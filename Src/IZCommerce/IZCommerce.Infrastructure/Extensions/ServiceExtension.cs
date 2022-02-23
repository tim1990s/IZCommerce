using IZCommerce.Infrastructure.DatabaseContext;
using IZCommerce.Infrastructure.Identity;
using IZCommerce.Infrastructure.Repositories;
using IZCommerce.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IZCommerce.Common.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigurationSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IZCommerceDBContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b => b.MigrationsAssembly("IZCommerce.API")));
        }

        public static void ConfigurationIdentityDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IZCommerceIdentityDbContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
    }
}
