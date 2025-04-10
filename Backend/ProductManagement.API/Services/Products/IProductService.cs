using ProductManagement.API.DTOs.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagement.API.Services.Products;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
    Task<ProductDTO?> GetProductByIdAsync(int id);
    Task<ProductDTO> CreateProductAsync(CreateProductDTO createProductDto);
    Task<ProductDTO?> UpdateProductAsync(int id, UpdateProductDTO updateProductDto);
    Task<bool> DeleteProductAsync(int id);
    Task<IEnumerable<ProductDTO>> GetProductsByCategoryAsync(string category);
} 