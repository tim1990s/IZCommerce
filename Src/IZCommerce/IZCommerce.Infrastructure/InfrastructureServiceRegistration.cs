using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IZCommerce.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register the service
            return services;
        }
    }
}
