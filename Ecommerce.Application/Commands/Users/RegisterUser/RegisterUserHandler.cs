using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Interfaces.Repositories;
using Ecommerce.Domain.Interfaces.Services;
using Ecommerce.Domain.ValueObjects;

namespace Ecommerce.Application.Commands.Users.RegisterUser
{
    public class RegisterUserHandler
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

        public async Task<bool> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var emailVO = new EmailAddressValueObject(command.Email);
            var mobilePhoneVO = new PhoneNumberValueObject(command.MobilePhone);

            var emailExists = await _userRepository.AnyAsync(u => u.EmailAddress.Value == emailVO.Value);

            if (emailExists) return false;

            User user = _userRegistrationDomainService.CreateUser(
                emailVO.GetUserName(),
                command.FirstName,
                command.LastName,
                emailVO,
                mobilePhoneVO
            );

            await _userRepository.InsertAsync(user);
            return await _unitOfWork.CommitAsync();
        }
    }
}
