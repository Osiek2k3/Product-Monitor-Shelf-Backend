using ProductMonitorShelf.Core.Entities;
using ProductMonitorShelf.Core.Response;
using ProductMonitorShelf.Core.Services;

namespace ProductMonitorShelf.Core.UseCase
{
    public class GetCountProductsInCategorieUseCase
    {
        private readonly IProductShortageRepository _productShortageRepositories;

        public GetCountProductsInCategorieUseCase(IProductShortageRepository productShortageRepositories)
        {
            _productShortageRepositories = productShortageRepositories;
        }

        public async Task<Count> ExecuteAsync(int categoryId)
        {
            var result = await _productShortageRepositories.GetAllProductInCategoryAsync(categoryId);

            return new Count(result.Count());
        }
    }
}
