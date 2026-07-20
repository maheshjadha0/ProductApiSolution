using Application.DTOs.Product;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var product = await _productService.GetAllAsync();
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductRequestDto dto)
        {
            var product = await _productService.CreateAsync(dto);

            return CreatedAtAction(
                 nameof(GetById),
                 new { id = product.Id },
                 product);
        }
        [HttpPut("id:int")]

        public async Task<IActionResult> Update(int id , UpdateProductDto dto)
        {
            var updated = await _productService.UpdateAsync(id, dto);
            if (!updated) 
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("id:int")]
        public async Task<IActionResult> DeleteAsync(int id) 
        { 
            var deleted = await _productService.DeleteAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return Ok("deleted successfully!");
        }
    }
}
