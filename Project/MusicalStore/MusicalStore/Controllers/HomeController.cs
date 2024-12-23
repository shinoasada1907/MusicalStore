using System.Diagnostics;
using System.Dynamic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicalStore.Data;
using MusicalStore.Function;
using MusicalStore.Models;
using MusicalStore.Repository.ProductRepo;
using MusicalStore.Repository.ShoppingCartRepo;

namespace MusicalStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository, IShoppingCartRepository shoppingCartRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        [HttpGet]
        public IActionResult Index(int page = 1, int pageSize = 12)
        {
            var totalPage = _productRepository.GetAllProducts().Count() / 12;
            dynamic dataIndex = new ExpandoObject();
            dataIndex.Categories = CategoryData.Categories;
            dataIndex.ProductsSale = ProductData.ProductsSale;
            dataIndex.Collections = CollectionsData.ListCollections;
            dataIndex.ListProduct = _productRepository.GetListProductWithPage(page, pageSize);
            dataIndex.CurrentPage = page;
            dataIndex.TotalPages = (totalPage is int) ? totalPage + 1 : totalPage;
            return View(dataIndex);
        }

        [HttpGet]
        public IActionResult ProductDetail(string productId)
        {            var product = _productRepository.GetProductById(productId);
            Console.WriteLine(product.ProductCode + " " + product.ProductName + " " + product.DetailVoucher.StartDate + " " + product.ProductDetail.Introduction);
            return View(product);
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

        public IActionResult ProfileUser()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ShoppingCart()
        {
            if(string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                return RedirectToAction("Login", "Auth");
            }
            var shoppingCart = _shoppingCartRepository.GetShoppingCarts(HttpContext.Session.GetString("UserId")) ?? new List<ShoppingCart>();
            return View();
        }
        public IActionResult FormUserInformation()
        {
            return View();
        }
        public IActionResult Profile()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                return RedirectToAction("Login", "Auth");
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddShoppingCart(string productId)
        {
            var product = _productRepository.GetProductById(productId);
            ShoppingCart sCart = new ShoppingCart();
            sCart.CartId = FunctionApplication.GenerateId(5);
            sCart.CustomerId = HttpContext.Session.GetString("UserId");
            sCart.ProductId = productId;
            sCart.Quantity = 1;
            sCart.Price = product.Price ?? 0;
            var cart = _shoppingCartRepository.AddShoppingCart(sCart);
            return Json(cart);
        }

        [HttpGet]
        public IActionResult PaymentProduct(string productId)
        {
            TempData["ProductId"] = productId;
            return RedirectToAction("Order", "Payment");
        }
    }
}
