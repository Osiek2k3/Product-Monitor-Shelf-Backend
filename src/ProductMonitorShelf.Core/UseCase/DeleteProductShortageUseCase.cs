using ProductMonitorShelf.Core.Services;

namespace ProductMonitorShelf.Core.UseCase
{
    public class DeleteProductShortageUseCase
    {
        private readonly IProductShortageRepository _productShortageRepository;

        public DeleteProductShortageUseCase(IProductShortageRepository productShortageRepository)
        {
            _productShortageRepository = productShortageRepository;
        }

        public async Task ExecuteAsync(int productShortageId)
        {
            await _productShortageRepository.DeleteAsync(productShortageId);
        }
    }
}