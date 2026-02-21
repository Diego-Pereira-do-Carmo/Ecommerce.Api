
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.Seeders.Base;

namespace Ecommerce.Infrastructure.Persistence.Seeders
{
    internal class OrderStatusSeeder : BaseSeeder<OrderStatus>
    {
        private readonly string _prefix = "ORDS";
        public override IEnumerable<OrderStatus> GetSeedData()
        {
            var statusNameList = new[] { "Novo", "Processando", "Aguardando Envio", "Concluido", "Cancelado", "Separacao em Estoque" };
            var className = nameof(OrderStatus);

            var defaultDate = new DateTime(2026, 2, 10, 0, 0, 0, DateTimeKind.Utc);
            var systemUserId = Guid.Parse("00000000-0000-0000-0000-000000000001");

            foreach (var status in statusNameList)
            {
                yield return new OrderStatus
                {
                    Id = GenerateDeterministicGuid(status),
                    Name = status,
                    Flag = GenerateFlag(status),
                    FriendlyCode = $"{_prefix}{GenerateFriendlyCode(className, status)}",
                    Description = $"Define o estado de {status.ToLower()} no ciclo de vida global do pedido.",

                    CreatedOn = defaultDate,
                    CreatedBy = systemUserId,
                    IsActive = true,
                    IsDeleted = false
                };
            }
        }
    }
}
