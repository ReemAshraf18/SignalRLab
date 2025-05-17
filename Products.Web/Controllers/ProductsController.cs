using Models;
using Repos;
using Services;
using Products.Web.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Products.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService productService;
        private readonly IHubContext<ProductHub> _productHub;

        public ProductsController(ProductService productService, IHubContext<ProductHub> productHub)
        {
            this.productService = productService;
            this._productHub = productHub;
        }
        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetAllProducts();
            return View(products);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await productService.GetProductById(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/AddComment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(int productId, string username, string content)
        {
            if (ModelState.IsValid)
            {
                await productService.AddCommentAsync(productId, username, content);

                // Send notification via SignalR
                var hubContext = HttpContext.RequestServices.GetService<IHubContext<CommentHub>>();
                await hubContext.Clients.All.SendAsync("ReceiveComment", productId, username, content);

                return RedirectToAction(nameof(Details), new { id = productId });
            }
            return RedirectToAction(nameof(Details), new { id = productId });
        }
        public IActionResult AddProduct()
        {
            return View();
        }

        // POST: Products/AddProduct
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                await productService.AddProduct(product);

                await _productHub.Clients.All.SendAsync("ProductAdded", product);

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/UpdateProduct/5
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var product = await productService.GetProductById(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST: Products/UpdateProduct
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                await productService.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }
        // GET: Products/DeleteProduct/5
        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await productService.GetProductById(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST: Products/DeleteConfirmed
        [HttpPost, ActionName("DeleteConfirmed")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await productService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }
    }
}


