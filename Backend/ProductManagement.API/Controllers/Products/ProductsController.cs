using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.API.DTOs.Products;
using ProductManagement.API.Services.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagement.API.Controllers.Products;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // GET: api/products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }

    // GET: api/products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDTO>> GetProductById(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        
        if (product == null)
            return NotFound();
            
        return Ok(product);
    }

    // POST: api/products
    [HttpPost]
    public async Task<ActionResult<ProductDTO>> CreateProduct(CreateProductDTO createProductDto)
    {
        var createdProduct = await _productService.CreateProductAsync(createProductDto);
        
        return CreatedAtAction(
            nameof(GetProductById),
            new { id = createdProduct.Id },
            createdProduct);
    }

    // PUT: api/products/5
    [HttpPut("{id}")]
    public async Task<ActionResult<ProductDTO>> UpdateProduct(int id, UpdateProductDTO updateProductDto)
    {
        var updatedProduct = await _productService.UpdateProductAsync(id, updateProductDto);
        
        if (updatedProduct == null)
            return NotFound();
            
        return Ok(updatedProduct);
    }

    // DELETE: api/products/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var result = await _productService.DeleteProductAsync(id);
        
        if (!result)
            return NotFound();
            
        return NoContent();
    }

    // GET: api/products/category/electronics
    [HttpGet("category/{category}")]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsByCategory(string category)
    {
        var products = await _productService.GetProductsByCategoryAsync(category);
        return Ok(products);
    }
} 