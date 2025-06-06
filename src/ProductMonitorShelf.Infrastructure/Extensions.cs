﻿using Microsoft.Extensions.DependencyInjection;
using ProductMonitorShelf.Infrastructure.EF;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ProductMonitorShelf.Infrastructure.Repositories;
using ProductMonitorShelf.Core.Services;
using ProductMonitorShelf.Infrastructure.Services;
using ProductMonitorShelf.Infrastructure.Exceptions;

namespace ProductMonitorShelf.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductShortageRepository, ProductShortageRepository>();
            services.AddScoped<ICategorieRepository, CategorieRepository>();
            services.AddScoped<IImageProcessingService, ImageProcessingService>();
            services.AddSingleton<ExceptionMiddleware>();

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
