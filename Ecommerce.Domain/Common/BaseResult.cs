namespace Ecommerce.Domain.Common
{
    public class BaseResult
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string? Message { get; }
        public IEnumerable<string> Errors { get; }

        public BaseResult(bool isSuccess, string? message, IEnumerable<string>? errors = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            Errors = errors ?? Enumerable.Empty<string>();
        }

        protected static BaseResult Success(string message = "") => new(true, message);
        protected static BaseResult Failure(string message) => new(false, message);
        protected static BaseResult Failure(string message, IEnumerable<string> errors) => new(false, message, errors);
    }
}
