using System;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.API.DTOs.Products;

// DTO para devolver productos
public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Category { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

// DTO para crear productos
public class CreateProductDTO
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int Stock { get; set; }

    [StringLength(50)]
    public string Category { get; set; } = string.Empty;

    [StringLength(255)]
    public string? ImageUrl { get; set; }
}

// DTO para actualizar productos
public class UpdateProductDTO
{
    [StringLength(100)]
    public string? Name { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal? Price { get; set; }

    [Range(0, int.MaxValue)]
    public int? Stock { get; set; }

    [StringLength(50)]
    public string? Category { get; set; }

    [StringLength(255)]
    public string? ImageUrl { get; set; }
} 