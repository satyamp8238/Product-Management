using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCategory.Domain.Model;
using ProductCategory.UI.Models;
using ProductCategory.UI.Services;

public class ProductController : Controller
{
    private readonly ProductService _productService;
    private readonly CategoryService _categoryService;

    public ProductController(ProductService productService, CategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        var result = await _productService.GetAllAsync(page, pageSize);

        var viewModel = new ProductListViewModel
        {
            Products = result.Data,
            PageNumber = result.PageNumber,
            TotalPages = result.TotalPages,
            PageSize = pageSize,
            TotalCount = result.TotalCount
        };

        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var Categories = await _categoryService.GetAllAsync();
        return Json(Categories);
    }


    [HttpPost]
    public async Task<IActionResult> AddOrEditProduct([FromBody] ProductCategory.UI.Models.Product product)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid input");

        bool result = await _productService.AddOrEditAsync(product);

        if (result)
            return Ok(new { status = product.ProductId == Guid.Empty ? "added" : "updated" });
        else
            return StatusCode(500, "Something went wrong.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        var result = await _productService.DeleteAsync(id);

        if (result.Status)
            return Ok(new { status = true, message = result.Message }); 

        return BadRequest(new { status = false, message = result.Message }); 
    }

}
