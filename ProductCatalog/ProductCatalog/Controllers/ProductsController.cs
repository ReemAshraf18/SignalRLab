using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Models;
using ProductCatalog.Services;
using ProductCatalog.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace ProductCatalog.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _service.GetAllProductsAsync();
            return View(products);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _service.GetProductByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(int productId, string username, string content)
        {
            if (ModelState.IsValid)
            {
                await _service.AddCommentAsync(productId, username, content);

                var hubContext = HttpContext.RequestServices.GetService<IHubContext<CommentHub>>();
                await hubContext.Clients.All.SendAsync("ReceiveComment", productId, username, content);

                return RedirectToAction(nameof(Details), new { id = productId });
            }
            return RedirectToAction(nameof(Details), new { id = productId });
        }
    }
}