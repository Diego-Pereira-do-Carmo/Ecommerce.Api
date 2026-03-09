using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Interfaces.Repositories;
using Ecommerce.Domain.Interfaces.Services;
using MediatR;

namespace Ecommerce.Application.Commands.Users.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Result<Guid>>
    {
        private readonly IUserRegistrationDomainService _userRegistrationDomainService;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserHandler(
            IUserRegistrationDomainService userRegistrationDomainService,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            _userRegistrationDomainService = userRegistrationDomainService;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(RegisterUserCommand command, CancellationToken cancellationToken = default)
        {
            try
            {
               var exists = await _userRepository.AnyAsync(u => u.EmailAddress.Value == command.EmailAddress);

                if (exists)
                    return Result<Guid>.Failure("E-mail já cadastrado verifique e tente novamente.");

                User user = _userRegistrationDomainService.CreateUser(command.FirstName, command.LastName, command.EmailAddress, command.MobilePhone);

                await _userRepository.AddAsync(user);
                await _unitOfWork.CommitAsync();

                return Result<Guid>.Success(user.Id, "Cadastro realizado com sucesso, em breve enviaremos um e-mail de confirmação");
            }
            catch (Exception ex)
            {
                return Result<Guid>.Failure("Ocorreu um erro interno, verifique e tente novamente");
            }
        }
    }
}
