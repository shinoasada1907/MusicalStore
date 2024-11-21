using Microsoft.AspNetCore.Mvc;

namespace MusicalStore.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult AdminOrder()
        {
            return View();
        }

        public IActionResult AdminStaff()
        {
            return View();
        }
        public IActionResult AdminUser()
        {
            return View();
        }
        public IActionResult AdminProduct()
        {
            return View();
        }
        public IActionResult AdminPayment()
        {
            return View();
        }
        public IActionResult AdminRevenue()
        {
            return View();
        }
    }
}
