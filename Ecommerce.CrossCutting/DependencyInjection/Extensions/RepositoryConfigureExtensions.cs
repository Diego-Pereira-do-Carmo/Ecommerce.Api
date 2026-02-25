
using Ecommerce.Domain.Entities.Base;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Infrastructure.Persistence;
using Ecommerce.Infrastructure.Persistence.Context;
using Ecommerce.Infrastructure.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.CrossCutting.DependencyInjection.Extensions
{
    public static class RepositoryConfigureExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EcommerceDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            var infrastructureAssembly = typeof(BaseRepository<>).Assembly;
            var domainAssembly = typeof(BaseEntity).Assembly;

            var repositoryTypes = infrastructureAssembly.GetTypes()
                                               .Where(t => t.IsClass && 
                                                      !t.IsAbstract && 
                                                      t.Name.EndsWith("Repository"));

            foreach (var type in repositoryTypes)
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
