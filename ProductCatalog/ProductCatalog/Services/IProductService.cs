using ProductCatalog.Models;

namespace ProductCatalog.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddCommentAsync(int productId, string username, string content);
    }
}