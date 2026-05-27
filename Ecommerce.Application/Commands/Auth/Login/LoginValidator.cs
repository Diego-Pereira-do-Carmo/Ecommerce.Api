using FluentValidation;

namespace Ecommerce.Application.Commands.Auth.Login
{
    public class LoginValidator : AbstractValidator<LoginCommand>
    {
        public LoginValidator() 
        {
            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .WithMessage("O e-mail é obrigatório")
                .EmailAddress()
                .WithMessage("Formato de e-mail inválido");

            RuleFor(x => x.Password)
                 .NotEmpty()
                 .WithMessage("A senha é obrigatória")
                 .MinimumLength(8)
                 .WithMessage("A senha deve conter no minimo 8 caracteres");
        }
    }
}
