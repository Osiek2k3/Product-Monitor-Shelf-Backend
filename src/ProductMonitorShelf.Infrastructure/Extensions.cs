using Microsoft.Extensions.DependencyInjection;
using ProductMonitorShelf.Infrastructure.EF;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ProductMonitorShelf.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SqlServerOptions>(configuration.GetSection("SqlServer"));

            services.AddDbContext<MyDbContext>((serviceProvider, options) =>
            {
                var sqlOptions = serviceProvider.GetRequiredService<Microsoft.Extensions.Options.IOptions<SqlServerOptions>>().Value;
                options.UseSqlServer(sqlOptions.ConnectionString);
            });

            return services;
        }
    }
}
