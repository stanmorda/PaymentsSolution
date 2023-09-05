using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication2
{
    public static class MyConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddDbConfig(
            this IServiceCollection services, IConfiguration config)
        {
            services.Configure<DbConfig>(config.GetSection(DbConfig.Position));

            return services;
        }
    }
}