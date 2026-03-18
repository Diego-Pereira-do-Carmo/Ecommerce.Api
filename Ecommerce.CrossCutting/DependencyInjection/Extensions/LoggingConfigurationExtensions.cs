using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Ecommerce.CrossCutting.DependencyInjection.Extensions
{
    public static class LoggingConfigurationExtensions
    {
        public static void AddLoggingConfiguration(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.PostgreSQL(
                    connectionString: connectionString,
                    tableName: "ecommerceLog",
                    needAutoCreateTable: true
                )
                .CreateLogger();

            builder.Host.UseSerilog();
        }
    }
}
