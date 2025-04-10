using Microsoft.EntityFrameworkCore;
using ProductManagement.API.Models.Products;

namespace ProductManagement.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Productos
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración de Productos
        modelBuilder.Entity<Product>()
            .HasKey(p => p.Id);
        
        modelBuilder.Entity<Product>()
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        modelBuilder.Entity<Product>()
            .Property(p => p.Description)
            .HasMaxLength(500);
        
        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)");
        
        modelBuilder.Entity<Product>()
            .Property(p => p.Stock)
            .IsRequired();
    }
}