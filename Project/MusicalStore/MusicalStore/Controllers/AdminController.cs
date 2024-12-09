using Microsoft.AspNetCore.Mvc;
using MusicalStore.Data;
using MusicalStore.Repository.ProductRepo;
using MusicalStore.Repository.StaffRepository;
using MusicalStore.Repository.UserRepository;

namespace MusicalStore.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IStaffRepository _staffRepository;
        public AdminController(IUserRepository userRepository, IProductRepository productRepository, IStaffRepository staffRepository)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
            _staffRepository = staffRepository;
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
            var staffs = _staffRepository.GetAllStaff();
            return View(staffs);
        }
        public IActionResult AdminUser()
        {
            var users = _userRepository.GetAllUser();
            return View(users);
        }
        public IActionResult AdminProduct()
        {
            var products= _productRepository.GetAllProducts();
            return View(products);
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
