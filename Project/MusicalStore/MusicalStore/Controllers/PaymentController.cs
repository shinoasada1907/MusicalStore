using Microsoft.AspNetCore.Mvc;
using MusicalStore.Function;
using MusicalStore.Models;
using MusicalStore.Models.Service.Vnpay;
using MusicalStore.Repository.Momo;
using MusicalStore.Repository.ProductRepo;
using MusicalStore.Repository.UserRepository;
using MusicalStore.Repository.vnpay;
using Newtonsoft.Json;

namespace MusicalStore.Controllers
{
    public class PaymentController : Controller
    {
        private IMomoService _momoService;
        private readonly IVnPayService _vnPayService;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        public PaymentController(IMomoService momoService, IVnPayService vnPayService, IUserRepository userRepository, IProductRepository productRepository)
        {
            _momoService = momoService;
            _vnPayService = vnPayService;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult Order(string productId)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                return RedirectToAction("Login", "Auth");
            }
            var product = _productRepository.GetProductById(productId);
            Console.WriteLine(product.ProductCode + " - " + product.ProductName);
            HttpContext.Session.SetString("OrderId", FunctionApplication.GenerateId(9));
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaymentMomo(OrderModel model)
        {
            var respose = await _momoService.CreatePaymentAsync(model);
            Console.WriteLine(JsonConvert.SerializeObject(respose, Formatting.Indented));
            return Redirect(respose.PayUrl);
        }

        [HttpGet]
        public IActionResult PaymentCallBackMomo()
        {
            var response = _momoService.PaymentExecuteAsync(HttpContext.Request.Query);
            Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));

            return Json(JsonConvert.SerializeObject(response, Formatting.Indented));
        }
        [HttpPost]
        public IActionResult CreatePaymentUrlVnpay(PaymentInformationModel model)
        {
            model.OrderType = "other";
            var url = _vnPayService.CreatePaymentUrl(model, HttpContext);

            return Redirect(url);
        }
        [HttpGet]
        public IActionResult PaymentCallbackVnpay()
        {
            var response = _vnPayService.PaymentExecute(Request.Query);

            return Json(response);
        }
        public IActionResult PaymentCallBack()
        {
            return View();
        }
    }
}
