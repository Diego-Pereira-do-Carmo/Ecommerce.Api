
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.Seeders.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.Seeders
{
    internal class OrderStatusSeeder : BaseSeeder<OrderStatus>
    {
        private readonly string _prefix = "ORDS";
        private static readonly Guid _systemUserId = Guid.Parse("00000000-0000-0000-0000-000000000001");
        private static readonly DateTime _defaultDate = new DateTime(2026, 2, 10, 0, 0, 0, DateTimeKind.Utc);

        public override void Seed(EntityTypeBuilder<OrderStatus> builder)
        {
            var statusNameList = new[] { "Novo", "Processando", "Aguardando Envio", "Concluido", "Cancelado", "Separacao em Estoque" };
            var className = nameof(OrderStatus);

            foreach (var status in statusNameList)
            {
                builder.HasData(new
                {
                    Id = GenerateDeterministicGuid(status),
                    Name = status,
                    Flag = GenerateFlag(status),
                    FriendlyCode = $"{_prefix}{GenerateFriendlyCode(className, status)}",
                    Description = $"Define o estado de {status.ToLower()} no ciclo de vida global do pedido.",
                    CreatedOn = _defaultDate,
                    CreatedBy = _systemUserId,
                    IsActive = true,
                    IsDeleted = false
                });
            }
        }
    }
}
