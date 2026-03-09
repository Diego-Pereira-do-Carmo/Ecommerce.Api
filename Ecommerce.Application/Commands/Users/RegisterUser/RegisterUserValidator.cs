using FluentValidation;

namespace Ecommerce.Application.Commands.Users.RegisterUser
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("O primeiro é obrigatório")
                .MinimumLength(2)
                .WithMessage("O primeiro nome deve ter 2 ou mais caracteres")
                .MaximumLength(50)
                .WithMessage("O primeiro nome deve ter no máximo 50 caracteres.");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("O sobrenome é obrigatório.")
                .MinimumLength(2)
                .WithMessage("O sobrenome deve ter 2 ou mais caracteres")
                .MaximumLength(100)
                .WithMessage("O sobrenome deve ter no máximo 100 caracteres.");

            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .WithMessage("O e-mail é obrigatório.")
                .EmailAddress()
                .WithMessage("Formato de e-mail inválido.");

            RuleFor(x => x.MobilePhone)
                .NotEmpty()
                .WithMessage("O telefone celular é obrigatório.")
                .MinimumLength(10)
                .WithMessage("O telefone celular deve ter no minimo 10 caracteres")
                .MaximumLength(13)
                .WithMessage("O telefone celular deve ter no máximo 13 caracteres.");
        }
    }
}
