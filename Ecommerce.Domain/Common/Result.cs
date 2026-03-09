
namespace Ecommerce.Domain.Common
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public T Value { get; }
        public string? Message { get; }
        public IEnumerable<string> Errors { get; }

        private Result(bool isSuccess, T value, string? message, IEnumerable<string>? errors = null)
        {
            IsSuccess = isSuccess;
            Value = value;
            Message = message;
            Errors = errors ?? Enumerable.Empty<string>();
        }

        public static Result<T> Success(T value, string message) => new Result<T>(true, value, message);

        public static Result<T> Failure(string message) => new Result<T>(false, default, message);

        public static Result<T> Failure(string message, IEnumerable<string> errors) => new Result<T>(false, default, message, errors);
    }
}
