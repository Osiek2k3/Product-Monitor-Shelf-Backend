
using ProductMonitorShelf.Core.DTO;
using ProductMonitorShelf.Core.Services;

namespace ProductMonitorShelf.Core.UseCase
{
    public class GetAllProductShortageUseCase
    {
        private readonly IProductShortageRepository _productShortageRepositories;

        public GetAllProductShortageUseCase(IProductShortageRepository productShortageRepositories)
        {
            _productShortageRepositories = productShortageRepositories;
        }

        public async Task<IEnumerable<ProductShortagesDto>> ExecuteAsync()
        {
            var result = await _productShortageRepositories.GetAllAsync();

            return result.Select(ProductShortagesDto.ToMap);
        }
    }
}