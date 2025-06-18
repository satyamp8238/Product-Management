using Microsoft.AspNetCore.Mvc;
using ProductCategory.Domain.Model;
using ProductCategory.Domain.Repositories;

namespace ProductCategory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // Get all categories
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return Ok(categories);
        }

        // Get category by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                return NotFound("Category not found.");

            return Ok(category);
        }

        // 🔹 POST: Add Category
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Category category)
        {
            try
            {
                category.CategoryId = Guid.NewGuid();

                await _categoryRepository.AddAsync(category);
                return Ok(new { status = true, message = "Category added successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = false, message = ex.Message });
            }
        }

        // 🔹 PUT: Update Category
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Category category)
        {
            if (id != category.CategoryId)
                return BadRequest(new { status = false, message = "Category ID mismatch." });

            try
            {
                await _categoryRepository.UpdateAsync(category);
                return Ok(new { status = true, message = "Category updated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = false, message = ex.Message });
            }
        }

        // 🔹 DELETE: Delete Category
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var inUse = await _categoryRepository.IsCategoryInUseAsync(id);
            if (inUse)
                return BadRequest(new { status = false, message = "Category is in use and cannot be deleted." });

            var category = new Category { CategoryId = id }; // dummy instance to delete
            await _categoryRepository.DeleteAsync(category);
            return Ok(new { status = true, message = "Category deleted successfully." });
        }
    }
}
