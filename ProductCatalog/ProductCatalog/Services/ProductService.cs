using ProductCatalog.Models;
using ProductCatalog.Repositories;

namespace ProductCatalog.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _repository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _repository.GetProductByIdAsync(id);
        }

        public async Task AddCommentAsync(int productId, string username, string content)
        {
            var comment = new Comment
            {
                ProductId = productId,
                UserName = username,
                Content = content
            };
            await _repository.AddCommentAsync(comment);
        }
    }
}