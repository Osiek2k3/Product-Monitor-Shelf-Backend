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
            var results = new List<GetAllCategoriesResponse>();

            foreach (var department in departments)
            {
                var count = await _productShortageRepository.GetDepartamentCountAsync(department.DepartmentId);
                results.Add(new GetAllCategoriesResponse(department, count));
            }

            return results;
        }
    }
}
