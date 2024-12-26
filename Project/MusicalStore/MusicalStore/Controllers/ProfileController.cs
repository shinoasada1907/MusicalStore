using Microsoft.AspNetCore.Mvc;

namespace MusicalStore.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult PersonalInfo()
        {
            return PartialView("_PersonalInfo");
        }

        public IActionResult PurchaseHistory()
        {
            return PartialView("_PurchaseHistory");
        }

        public IActionResult Favorites()
        {
            return PartialView("_Favorites");
        }

        public IActionResult Notifications()
        {
            return PartialView("_Notifications");
        }
    }
}
