using Microsoft.EntityFrameworkCore;

namespace Models
{
    public static class DataSeed
    {
        public static void DataSeeding(this ModelBuilder modelBuilder)
        {
            SeedProducts(modelBuilder);
            SeedComments(modelBuilder);
        }

        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Price = 1200.50,
                    Description = "High-performance laptop",
                    Quantity = 10,
                    ImageUrl = "https://image.made-in-china.com/202f0j00QlWgerOzYFpL/Intel-Core-I7-6700hq-Laptop-Notebook-IPS-DDR4-256GB-SSD-8GB-15-6-Professional-for-Students-Office-Computer-Labtop-Laptop.webp",
                },
                new Product
                {
                    Id = 2,
                    Name = "Smartphone",
                    Price = 800.75,
                    Description = "Latest smartphone model",
                    Quantity = 20,
                    ImageUrl = "https://www.01net.com/app/uploads/2025/02/meilleur-smartphone-moins-300-euros-Xiaomi-Redmi-Note-14-Pro-4G.jpg",
                },
                new Product
                {
                    Id = 3,
                    Name = "Chocolate",
                    Price = 5.99,
                    Description = "Delicious milk chocolate",
                    Quantity = 50,
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSfH3zZOKzb5uHUbMs02zQxFuUUdGYHTW4CpA&s",
                }
            );
        }

        public static void SeedComments(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    ProductId = 1,
                    UserName = "User1",
                    Content = "Great laptop!",
                },
                new Comment
                {
                    Id = 2,
                    ProductId = 1,
                    UserName = "User2",
                    Content = "Worth the price.",
                },
                new Comment
                {
                    Id = 3,
                    ProductId = 2,
                    UserName = "User3",
                    Content = "Excellent camera quality",
                }
            );
        }
    }
}