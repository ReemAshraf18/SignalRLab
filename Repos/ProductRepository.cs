using Models;
using Microsoft.EntityFrameworkCore;

namespace Repos
{
    public class ProductRepository
    {
        private readonly DbContext _context;
        public ProductRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Set<Product>().ToListAsync();
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Set<Product>().Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddCommentAsync(Comment c)
        {
            _context.Set<Comment>().Add(c);
            await _context.SaveChangesAsync();
        }
        public async Task AddProduct(Product p)
        {
            _context.Add(p);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteProduct(int id)
        {
            var product = await _context.Set<Product>().FindAsync(id);
            if (product != null)
            {
                _context.Set<Product>().Remove(product);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateProduct(Product product)
        {
            _context.Set<Product>().Update(product);
            await _context.SaveChangesAsync();
        }

    }
}
