using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Interfaces.Repositories;
using Ecommerce.Domain.Interfaces.Services;
using Ecommerce.Domain.ValueObjects;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Commands.Users.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Result<Guid>>
    {
        private readonly IUserRegistrationDomainService _userRegistrationDomainService;
        private readonly IUserRepository _userRepository;
        private readonly IAccessProfileRepository _accessProfileRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RegisterUserHandler> _logger;

        public RegisterUserHandler(
            IUserRegistrationDomainService userRegistrationDomainService,
            IUserRepository userRepository,
            IAccessProfileRepository accessProfileRepository,
            IUnitOfWork unitOfWork,
            ILogger<RegisterUserHandler> logger)
        {
            _userRegistrationDomainService = userRegistrationDomainService;
            _userRepository = userRepository;
            _accessProfileRepository = accessProfileRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Result<Guid>> Handle(RegisterUserCommand command, CancellationToken cancellationToken = default)
        {
            var existsUser = await _userRepository.AnyAsync(u => u.EmailAddress.Value == command.EmailAddress || u.Mobilephone.Value == command.MobilePhone);

            if (existsUser)
                return Result<Guid>.Failure("E-mail ou telefone já cadastrado verifique e tente novamente.");

            var email = new EmailAddressValueObject(command.EmailAddress);
            var mobilePhone = new PhoneNumberValueObject(command.MobilePhone);

            var accessFlagCustumer = "ACPR-02643";
            var accessprofile = await _accessProfileRepository.GetByFriendlyCode(accessFlagCustumer);

            if (accessprofile is null)
            {
               return Result<Guid>.Failure("Não foi possivel localizar o perfil de acesso");
            }

            User user = _userRegistrationDomainService.CreateUser(command.FirstName, command.LastName, accessprofile.Id, email, mobilePhone);

            await _userRepository.AddAsync(user);
            await _unitOfWork.CommitAsync();

            //envio do email com login e senha

            return Result<Guid>.Success(user.Id, "Cadastro realizado com sucesso, em breve enviaremos um e-mail de confirmação");
        }
    }
}
