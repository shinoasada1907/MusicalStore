using Microsoft.AspNetCore.Mvc;
using MusicalStore.Data;
using MusicalStore.Repository.ProductRepo;
using MusicalStore.Repository.StaffRepository;
using MusicalStore.Repository.UserRepository;
using MusicalStore.Repository.OrderRespository;
using MusicalStore.Repository.PaymentRespository;
using MusicalStore.Repository.ChucVuRepository;
using MusicalStore.Models;
using MusicalStore.Repository.CategoryRespository;
using NuGet.Protocol;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis;
using MusicalStore.Function;

namespace MusicalStore.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IOrderRespository _orderRespository;
        private readonly IPaymentRespository _paymentResporsitory;
        private readonly IPositionRepository _positionRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(IPaymentRespository paymentResporsitory,
            IUserRepository userRepository,
            IProductRepository productRepository,
            IStaffRepository staffRepository,
            IOrderRespository orderRespository,
            IPositionRepository positionRepository,
            ICategoryRepository categoryRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
            _staffRepository = staffRepository;
            _orderRespository = orderRespository;
            _paymentResporsitory = paymentResporsitory;
            _positionRepository = positionRepository;
            _categoryRepository = categoryRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult AdminOrder()
        {
            var oders = _orderRespository.GetAllOrder();
            return View(oders);
        }

        public IActionResult AdminStaff()
        {
            var staffs = _staffRepository.GetAllStaff();
            ViewData["Position"] = _positionRepository.GetPositions();
            return View(staffs);
        }
        public IActionResult AdminUser()
        {
            var users = _userRepository.GetAllUser();
            return View(users);
        }
        public IActionResult AdminProduct()
        {
            var products = _productRepository.GetAllProducts();
            ViewData["Category"] = _categoryRepository.GetCategorys();
            return View(products);
        }
        public IActionResult AdminPayment()
        {
            var payments = _paymentResporsitory.GetAllPayment();
            return View(payments);
        }
        public IActionResult AdminRevenue()
        {
            return View();
        }

        public IActionResult AdminAccount()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetProductById(string productId)
        {
            var product = _productRepository.GetProductById(productId);
            return Json(product);
        }
        [HttpGet]
        public IActionResult GetStaffById(string staffId)
        {
            var staff = _staffRepository.GetStaffById(staffId);
            return Json(staff);
        }

        [HttpPost]
        public async Task<IActionResult> AddStaff(Staff staff)
        {
            Console.WriteLine(staff.StaffId);
            var liststaff = await _staffRepository.AddNewStaff(staff);
            ViewData["Position"] = _positionRepository.GetPositions();
            return PartialView("_TableStaff", liststaff);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStaff(Staff staff)
        {
            Console.WriteLine(staff.StaffId);
            var liststaff = await _staffRepository.UpdateStaff(staff);
            ViewData["Position"] = _positionRepository.GetPositions();
            return PartialView("_TableStaff", liststaff);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteStaff(string staffId)
        {
            var liststaff = await _staffRepository.DeleteStaff(staffId);
            ViewData["Position"] = _positionRepository.GetPositions();
            return PartialView("_TableStaff", liststaff);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var listproduct = await _productRepository.AddNewProduct(product);
            ViewData["Category"] = _categoryRepository.GetCategorys();
            return PartialView("_TableProduct", listproduct);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            Console.WriteLine(product.ProductCode);
            var listproduct = await _productRepository.UpdateProduct(product);
            ViewData["Category"] = _categoryRepository.GetCategorys();
            return PartialView("_TableProduct", listproduct);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(string productId)
        {
            var listproduct = await _productRepository.DeleteProduct(productId);
            ViewData["Category"] = _categoryRepository.GetCategorys();
            return PartialView("_TableProduct", listproduct);
        }
        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
        {
            //if (file == null || file.Length == 0)
            //{
            //    return BadRequest("File is empty");
            //}

            //var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            //if (!Directory.Exists(uploadsFolder))
            //{
            //    Directory.CreateDirectory(uploadsFolder);
            //}

            //var fileName = Path.GetFileNameWithoutExtension(file.FileName);
            //var fileExtension = Path.GetExtension(file.FileName);
            //var filePath = Path.Combine(uploadsFolder, file.FileName);
            //int counter = 1;

            //// Kiểm tra và tạo tên tệp mới nếu tệp đã tồn tại
            //while (System.IO.File.Exists(filePath))
            //{
            //    filePath = Path.Combine(uploadsFolder, $"{fileName}_{counter}{fileExtension}");
            //    counter++;
            //}

            //// Lưu tệp tin
            //using (var stream = new FileStream(filePath, FileMode.Create))
            //{
            //    await file.CopyToAsync(stream);
            //}

            FunctionApplication func = new FunctionApplication(_webHostEnvironment);
            string filelName = await func.UploadImage(file);

            // Trả về tên tệp đã được lưu
            return Ok(new { FilePath = filelName });
        }

        //Payment
        [HttpGet]
        public IActionResult GetPaymentById(string paymentId)
        {
            var payment = _paymentResporsitory.GetPaymentById(paymentId);
            return Json(payment);
        }

        [HttpPost]
        public async Task<IActionResult> AddPayment(Payment payment)
        {
            Console.WriteLine(payment.PaymentMethodId);
            var listPayments = await _paymentResporsitory.AddNewPayment(payment);
            return PartialView("_TablePayment", listPayments);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePayment(Payment payment)
        {
            Console.WriteLine(payment.PaymentMethodId);
            var listPayments = await _paymentResporsitory.UpdatePayment(payment);
            return PartialView("_TablePayment", listPayments);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePayment(string paymentId)
        {
            var listPayments = await _paymentResporsitory.DeletePayment(paymentId);
            return PartialView("_TablePayment", listPayments);
        }

    }

}
