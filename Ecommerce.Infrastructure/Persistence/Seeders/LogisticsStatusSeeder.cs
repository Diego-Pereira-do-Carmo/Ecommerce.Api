
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistence.Seeders.Base;

namespace Ecommerce.Infrastructure.Persistence.Seeders
{
    internal class LogisticsStatusSeeder : BaseSeeder<LogisticStatus>
    {
        private readonly string _prefix = "LGCS";
        public override IEnumerable<LogisticStatus> GetSeedData()
        {
            var statusNameList = new[] { "Aguardando Coleta", "Postado", "Em Transito", "Saiu para Entrega", "Entregue", "Extraviado", "Devolvido" };
            var className = nameof(LogisticStatus);

            var defaultDate = new DateTime(2026, 2, 10, 0, 0, 0, DateTimeKind.Utc);
            var systemUserId = Guid.Parse("00000000-0000-0000-0000-000000000001");

            foreach (var status in statusNameList)
            {
                yield return new LogisticStatus
                {
                    Id = GenerateDeterministicGuid(status),
                    Name = status,
                    Flag = GenerateFlag(status),
                    FriendlyCode = $"{_prefix}{GenerateFriendlyCode(className, status)}",
                    Description = $"Define o estado de {status.ToLower()} no ciclo de vida da entrega logística.",

                    CreatedOn = defaultDate,
                    CreatedBy = systemUserId,
                    IsActive = true,
                    IsDeleted = false
                };
            }
        }
    }
}
