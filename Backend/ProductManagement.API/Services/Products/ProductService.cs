using ProductManagement.API.DTOs.Products;
using ProductManagement.API.Models.Products;
using ProductManagement.API.Repositories.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.API.Services.Products;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return products.Select(MapToDTO);
    }

    public async Task<ProductDTO?> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return product != null ? MapToDTO(product) : null;
    }

    public async Task<ProductDTO> CreateProductAsync(CreateProductDTO createProductDto)
    {
        var product = new Product
        {
            Name = createProductDto.Name,
            Description = createProductDto.Description,
            Price = createProductDto.Price,
            Stock = createProductDto.Stock,
            Category = createProductDto.Category,
            ImageUrl = createProductDto.ImageUrl
        };

        var createdProduct = await _productRepository.CreateAsync(product);
        return MapToDTO(createdProduct);
    }

    public async Task<ProductDTO?> UpdateProductAsync(int id, UpdateProductDTO updateProductDto)
    {
        var existingProduct = await _productRepository.GetByIdAsync(id);
        
        if (existingProduct == null)
            return null;

        // Actualizar solo los campos proporcionados
        if (updateProductDto.Name != null)
            existingProduct.Name = updateProductDto.Name;
            
        if (updateProductDto.Description != null)
            existingProduct.Description = updateProductDto.Description;
            
        if (updateProductDto.Price.HasValue)
            existingProduct.Price = updateProductDto.Price.Value;
            
        if (updateProductDto.Stock.HasValue)
            existingProduct.Stock = updateProductDto.Stock.Value;
            
        if (updateProductDto.Category != null)
            existingProduct.Category = updateProductDto.Category;
            
        if (updateProductDto.ImageUrl != null)
            existingProduct.ImageUrl = updateProductDto.ImageUrl;

        var updatedProduct = await _productRepository.UpdateAsync(existingProduct);
        return updatedProduct != null ? MapToDTO(updatedProduct) : null;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        return await _productRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<ProductDTO>> GetProductsByCategoryAsync(string category)
    {
        var products = await _productRepository.GetByCategoryAsync(category);
        return products.Select(MapToDTO);
    }

    // Método privado para convertir de Entidad a DTO
    private static ProductDTO MapToDTO(Product product)
    {
        return new ProductDTO
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            Category = product.Category,
            ImageUrl = product.ImageUrl,
            CreatedAt = product.CreatedAt,
            UpdatedAt = product.UpdatedAt
        };
    }
} 