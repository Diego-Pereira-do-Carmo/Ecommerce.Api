using Ecommerce.Application.Behaviors;
using Ecommerce.Application.Commands.Users.RegisterUser;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.CrossCutting.DependencyInjection.Extensions
{
    public static class ApplicationConfigureExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var applicationAssembly = typeof(RegisterUserHandler).Assembly;

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(applicationAssembly);
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(applicationAssembly);
            return services;
        }
    }
}
