
using ProductCategory.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategory.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync(int pageNumber, int pageSize);
        Task<Product?> GetByIdAsync(Guid id);
        Task<int> GetTotalCountAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
        Task<bool> CategoryExists(Guid categoryId);
    }

}
