using Ecommerce.Application.Commands.Users.RegisterUser;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Interfaces.Repositories;
using Ecommerce.Domain.Interfaces.Services;
using FluentAssertions;
using FluentAssertions.Execution;
using NSubstitute;
using System.Linq.Expressions;

namespace Ecommerce.UnitTests.Application.Commands.Users.RegisterUser
{
    public class RegisterUserHandlerTest
    {
        private readonly IUserRegistrationDomainService _userRegistrationDomainServiceMock;
        private readonly IUserRepository _userRepositoryMock;
        private readonly IUnitOfWork _uowMock;
        private readonly RegisterUserHandler _registerUserHandler;

        public RegisterUserHandlerTest()
        {
            _userRegistrationDomainServiceMock = Substitute.For<IUserRegistrationDomainService>();
            _userRepositoryMock = Substitute.For<IUserRepository>();
            _uowMock = Substitute.For<IUnitOfWork>();
            _registerUserHandler = new RegisterUserHandler(_userRegistrationDomainServiceMock, _userRepositoryMock, _uowMock);
        }

        [Fact]
        public async Task Given_ValidComand_Then_CreateUser()
        {
            RegisterUserCommand command = new RegisterUserCommand("Fulano", "de Tal", "fulano@email.com", "(11) 94002-8922");

            _userRepositoryMock.AnyAsync(Arg.Any<Expression<Func<User, bool>>>()).Returns(false);

            var fakeUser = Substitute.For<User>();

            _userRegistrationDomainServiceMock.CreateUser(command.FirstName, command.LastName, command.EmailAddress, command.MobilePhone)
                                              .Returns(fakeUser);

            var result = await _registerUserHandler.Handle(command);

            using (new AssertionScope())
            {
                result.IsSuccess.Should().BeTrue();
                result.IsFailure.Should().BeFalse();
                result.Message.Should().Be("Cadastro realizado com sucesso, em breve enviaremos um e-mail de confirmação");

                _userRegistrationDomainServiceMock.Received(1).CreateUser(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
                await _userRepositoryMock.Received(1).AddAsync(fakeUser);
                await _uowMock.Received(1).CommitAsync();
            }
        }


        [Fact]
        public async Task Given_ExistingEmail_Then_ReturnFailure()
        {
            RegisterUserCommand command = new RegisterUserCommand("Fulano", "de Tal", "existente@email.com", "(11) 94002-8922");

            _userRepositoryMock.AnyAsync(Arg.Any<Expression<Func<User, bool>>>()).Returns(true);
            var fakeUser = Substitute.For<User>();


            var result = await _registerUserHandler.Handle(command);

            using (new AssertionScope())
            {
                result.IsSuccess.Should().BeFalse();
                result.IsFailure.Should().BeTrue();
                result.Message.Should().Be("E-mail já cadastrado verifique e tente novamente.");

                _userRegistrationDomainServiceMock.DidNotReceive().CreateUser(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
                await _uowMock.DidNotReceive().CommitAsync();
            }
        }


















        //[Fact]
        //public async Task Given_EmailAlreadyExists_ShouldReturnFalse()
        //{
        //    var command = new RegisterUserCommand("Fulano", "de Tal", "fulano@email.com", "(11) 94002-8922", "Senha123!");

        //    _userRepositoryMock.AnyAsync(Arg.Any<Expression<Func<User, bool>>>())
        //                   .Returns(true);

        //    var result = await _handler.Handle(command, CancellationToken.None);

        //    result.Should().BeFalse();
        //    await _uowMock.DidNotReceive().CommitAsync();
        //}

        //[Fact]
        //public async Task Handle_WhenEmailDoesNotExist_ShouldReturnTrue()
        //{
        //    var command = new RegisterUserCommand("Ciclano", "de Tal", "ciclano@email.com", "(11) 94002-8933", "Senha@123!");

        //    _userRepositoryMock.AnyAsync(Arg.Any<Expression<Func<User, bool>>>())
        //                   .Returns(false);

        //    _uowMock.CommitAsync().Returns(true);

        //    var result = await _handler.Handle(command, CancellationToken.None);

        //    result.Should().BeTrue();

        //    await _userRepositoryMock.Received(1).InsertAsync(Arg.Any<User>());
        //    await _uowMock.Received(1).CommitAsync();
        //}
    }
}
