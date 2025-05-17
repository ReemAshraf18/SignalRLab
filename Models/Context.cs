using Microsoft.EntityFrameworkCore;
using Models;

namespace Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies()
                .UseSqlServer("Server=REEM-ASHRAF;Database=TestShop;User Id = Reem Ashraf; Password =;Integrated security = True; Trusted_Connection=True;TrustserverCertificate = True; MultipleActiveResultSets=True");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Product)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.ProductId);

            modelBuilder.DataSeeding();
        }
    }
}