
using Ecommerce.Infrastructure.Persistence.Context;
using Ecommerce.Infrastructure.Persistence.Seeders.SeederInterface;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Reflection;

namespace Ecommerce.Infrastructure.Persistence.Extensions
{
    internal static class ModelBuilderExtensions
    {
        public static void ApplySeeders(this ModelBuilder modelBuilder, Assembly assembly)
        {
            var infrastructureAssembly = typeof(EcommerceDbContext).Assembly;

            var seeders = infrastructureAssembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISeeder<>))
                    && !t.IsAbstract && !t.IsInterface)
                .ToList();

            foreach (var seederType in seeders)
            {
                var interfaceType = seederType.GetInterfaces()
                    .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ISeeder<>));

                var entityType = interfaceType.GetGenericArguments()[0];

                var seederInstance = Activator.CreateInstance(seederType);

                var method = seederType.GetMethod("GetSeedData");

                if (method != null && seederInstance != null)
                {
                    var data = method.Invoke(seederInstance, null) as IEnumerable;

                    if (data != null)
                    {
                        var dataArray = data.Cast<object>().ToArray();

                        if (dataArray.Any())
                        {
                            modelBuilder.Entity(entityType).HasData(dataArray);
                        }
                    }
                }
            }
        } 
    }
}
