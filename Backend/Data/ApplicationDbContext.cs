using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Datos iniciales para productos
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Laptop Dell XPS 13",
                    Description = "Laptop de alta gama con procesador Intel Core i7",
                    Price = 1299.99m,
                    Stock = 10,
                    Category = "Electrónica",
                    ImageUrl = "https://example.com/laptop.jpg",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Product
                {
                    Id = 2,
                    Name = "Monitor LG 27\"",
                    Description = "Monitor UltraHD con resolución 4K",
                    Price = 349.99m,
                    Stock = 15,
                    Category = "Electrónica",
                    ImageUrl = "https://example.com/monitor.jpg",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Product
                {
                    Id = 3,
                    Name = "Teclado Mecánico",
                    Description = "Teclado mecánico RGB con switches Cherry MX",
                    Price = 99.99m,
                    Stock = 20,
                    Category = "Accesorios",
                    ImageUrl = "https://example.com/teclado.jpg",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );
        }
    }
} 