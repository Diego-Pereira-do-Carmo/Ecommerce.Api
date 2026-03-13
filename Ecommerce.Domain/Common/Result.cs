
namespace Ecommerce.Domain.Common
{
    public class Result<T> : BaseResult
    {
        public T Value { get; }

        private Result(bool isSuccess, T value, string? message, IEnumerable<string>? errors = null)
            : base(isSuccess, message, errors)
        {
            Value = value;
        }

        public static Result<T> Success(T value, string message) => new Result<T>(true, value, message);
        public new static Result<T> Failure(string message) => new Result<T>(false, default, message);
        public new static Result<T> Failure(string message, IEnumerable<string> errors) => new Result<T>(false, default, message, errors);
    }
}
