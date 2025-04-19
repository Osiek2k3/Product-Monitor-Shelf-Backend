using Microsoft.AspNetCore.Mvc;
using ProductMonitorShelf.Core.DTO;
using ProductMonitorShelf.Core.UseCase;

namespace ProductMonitorShelf.Api.Controllers
{
    [ApiController]
    [Route("productShortage")]
    public class ProductShortageController : ControllerBase
    {
        private readonly GetAllProductShortageUseCase _getAllProductShortageUseCase;
        public ProductShortageController(GetAllProductShortageUseCase getAllProductShortageUseCase)
        {
            _getAllProductShortageUseCase = getAllProductShortageUseCase;
        }

        // GET: api/ProductShortages
        //zwraca wszystkie braki produktów
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductShortagesDto>>> GetAll()
        {
            var ProductShortage = await _getAllProductShortageUseCase.ExecuteAsync();
            return Ok(ProductShortage);
        }
    }
}