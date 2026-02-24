
using Ecommerce.Application.Commands.Users.RegisterUser;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Interfaces.Repositories;
using FluentAssertions;
using NSubstitute;
using System.Linq.Expressions;

namespace Ecommerce.UnitTests.Application.Commands.Users.RegisterUser
{
    public class RegisterUserHandlerTests
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly RegisterUserHandler _handler;

        public RegisterUserHandlerTests()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _unitOfWork = Substitute.For<IUnitOfWork>();

            _handler = new RegisterUserHandler(_userRepository, _unitOfWork);
        }

        [Fact]
        public async Task Handle_WhenEmailAlreadyExists_ShouldReturnFalse()
        {
            var command = new RegisterUserCommand("Joao", "joao@email.com", "Senha123!");

            _userRepository.AnyAsync(Arg.Any<Expression<Func<User, bool>>>())
                           .Returns(true);

            var result = await _handler.Handle(command, CancellationToken.None);

            result.Should().BeFalse();
            await _unitOfWork.DidNotReceive().CommitAsync();
        }

        [Fact]
        public async Task Handle_WhenEmailAlreadyNotExists_ShouldReturnTrue()
        {
            var command = new RegisterUserCommand("Maria", "maria@email.com", "Senha123!");

            _userRepository.AnyAsync(Arg.Any<Expression<Func<User, bool>>>())
                           .Returns(false);

            _unitOfWork.CommitAsync().Returns(true);

            var result = await _handler.Handle(command, CancellationToken.None);

            result.Should().BeTrue();

            await _userRepository.Received(1).InsertAsync(Arg.Any<User>());
            await _unitOfWork.Received(1).CommitAsync();
        }
    }
}
