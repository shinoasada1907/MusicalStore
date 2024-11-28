using System.Diagnostics;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using MusicalStore.Data;
using MusicalStore.Models;

namespace MusicalStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int page = 1)
        {
            int pageSize = 5;
            dynamic dataIndex = new ExpandoObject();
            dataIndex.Categories = CategoryData.Categories;
            dataIndex.ProductsSale = ProductData.ProductsSale;
            dataIndex.Collections = CollectionsData.ListCollections;
            dataIndex.ListProduct = ProductData.ListProduct;
            dataIndex.CurrentPage = page;
            dataIndex.TotalPages = 10;
            return View(dataIndex);
        }

        public IActionResult ProductDetail(int productId)
        {
            return View();
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
    }
}
