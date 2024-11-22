using Microsoft.AspNetCore.Mvc;
using MusicalStore.Data;

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
            return View(StaffData.staffList);
        }
        public IActionResult AdminUser()
        {
            return View(UserData.ListUser);
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
