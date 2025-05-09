using ProductMonitorShelf.Core.DTO;
using ProductMonitorShelf.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMonitorShelf.Core.UseCase
{
    public class GetProductsInCategorieWithPaginationUseCase
    {
        private readonly IProductShortageRepository _productShortageRepositories;

        public GetProductsInCategorieWithPaginationUseCase(IProductShortageRepository productShortageRepositories)
        {
            _productShortageRepositories = productShortageRepositories;
        }

        public async Task<IEnumerable<ProductShortagesDto>> ExecuteAsync(int categoryId, int pageNumber, int pageSize)
        {
            var result = await _productShortageRepositories.GetProductsInCategorieWithPaginationAsync(
                categoryId, pageNumber, pageSize);
            return result.Select(ProductShortagesDto.ToMap);
        }
    }
}
