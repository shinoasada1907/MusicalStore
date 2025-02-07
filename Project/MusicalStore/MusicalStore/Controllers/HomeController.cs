using System.Diagnostics;
using System.Dynamic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicalStore.Data;
using MusicalStore.Function;
using MusicalStore.Models;
using MusicalStore.Repository.CategoryRespository;
using MusicalStore.Repository.ProductRepo;
using MusicalStore.Repository.ShoppingCartRepo;

namespace MusicalStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository, IShoppingCartRepository shoppingCartRepository, ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Index(int page = 1, int pageSize = 12)
        {
            var totalPage = _productRepository.GetAllProducts().Count() / 12;
            dynamic dataIndex = new ExpandoObject();
            dataIndex.Categories = _categoryRepository.GetCategorys();
            dataIndex.ProductsSale = _productRepository.GetTopSellingProducts();
            dataIndex.Collections = CollectionsData.ListCollections;
            dataIndex.News = NewsData.listNews;
            dataIndex.ListProduct = _productRepository.GetListProductWithPage(page, pageSize);
            dataIndex.CurrentPage = page;
            dataIndex.TotalPages = (totalPage is int) ? totalPage + 1 : totalPage;
            return View(dataIndex);
        }

        [HttpGet]
        public IActionResult ProductDetail(string productId)
        {
            var product = _productRepository.GetProductById(productId);
            Console.WriteLine(product.ProductCode + " " + product.ProductName + " " + product.DetailVoucher.StartDate + " " + product.ProductDetail.Introduction);
            //return View(product);
            dynamic dataProduct = new ExpandoObject();
            dataProduct.ProductDetail = product;
            dataProduct.ListRelatedProduct = _productRepository.GetListProductByCategory(product.CategoryCode)
                                                                .OrderByDescending(p => p.StockQuantity)
                                                                .Take(4)
                                                                .ToList();

            //Console.WriteLine(product.ProductCode + " " + product.ProductName + " " + product.DetailVoucher.StartDate + " " + product.ProductDetail.Introduction);
            return View(dataProduct);
        }
        public IActionResult ListCollectionProduct(string categoryName, int page = 1, int pageSize = 12)
        {
            ViewData["Collection"] = categoryName;
            ViewData["CategoryName"] = categoryName;
            //var collection = _productRepository.GetListCollectionProduct(categoryName, page, pageSize);
            var totalPage = _productRepository.GetListCollectionProduct(categoryName, page, pageSize).Count() / 12;
            dynamic dataIndex = new ExpandoObject();
            dataIndex.ListProduct = _productRepository.GetListCollectionProduct(categoryName, page, pageSize);
            dataIndex.CurrentPage = page;
            dataIndex.TotalPages = (totalPage is int) ? totalPage + 1 : totalPage;
            return View(dataIndex);
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
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                return RedirectToAction("Login", "Auth");
            }
            var shoppingCart = _shoppingCartRepository.GetShoppingCarts(HttpContext.Session.GetString("UserId")) ?? new List<ShoppingCart>();
            return View(shoppingCart);
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

        public IActionResult ListProduct(string categoryId, int page = 1, int pageSize = 12)
        {
            var categoryName = _categoryRepository.GetCategoryNameById(categoryId);
            ViewData["categoryId"] = categoryId;
            ViewData["CategoryName"] = categoryName;
            var totalPage = _productRepository.GetListProductByCategoryWithPage(categoryId, page, pageSize).Count() / 12;
            dynamic dataIndex = new ExpandoObject();
            dataIndex.ListProduct = _productRepository.GetListProductByCategoryWithPage(categoryId, page, pageSize);
            dataIndex.CurrentPage = page;
            dataIndex.TotalPages = (totalPage is int) ? totalPage + 1 : totalPage;
            return View(dataIndex);
        }

        [HttpPost]
        public async Task<IActionResult> AddShoppingCart(string productId)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                return RedirectToAction("Login", "Auth");
            }
            var product = _productRepository.GetProductById(productId);
            ShoppingCart sCart = new ShoppingCart();
            sCart.CartId = FunctionApplication.GenerateId(5);
            sCart.CustomerId = HttpContext.Session.GetString("UserId")!;
            sCart.ProductId = productId;
            sCart.Quantity = 1;
            sCart.Price = product.Price ?? 0;
            var cart = await _shoppingCartRepository.AddShoppingCart(sCart);
            return Json(cart);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteShoppingCart([FromBody] List<string> listId)
        {
            string customerId = HttpContext.Session.GetString("UserId")!;
            var carts = await _shoppingCartRepository.DeleteShoppingCart(customerId, listId);
            return PartialView("_ListProductShoppingCart", carts);
        }

        [HttpGet]
        public IActionResult PaymentProduct(string productId)
        {
            TempData["ProductId"] = productId;

            return RedirectToAction("Order", "Payment");
        }

        // Action để lấy danh sách sản phẩm cùng danh mục
        public ActionResult RelatedProducts(string category)
        {
            var relatedProducts = _productRepository.GetListProductByCategory(category);
            return PartialView("_RelatedProducts", relatedProducts);
        }

        [HttpGet]
        public IActionResult CheckQuantity(string productId, string quantity)
        {
            return Json(new
            {
                check = _productRepository.CheckQuantityProduct(productId, Convert.ToInt32(quantity))
            });
        }
    }
}
