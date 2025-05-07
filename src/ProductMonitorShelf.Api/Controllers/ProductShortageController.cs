using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductMonitorShelf.Core.DTO;
using ProductMonitorShelf.Core.UseCase;
using System.Drawing;

namespace ProductMonitorShelf.Api.Controllers
{
    [ApiController]
    [Route("productShortage")]
    public class ProductShortageController : ControllerBase
    {
        // GET: api/ProductShortages
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

        // GET: api/ProductShortages
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

        // GET: api/ProductShortages
        /// <summary>
        /// zwraca wszystkie braki produktów z paginacją       
        /// </summary>
        [HttpGet("paginated")]
        public async Task<ActionResult<IEnumerable<ProductShortagesDto>>> GetAllWithPagination(
            [FromServices] GetAllWithPaginationProductShortageUseCase _getAllWithPaginationProductShortageUseCase,
            [FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var ProductShortage = await _getAllWithPaginationProductShortageUseCase.ExecuteAsync(pageNumber, pageSize);
            return Ok(ProductShortage);
        }

        // GET: api/ProductShortages/{id}
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


        // GET: api/ProductShortages/categories
        /// <summary>
        /// zwraca wszystkie kategorie      
        /// </summary>
        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<object>>> GetAllCategories(
            [FromServices] GetAllCategoriesUseCase _getAllCategoriesUseCase)
        {
            var categories = await _getAllCategoriesUseCase.ExecuteAsync();
            return Ok(categories);
        }

        // DELETE: api/ProductShortages/{id}
        /// <summary>
        /// Usuwa brak produktu po ID     
        /// </summary>
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