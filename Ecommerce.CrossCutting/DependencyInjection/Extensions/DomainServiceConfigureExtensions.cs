
using Ecommerce.Domain.Entities.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.CrossCutting.DependencyInjection.Extensions
{
    public static class DomainServiceConfigureExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            var domainAssembly = typeof(BaseEntity).Assembly;

            var serviceTypes = domainAssembly.GetTypes()
                                             .Where(t => t.IsClass && 
                                             !t.IsAbstract && 
                                             t.Name.EndsWith("DomainService"));

            foreach (var type in serviceTypes)
            {
                var interfaceType = type.GetInterfaces()
                                        .FirstOrDefault(i => i.Name == $"I{type.Name}" &&
                                                        i.Assembly == domainAssembly);

                if (interfaceType != null) services.AddScoped(interfaceType, type);
            }

            return services;
        }
    }
}
