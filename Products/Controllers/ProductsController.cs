using Microsoft.AspNetCore.Mvc;
using Products.Data;
using Products.Models;
using Microsoft.EntityFrameworkCore;
using Products.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Products.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsContext _context;
        public ProductsController(ProductsContext context)
        {
            _context = context;
        }
        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }
        // GET: Products/Details/id?
        public async Task<IActionResult> Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var product = await _context.Products
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        // POST: Products/AddComment
        [HttpPost]
        public async Task <IActionResult> AddComment(int productId, string username, string content)
        {
            if(ModelState.IsValid)
            {
                var comment = new Comment
                {
                    Content = content,
                    UserName = username,
                    ProductId = productId
                };
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
                // Notify all clients about the new comment
                var hubContext = HttpContext.RequestServices.GetService<IHubContext<CommentHub>>();
                await hubContext.Clients.All.SendAsync("ReceiveComment", username, content, productId);
                return RedirectToAction("Details", new { id = productId });
            }
            return RedirectToAction("Details", new { id = productId });
        }

    }
}
