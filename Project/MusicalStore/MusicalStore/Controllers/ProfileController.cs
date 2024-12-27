using Microsoft.AspNetCore.Mvc;
using MusicalStore.Repository.OrderDetailRepository;

namespace MusicalStore.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public ProfileController(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public IActionResult Profile()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                return RedirectToAction("Login", "Auth");
            }
            ViewData["IsProfile"] = true;
            return View();
        }
        public IActionResult PersonalInfo()
        {
            return PartialView("_PersonalInfo");
        }

        public IActionResult PurchaseHistory()
        {
            string customerId = HttpContext.Session.GetString("UserId")!;
            Console.WriteLine(customerId);
            var listModel = _orderDetailRepository.GetAllOrderDetail(customerId);
            return PartialView("_PurchaseHistory", listModel);
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
