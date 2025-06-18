using ProductCategory.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace ProductCategory.UI.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
    }

    public class Product
    {
        public Guid ProductId { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }

    }

    public class Category
    {
        public Guid CategoryId { get; set; }
        [Required] 
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
