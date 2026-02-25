
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Infrastructure.Persistence.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.CrossCutting.DependencyInjection.Extensions
{
    public static class SecurityServiceConfigureExtensions
    {
        public static IServiceCollection AddSecurityServices(this IServiceCollection services)
        {
            var infrastructureAssembly = typeof(BaseRepository<>).Assembly;
            var domainAssembly = typeof(BaseEntity).Assembly;

            var serviceTypes = infrastructureAssembly.GetTypes()
                                                     .Where(t => t.IsClass &&
                                                            !t.IsAbstract &&
                                                            t.Namespace != null && t.Namespace.Contains("Security") &&
                                                            t.Name.EndsWith("Service"));

            foreach (var type in serviceTypes)
            {
                var interfaceType = type.GetInterfaces()
                                        .FirstOrDefault(i => i.Name == $"I{type.Name}" &&
                                                        i.Assembly == domainAssembly);

                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, type);
                }
            }

            return services;
        }
    }
}
