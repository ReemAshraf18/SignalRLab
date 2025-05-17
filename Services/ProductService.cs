using Models;
using Repos;
using System.Threading.Tasks;
namespace Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepo;
        public ProductService(ProductRepository productRepo)
        {
            _productRepo = productRepo;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepo.GetAllProductsAsync();
        }
        public async Task <Product> GetProductById(int id)
        {
            return await _productRepo.GetProductByIdAsync(id);
        }
        public async Task AddCommentAsync(int productId, string username, string content)
        {
            var comment = new Comment
            {
                ProductId = productId,
                UserName = username,
                Content = content,
            };
            await _productRepo.AddCommentAsync(comment);
        }
        public async Task AddProduct(Product p)
        {
            await _productRepo.AddProduct(p);
        }
        public async Task DeleteProduct(int id)
        {
            await _productRepo.DeleteProduct(id);
        }
        public async Task UpdateProduct(Product product)
        {
            await _productRepo.UpdateProduct(product);
        }


    }
}
