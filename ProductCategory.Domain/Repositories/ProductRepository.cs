using Microsoft.EntityFrameworkCore;
using ProductCategory.Domain.Data;
using ProductCategory.Domain.Model;

namespace ProductCategory.Domain.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Products.Include(p => p.Category).Skip((pageNumber - 1) * pageSize).Take(pageSize).OrderByDescending(p => p.CreatedDate).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _context.Products.CountAsync();
        }

        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CategoryExists(Guid categoryId)
        {
            return await _context.Categories.AnyAsync(c => c.CategoryId == categoryId);
        }
    }
}
