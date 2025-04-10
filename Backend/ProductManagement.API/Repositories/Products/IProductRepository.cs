using ProductManagement.API.Models.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagement.API.Repositories.Products;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<Product> CreateAsync(Product product);
    Task<Product?> UpdateAsync(Product product);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<Product>> GetByCategoryAsync(string category);
} 