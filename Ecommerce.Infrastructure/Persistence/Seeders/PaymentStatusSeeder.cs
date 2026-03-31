using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.Seeders.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.Seeders
{
    internal class PaymentStatusSeeder : BaseSeeder<PaymentStatus>
    {
        private readonly string _prefix = "PAYS";
        private static readonly Guid _systemUserId = Guid.Parse("00000000-0000-0000-0000-000000000001");
        private static readonly DateTime _defaultDate = new DateTime(2026, 2, 10, 0, 0, 0, DateTimeKind.Utc);

        public override void Seed(EntityTypeBuilder<PaymentStatus> builder)
        {
            var statusNameList = new[] { "Aguardando Pagamento", "Em Analise", "Aprovado", "Recusado", "Estornado", "Cancelado" };
            var className = nameof(PaymentStatus);

            foreach (var status in statusNameList)
            {
                var id = GenerateDeterministicGuid(status);

                builder.HasData(new
                {
                    Id = id,
                    Name = status,
                    FriendlyCode = GenerateFriendlyCode(id, className),
                    Flag = GenerateFlag(status),
                    Description = $"Define o estado de {status.ToLower()} no ciclo de vida do fluxo financeiro.",
                    CreatedOn = _defaultDate,
                    CreatedBy = _systemUserId,
                    IsActive = true,
                    IsDeleted = false
                });
            }
        }
    }
}
