using System.Diagnostics;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using MusicalStore.Data;
using MusicalStore.Models;
using MusicalStore.Repository.ProductRepo;

namespace MusicalStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
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
        {
            var product = _productRepository.GetProductById(productId);
            Console.WriteLine(product.ProductCode + " " + product.ProductName);
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
        public IActionResult ShoppingCart()
        {
            return View();
        }
        public IActionResult FormUserInformation()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
    }
}
