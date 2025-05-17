using ProductCatalog.Models;

namespace ProductCatalog.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddCommentAsync(Comment comment);
    }
}