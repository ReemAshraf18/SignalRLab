using Microsoft.EntityFrameworkCore;
using Products.Models;
namespace Products.Data
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Price = 1200.50,
                    Description = "High-performance laptop",
                    Quantity = 10,
                    ImageUrl = "https://example.com/laptop.jpg"
                },
                new Product
                {
                    Id = 2,
                    Name = "Smartphone",
                    Price = 800.75,
                    Description = "Latest smartphone model",
                    Quantity = 20,
                    ImageUrl = "https://example.com/smartphone.jpg"
                }
            );

            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    ProductId = 1,
                    UserName = "User1",
                    Content = "Great laptop!"
                },
                new Comment
                {
                    Id = 2,
                    ProductId = 1,
                    UserName = "User2",
                    Content = "Worth the price."
                }
            );
        }
    }
  
}
