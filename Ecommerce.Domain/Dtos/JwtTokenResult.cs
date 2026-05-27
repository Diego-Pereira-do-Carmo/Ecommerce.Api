namespace Ecommerce.Domain.Dtos
{
    public record JwtTokenResult(string Value, DateTime ExpiresIn);
}
