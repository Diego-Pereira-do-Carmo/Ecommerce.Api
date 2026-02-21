
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.Seeders.Base;

namespace Ecommerce.Infrastructure.Persistence.Seeders
{
    internal class ProductReviewStatusSeeder : BaseSeeder<ProductReviewStatus>
    {
        private readonly string _prefix = "PDRS";
        public override IEnumerable<ProductReviewStatus> GetSeedData()
        {
            var statusNameList = new[] { "Pendente de Aprovação", "Aprovado", "Rejeitado", "Arquivado" };
            var className = nameof(ProductReviewStatus);

            var defaultDate = new DateTime(2026, 2, 10, 0, 0, 0, DateTimeKind.Utc);
            var systemUserId = Guid.Parse("00000000-0000-0000-0000-000000000001");

            foreach (var status in statusNameList)
            {
                yield return new ProductReviewStatus
                {
                    Id = GenerateDeterministicGuid(status),
                    Name = status,
                    Flag = GenerateFlag(status),
                    FriendlyCode = $"{_prefix}{GenerateFriendlyCode(className, status)}",
                    Description = $"Define o estado de {status.ToLower()} no ciclo de vida do processamento de reviews.",

                    CreatedOn = defaultDate,
                    CreatedBy = systemUserId,
                    IsActive = true,
                    IsDeleted = false
                };
            }
        }
    }
}
