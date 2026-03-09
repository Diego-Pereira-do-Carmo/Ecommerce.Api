
using Ecommerce.Domain.Common;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Ecommerce.UnitTests.Domain.Common
{
    public class ResultTest
    {
        [Fact]
        public void Given_ResultIsSuccess_ThenCreateSuccessfulResultWithValueAndMessage()
        {
            var value = "Dados de Teste";
            var message = "Operação realizada";

            var result = Result<string>.Success(value, message);

            using (new AssertionScope())
            {
                result.IsSuccess.Should().BeTrue();
                result.IsFailure.Should().BeFalse();
                result.Value.Should().Be(value);
                result.Message.Should().Be(message);
                result.Errors.Should().BeEmpty();
            }
        }

        [Fact]
        public void Given_ResultIsFailure_Then_CreateFailureResultWithDefaultValueAndMessage()
        {
            var message = "Erro ao processar";

            var result = Result<int>.Failure(message);
            using (new AssertionScope())
            {
                result.IsSuccess.Should().BeFalse();
                result.IsFailure.Should().BeTrue();
                result.Value.Should().Be(0);
                result.Message.Should().Be(message);
                result.Errors.Should().BeEmpty();
            }
        }

        [Fact]
        public void Failure_WithMultipleErrors_ShouldStoreAllErrors()
        {
            var message = "Erros de validação";
            var errors = new List<string> { "Campo 'Teste 1' inválido", "Campo 'Teste 2' obrigatório" };

            var result = Result<Guid>.Failure(message, errors);

            result.IsSuccess.Should().BeFalse();
            result.Errors.Should().HaveCount(2);
            result.Errors.Should().Contain(errors);
        }
    }
}
