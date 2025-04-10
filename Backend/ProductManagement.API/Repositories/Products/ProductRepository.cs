using Microsoft.EntityFrameworkCore;
using ProductManagement.API.Data;
using ProductManagement.API.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.API.Repositories.Products;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<Product> CreateAsync(Product product)
    {
        product.CreatedAt = DateTime.UtcNow;
        product.UpdatedAt = DateTime.UtcNow;

        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        
        return product;
    }

    public async Task<Product?> UpdateAsync(Product product)
    {
        var existingProduct = await _context.Products.FindAsync(product.Id);
        
        if (existingProduct == null)
            return null;

        // Actualizar propiedades
        existingProduct.Name = product.Name;
        existingProduct.Description = product.Description;
        existingProduct.Price = product.Price;
        existingProduct.Stock = product.Stock;
        existingProduct.Category = product.Category;
        existingProduct.ImageUrl = product.ImageUrl;
        existingProduct.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        
        return existingProduct;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        
        if (product == null)
            return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        
        return true;
    }

    public async Task<IEnumerable<Product>> GetByCategoryAsync(string category)
    {
        return await _context.Products
            .Where(p => p.Category.ToLower() == category.ToLower())
            .ToListAsync();
    }
} 