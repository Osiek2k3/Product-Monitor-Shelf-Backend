using ProductMonitorShelf.Core.DTO;
using ProductMonitorShelf.Core.Services;

namespace ProductMonitorShelf.Core.UseCase
{
    public class GetProductShortageByIdUseCase
    {
        private readonly IProductShortageRepository _productShortageRepositories;

        public GetProductShortageByIdUseCase(IProductShortageRepository productShortageRepositories)
        {
            _productShortageRepositories = productShortageRepositories;
        }

        public async Task<ProductShortagesDto> ExecuteAsync(int productShortageId)
        {
            var result = await _productShortageRepositories.GetByIdAsync(productShortageId);

            return ProductShortagesDto.ToMap(result);
        }
    }
}
