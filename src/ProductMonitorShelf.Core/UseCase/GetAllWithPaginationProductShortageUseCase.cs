using ProductMonitorShelf.Core.DTO;
using ProductMonitorShelf.Core.Services;

namespace ProductMonitorShelf.Core.UseCase
{
    public class GetAllWithPaginationProductShortageUseCase
    {
        private readonly IProductShortageRepository _productShortageRepositories;

        public GetAllWithPaginationProductShortageUseCase(IProductShortageRepository productShortageRepositories)
        {
            _productShortageRepositories = productShortageRepositories;
        }

        public async Task<IEnumerable<ProductShortagesDto>> ExecuteAsync(int pageNumber, int pageSize)
        {
            var result = await _productShortageRepositories.GetAllWithPaginationAsync(pageNumber, pageSize);
            return result.Select(ProductShortagesDto.ToMap);
        }
    }
}