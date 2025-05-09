using ProductMonitorShelf.Core.DTO;
using ProductMonitorShelf.Core.Services;

namespace ProductMonitorShelf.Core.UseCase
{
    public class GetAllProductsInCategorieUseCase
    {
        private readonly IProductShortageRepository _productShortageRepositories;

        public GetAllProductsInCategorieUseCase(IProductShortageRepository productShortageRepositories)
        {
            _productShortageRepositories = productShortageRepositories;
        }

        public async Task<IEnumerable<ProductShortagesDto>> ExecuteAsync(int categoryId)
        {
            var result = await _productShortageRepositories.GetAllProductInCategoryAsync(categoryId);

            return result.Select(ProductShortagesDto.ToMap);
        }
    }
}
