
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Infrastructure.Exceptions;
using Ecommerce.Infrastructure.Persistence.Seeders.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.Seeders
{
    internal class EntityMetadataSeeder : BaseSeeder<EntityMetadata>
    {
        public override void Seed(EntityTypeBuilder<EntityMetadata> builder)
        {
            var domainAssembly = typeof(BaseEntity).Assembly;

            var entityTypes = domainAssembly.GetTypes()
                        .Where(t => t.IsSubclassOf(typeof(BaseEntity)) && !t.IsAbstract)
                        .OrderBy(t => t.FullName)
                        .ToList();

            var usedCodes = new HashSet<string>();
            var usedGuids = new HashSet<Guid>();

            foreach (var type in entityTypes)
            {
                var fullName = type.FullName;
                var name = type.Name;

                if (string.IsNullOrWhiteSpace(fullName))
                {
                    throw new SeedingException(name, $"Falha na identificação completa do tipo.", $"O reflexo do Assembly não conseguiu obter o FullName para a classe '{type.Name}'. " +
                                                     "Certifique-se de que a entidade não seja um tipo anônimo ou gerado dinamicamente.");
                }

                string code = GenerateDeterministicEntityCode(fullName);
                Guid guid = GenerateDeterministicGuid(fullName);

                if (!usedCodes.Add(code))
                {
                    throw new SeedingException(name, "Colisão crítica de EntityCode detectada.", $"O código {code} já foi gerado para outra entidade neste assembly.");
                }

                if (!usedGuids.Add(guid))
                {
                    throw new SeedingException(name, "Colisão crítica de GUID detectada.", $"O ID {guid} já existe. Verifique se há nomes de classes duplicados.");
                }

                builder.HasData(new
                {
                    Id = guid,
                    EntityName = name,
                    EntityCode = code,
                });
            }
        }
    }
}
