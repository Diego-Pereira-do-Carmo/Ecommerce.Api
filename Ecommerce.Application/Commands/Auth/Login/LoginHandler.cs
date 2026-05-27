using Ecommerce.Application.Commands.Users.RegisterUser;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Dtos;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Interfaces.Repositories;
using Ecommerce.Domain.Interfaces.Security;
using Ecommerce.Domain.Interfaces.Services;
using Ecommerce.Domain.ValueObjects;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.Commands.Auth.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, Result<LoginResponseDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;
        private readonly ILogger<LoginHandler> _logger;

        public LoginHandler(
            IUserRepository userRepository,
            IPasswordService passwordService,
            ITokenService tokenService,
            ILogger<LoginHandler> logger)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _tokenService = tokenService;
            _logger = logger;
        }

        public async Task<Result<LoginResponseDto>> Handle(LoginCommand command, CancellationToken cancellationToken = default)
        {
            var email = new EmailAddressValueObject(command.EmailAddress);
            var user = await _userRepository.GetByEmailAsync(email, cancellationToken);

            if (user is null)
            {
                _logger.LogWarning($"Tentativa de login falhou: O e-mail {command.EmailAddress} não existe na base de dados.", command.EmailAddress);
                return Result<LoginResponseDto>.Failure("usuário não localizado, verifique e tente novamente");
            }

            var isPasswordValid = _passwordService.VerifyPassword(command.Password, user.PasswordHash);

            if (!isPasswordValid)
            {
                _logger.LogWarning($"Tentativa de login falhou: Senha incorreta para o e-mail {command.EmailAddress}.", command.EmailAddress);
                return Result<LoginResponseDto>.Failure("Usuário ou senha inválidos, verifique e tente novamente");
            }

            var jwtResult = _tokenService.GenerateToken(user);

            var loginResponse = new LoginResponseDto(
                Token: jwtResult.Value,
                Type: "Bearer",
                ExpiresIn: jwtResult.ExpiresIn,
                UserName: user.UserName
            );

            _logger.LogInformation($"Usuário {command.EmailAddress} autenticado com sucesso. Token gerado.", command.EmailAddress);

            return Result<LoginResponseDto>.Success(loginResponse, "Login realizado com sucesso.");
        }
    }
}
