using Microsoft.AspNetCore.Mvc;

namespace MusicalStore.Controllers.Admin
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
    }
}
