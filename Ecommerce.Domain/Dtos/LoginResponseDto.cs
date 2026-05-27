namespace Ecommerce.Domain.Dtos
{
    public record LoginResponseDto(string Token, string Type, DateTime ExpiresIn, string UserName);
}
