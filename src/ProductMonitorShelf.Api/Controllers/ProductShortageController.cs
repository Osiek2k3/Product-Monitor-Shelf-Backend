using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductMonitorShelf.Core.DTO;
using ProductMonitorShelf.Core.Entities;
using ProductMonitorShelf.Core.Response;
using ProductMonitorShelf.Core.UseCase;
using System.Drawing;

namespace ProductMonitorShelf.Api.Controllers
{
    [ApiController]
    [Route("productShortage")]
    public class ProductShortageController : ControllerBase
    {
        // GET: api/ProductShortages/all
        /// <summary>
        /// zwraca wszystkie braki produktów       
        /// </summary>
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ProductShortagesDto>>> GetAll(
            [FromServices] GetAllProductShortageUseCase _getAllProductShortageUseCase)
        {
            var ProductShortage = await _getAllProductShortageUseCase.ExecuteAsync();
            return Ok(ProductShortage);
        }

        // GET: api/ProductShortages/Count
        /// <summary>
        /// zwraca liczbe wszystkich braków produktów      
        /// </summary>
        [HttpGet("Count")]
        public async Task<ActionResult<IEnumerable<ProductShortagesDto>>> GetCountAllProductShortage(
            [FromServices] GetCountAllProductShortageUseCase _getCountAllProductShortageUseCase)
        {
            var Count = await _getCountAllProductShortageUseCase.ExecuteAsync();
            return Ok(Count);
        }

        // GET: api/ProductShortages/Paginated
        /// <summary>
        /// zwraca wszystkie braki produktów z paginacją       
        /// </summary>
        [HttpGet("Paginated")]
        public async Task<ActionResult<IEnumerable<ProductShortagesDto>>> GetAllWithPagination(
            [FromServices] GetAllWithPaginationProductShortageUseCase _getAllWithPaginationProductShortageUseCase,
            [FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var ProductShortage = await _getAllWithPaginationProductShortageUseCase.ExecuteAsync(pageNumber, pageSize);
            return Ok(ProductShortage);
        }

        // GET: api/ProductShortages/byId/{id}
        /// <summary>
        /// zwraca brak produktu po ID    
        /// </summary>
        [HttpGet("byId")]
        public async Task<ActionResult<IEnumerable<ProductShortagesDto>>> GetProductShortageById(
            [FromServices] GetProductShortageByIdUseCase _getProductShortageByIdUseCase,
            int productShortageId)
        {
            var ProductShortage = await _getProductShortageByIdUseCase.ExecuteAsync(productShortageId);
            //return File(ProductShortage.FileData, "image/jpeg");
            return Ok(ProductShortage);
        }


        // GET: api/ProductShortages/Categories
        /// <summary>
        /// zwraca wszystkie kategorie      
        /// </summary>
        [HttpGet("Categories")]
        public async Task<ActionResult<IEnumerable<GetAllCategoriesResponse>>> GetAllCategories(
            [FromServices] GetAllCategoriesUseCase _getAllCategoriesUseCase)
        {
            var categories = await _getAllCategoriesUseCase.ExecuteAsync();
            return Ok(categories);
        }

        // GET: api/ProductShortages/Categories/{categoryId}
        /// <summary>
        /// Zwraca wszystkie kategorie jak i liczbe braków w dane kategorii
        /// </summary>
        [HttpGet("Categories/{categoryId}")]
        public async Task<ActionResult<IEnumerable<ProductShortagesDto>>> GetAllProductsInCategorie(
            [FromServices] GetAllProductsInCategorieUseCase _getAllProductsInCategorieUseCase,
            int categoryId)
        {
            var ProductShortages = await _getAllProductsInCategorieUseCase.ExecuteAsync(categoryId);
            return Ok(ProductShortages);
        }

        // GET: api/ProductShortages/Categories/{categoryId}/Count
        /// <summary>
        /// Zwraca liczbe produktów w danej kategorii
        /// </summary>
        [HttpGet("Categories/{categoryId}/Count")]
        public async Task<ActionResult<int>> GetCountProductsInCategorie(
            [FromServices] GetCountProductsInCategorieUseCase _getCountProductsInCategorieUseCase,
            int categoryId)
        {
            var count = await _getCountProductsInCategorieUseCase.ExecuteAsync(categoryId);
            return Ok(count);
        }

        // GET: api/ProductShortages/Categories/{categoryId}/Paginated
        /// <summary>
        /// Zwraca produkty w danej kategorii z paginacją
        /// </summary>
        [HttpGet("Categories/{categoryId}/Paginated")]
        public async Task<ActionResult<IEnumerable<ProductShortagesDto>>> GetProductsInCategorieWithPagination(
            [FromServices] GetProductsInCategorieWithPaginationUseCase _getProductsInCategorieWithPaginationUseCase,
            [FromQuery] int pageNumber, [FromQuery] int pageSize, int categoryId)
        {
            var ProductShortage = await _getProductsInCategorieWithPaginationUseCase.ExecuteAsync(
                categoryId, pageNumber, pageSize);
            return Ok(ProductShortage);
        }

        // DELETE: api/ProductShortages/{id}
        /// <summary>
        /// Usuwa brak produktu po ID     
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> DeleteProductShortage(
            [FromServices] DeleteProductShortageUseCase _deleteProductShortageUseCase,
            int id)
        {
            await _deleteProductShortageUseCase.ExecuteAsync(id);
            return NoContent();
        }
    }
}