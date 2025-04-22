using ProductMonitorShelf.Core.DTO;
using ProductMonitorShelf.Core.Entities;
using ProductMonitorShelf.Core.Response;
using ProductMonitorShelf.Core.Services;

namespace ProductMonitorShelf.Core.UseCase
{
    public  class GetAllCategoriesUseCase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IProductShortageRepository _productShortageRepository;

        public GetAllCategoriesUseCase(
            IDepartmentRepository departmentRepository,
            IProductShortageRepository productShortageRepository)
        {
            _departmentRepository = departmentRepository;
            _productShortageRepository = productShortageRepository;
        }

        public async Task<IEnumerable<GetAllCategoriesResponse>> ExecuteAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();

            var tasks = departments.Select(async department =>
            {
                var count = await _productShortageRepository.GetDepartamentCountAsync(department.DepartmentId);
                return new GetAllCategoriesResponse(department, count);
            });

            var results = await Task.WhenAll(tasks);
            return results;
        }
    }
}
