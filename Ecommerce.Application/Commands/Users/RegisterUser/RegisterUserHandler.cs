
using Ecommerce.Domain.Interfaces.Repositories;
using Ecommerce.Domain.ValueObjects;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Commands.Users.RegisterUser
{
    public class RegisterUserHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserHandler(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            // 1. Transformamos a string do comando no seu Value Object
            // Se o seu VO tiver uma factory ou construtor que valida:
            var emailVO = new EmailAddressValueObject(command.Email);
            var mobilePhoneVO = new PhoneNumberValueObject("(11) 97731-3094");

            // 2. Usamos o Value Object para a regra de negócio no repositório
            // Note que usamos o .Value ou o próprio objeto dependendo de como você mapeou no EF
            var emailExists = await _userRepository.AnyAsync(u => u.EmailAddress.Value == emailVO.Value);

            if (emailExists) return false;

            // 3. Criamos a entidade User passando o Value Object
            User user = new User(
                "userName",
                "firstName",
                "lastName",
                emailVO,
                mobilePhoneVO,
                "passwordHash");


            await _userRepository.InsertAsync(user);
            return await _unitOfWork.CommitAsync();
        }
    }
}
