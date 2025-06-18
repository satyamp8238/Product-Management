using Microsoft.AspNetCore.Mvc;
using ProductCategory.Domain.Model;
using ProductCategory.Domain.Repositories;
using ProductCategory.UI.Models;
using ProductCategory.UI.Services;

namespace ProductCategory.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> CategoryList()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.Categories = await _categoryService.GetAllAsync();
            return View(categoryViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEditCategory([FromBody] Models.Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid input.");

            bool result = await _categoryService.AddOrEditAsync(category);

            if (result)
                return Ok(new { status = category.CategoryId == Guid.Empty ? "added" : "updated" });
            else
                return StatusCode(500, "Something went wrong.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if (result.Status)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

    }
}