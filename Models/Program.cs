using Microsoft.EntityFrameworkCore;
using Models;

class Program
{
    static async Task Main(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<Context>();
        optionsBuilder.UseSqlServer("Server=REEM-ASHRAF;Database=ProductsSignalR;Integrated Security=True;TrustServerCertificate=True");

        using var context = new Context(optionsBuilder.Options);
        await context.Database.MigrateAsync();

        Console.WriteLine("Database migrated successfully.");
    }
}