using Microsoft.AspNetCore.Mvc;
using MusicalStore.Data;
using MusicalStore.Repository.ProductRepo;
using MusicalStore.Repository.UserRepository;

namespace MusicalStore.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        public AdminController(IUserRepository userRepository, IProductRepository productRepository)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
        }
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
            var users = _userRepository.GetAllUser();
            return View(users);
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
