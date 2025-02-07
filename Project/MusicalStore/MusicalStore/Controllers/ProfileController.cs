using Microsoft.AspNetCore.Mvc;
using MusicalStore.Repository.OrderDetailRepository;
using MusicalStore.Repository.OrderRespository;

namespace MusicalStore.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IOrderRespository _orderRepository;
        public ProfileController(IOrderDetailRepository orderDetailRepository, IOrderRespository orderRespository)
        {
            _orderDetailRepository = orderDetailRepository;
            _orderRepository = orderRespository;
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
            ViewData["ListStatus"] = _orderRepository.GetAllStatus();
            return PartialView("_PurchaseHistory", listModel);
        }

        [HttpGet]
        public IActionResult GetListOrderByStatus(int statusId)
        {
            string customerId = HttpContext.Session.GetString("UserId")!;
            var orders = _orderDetailRepository.GetOrderDetailByStatus(customerId, statusId);
            return PartialView("_ListOrder",orders);
        }

        [HttpGet]
        public IActionResult GetAllOrder()
        {
            string customerId = HttpContext.Session.GetString("UserId")!;
            var orders = _orderDetailRepository.GetAllOrderDetail(customerId);
            return PartialView("_ListOrder", orders);
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
