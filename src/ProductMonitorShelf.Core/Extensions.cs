using Microsoft.Extensions.DependencyInjection;
using ProductMonitorShelf.Core.UseCase;

namespace ProductMonitorShelf.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddTransient<GetAllProductShortageUseCase>();
            services.AddTransient<GetAllWithPaginationProductShortageUseCase>();
            services.AddTransient<GetAllCategoriesUseCase>();
            services.AddTransient<DeleteProductShortageUseCase>();
            return services;
        }
    }

}