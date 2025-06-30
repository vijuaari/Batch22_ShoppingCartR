using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartR.Models;
using ShoppingCartR.Repository;

namespace ShoppingCartR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()

        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAllexpression(includeproperties: "Category,ProductImage");
            return View(productList);
        }

        public IActionResult Details (int productId)
        {
            ShoppingKart shoppingKart = new ShoppingKart()
            {
                Product = _unitOfWork.Product.Get(u => u.ProductId == productId, includeproperties: "Category,ProductImage"),
                Count = 1,
                ProductId = productId

            };
            return View(shoppingKart);
        }
        [HttpPost]
        public IActionResult Details(ShoppingKart shoppingKart)
        {

            var claimsIdentity =(ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var productFromDb = _unitOfWork.Product.Get(u => u.ProductId == shoppingKart.ProductId, includeproperties: "Category,ProductImage");
            shoppingKart.ApplicationUserId = userId;
            shoppingKart.Price = productFromDb.Price;
            _unitOfWork.Shoppingkart.Add(shoppingKart);
            _unitOfWork.Save();

            //ShoppingKart shoppingKart = new ShoppingKart()
            //{
            //    Product = _unitOfWork.Product.Get(u => u.ProductId == productId, includeproperties: "Category,ProductImage"),
            //    Count = 1,
            //    ProductId = productId

            //};
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
