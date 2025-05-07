using ProductMonitorShelf.Core.Response;
using ProductMonitorShelf.Core.Services;

namespace ProductMonitorShelf.Core.UseCase
{
    public class GetCountAllProductShortageUseCase
    {
        private readonly IProductShortageRepository _productShortageRepositories;

        public GetCountAllProductShortageUseCase(IProductShortageRepository productShortageRepositories)
        {
            _productShortageRepositories = productShortageRepositories;
        }

        public async Task<Count> ExecuteAsync()
        {
            var result = await _productShortageRepositories.GetAllAsync();

            return new Count(result.Count());
        }
    }
}
