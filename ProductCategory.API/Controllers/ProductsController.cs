using Microsoft.AspNetCore.Mvc;
using ProductCategory.Domain.Model;
using ProductCategory.Domain.Repositories;

namespace ProductCategory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var totalCount = await _productRepository.GetTotalCountAsync();
            var products = await _productRepository.GetAllAsync(pageNumber, pageSize);

            return Ok(new
            {
                Data = products,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProduct dto)
        {
            if (!await _productRepository.CategoryExists(dto.CategoryId))
                return BadRequest(new { status = false, message = "Invalid CategoryId." });

            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                CategoryId = dto.CategoryId,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };

            await _productRepository.AddAsync(product);
            return Ok(new { status = true, message = "Product added successfully." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProduct dto)
        {
            if (id != dto.ProductId)
                return BadRequest(new { status = false, message = "Product ID mismatch." });

            var existing = await _productRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound(new { status = false, message = "Product not found." });

            if (!await _productRepository.CategoryExists(dto.CategoryId))
                return BadRequest(new { status = false, message = "Invalid CategoryId." });

            // Update the existing product
            existing.Name = dto.Name;
            existing.Description = dto.Description;
            existing.Price = dto.Price;
            existing.CategoryId = dto.CategoryId;
            existing.ModifiedDate = DateTime.UtcNow;

            await _productRepository.UpdateAsync(existing);

            return Ok(new { status = true, message = "Product updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound(new { status = false, message = "Product not found." });

            await _productRepository.DeleteAsync(product);

            return Ok(new { status = true, message = "Product deleted successfully." });
        }

    }
}
