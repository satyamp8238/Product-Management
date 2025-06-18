using Microsoft.EntityFrameworkCore;
using ProductCategory.Domain.Data;
using ProductCategory.Domain.Model;

namespace ProductCategory.Domain.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            var existing = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == category.CategoryId);
            if (existing != null)
            {
                existing.Name = category.Name;
                existing.Description = category.Description;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsCategoryInUseAsync(Guid categoryId)
        {
            return await _context.Products.AnyAsync(p => p.CategoryId == categoryId);
        }
    }
}
