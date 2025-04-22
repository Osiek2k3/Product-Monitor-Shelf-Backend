using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductMonitorShelf.Core.DTO;
using ProductMonitorShelf.Core.UseCase;

namespace ProductMonitorShelf.Api.Controllers
{
    [ApiController]
    [Route("productShortage")]
    public class ProductShortageController : ControllerBase
    {
        // GET: api/ProductShortages
        //zwraca wszystkie braki produktów
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductShortagesDto>>> GetAll(
            [FromServices] GetAllProductShortageUseCase _getAllProductShortageUseCase)
        {
            var ProductShortage = await _getAllProductShortageUseCase.ExecuteAsync();
            return Ok(ProductShortage);
        }

        // GET: api/ProductShortages
        //zwraca wszystkie braki produktów z paginacją
        [HttpGet("paginated")]
        public async Task<ActionResult<IEnumerable<ProductShortagesDto>>> GetAllWithPagination(
            [FromServices] GetAllWithPaginationProductShortageUseCase _getAllWithPaginationProductShortageUseCase,
            [FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var ProductShortage = await _getAllWithPaginationProductShortageUseCase.ExecuteAsync(pageNumber, pageSize);
            return Ok(ProductShortage);
        }

        // GET: api/ProductShortages/{id}
        //zwraca brak produktu po ID


        // GET: api/ProductShortages/categories
        //zwraca wszystkie kategorie
        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<object>>> GetAllCategories(
            [FromServices] GetAllCategoriesUseCase _getAllCategoriesUseCase)
        {
            var categories = await _getAllCategoriesUseCase.ExecuteAsync();
            return Ok(categories);
        }

        // DELETE: api/ProductShortages/{id}
        //Usuwa brak produktu po ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductShortage(
            [FromServices] DeleteProductShortageUseCase _deleteProductShortageUseCase,
            int id)
        {
            await _deleteProductShortageUseCase.ExecuteAsync(id);
            return NoContent();
        }
    }
}