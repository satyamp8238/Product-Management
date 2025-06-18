using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductCategory.Domain.Model
{
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
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
    }
    public class AddProduct
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
    }   
    
    public class UpdateProduct
    {
        public Guid? ProductId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
    }

}
