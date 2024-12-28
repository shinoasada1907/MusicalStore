using Microsoft.AspNetCore.Mvc;
using MusicalStore.Function;
using MusicalStore.Mapping;
using MusicalStore.Models;
using MusicalStore.Models.Service;
using MusicalStore.Models.Service.Vnpay;
using MusicalStore.Repository.Momo;
using MusicalStore.Repository.OrderDetailRepository;
using MusicalStore.Repository.OrderRespository;
using MusicalStore.Repository.PaymentRespository;
using MusicalStore.Repository.ProductRepo;
using MusicalStore.Repository.ShoppingCartRepo;
using MusicalStore.Repository.UserRepository;
using MusicalStore.Repository.vnpay;
using MusicalStore.Services;
using Newtonsoft.Json;
using System.Dynamic;

namespace MusicalStore.Controllers
{
    public class PaymentController : Controller
    {
        private IMomoService _momoService;
        private readonly IVnPayService _vnPayService;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPaymentRespository _paymentRespository;
        private readonly IOrderRespository _orderRespository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IEmailService _emailService;
        private readonly IInvoiceEmailService _invoiceEmailService;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        public PaymentController(IMomoService momoService, 
            IVnPayService vnPayService, 
            IUserRepository userRepository, 
            IProductRepository productRepository, 
            IPaymentRespository paymentRespository,
            IOrderRespository orderRespository,
            IOrderDetailRepository orderDetailRepository,
            IEmailService emailService,
            IInvoiceEmailService invoiceEmailService,
            IShoppingCartRepository shoppingCartRepository)
        {
            _momoService = momoService;
            _vnPayService = vnPayService;
            _userRepository = userRepository;
            _productRepository = productRepository;
            _paymentRespository = paymentRespository;
            _orderRespository = orderRespository;
            _orderDetailRepository = orderDetailRepository;
            _emailService = emailService;
            _invoiceEmailService = invoiceEmailService;
            _shoppingCartRepository = shoppingCartRepository;
        }
        [HttpPost]
        public IActionResult SendRequestOrder([FromBody] List<OrderDetail> orderDetails)
        {
            // Kiểm tra đăng nhập
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                return RedirectToAction("Login", "Auth");
            }

            // Lưu OrderDetails vào Session hoặc xử lý theo nhu cầu
            HttpContext.Session.SetString("OrderId", FunctionApplication.GenerateId(9));

            foreach (var item in orderDetails)
            {
                var product = _productRepository.GetProductById(item.ProductId);
                item.Product = product;
                item.OrderId = HttpContext.Session.GetString("OrderId")!;
            }

            HttpContext.Session.SetString("OrderDetails", Newtonsoft.Json.JsonConvert.SerializeObject(orderDetails));

            // Chuyển đến trang Order
            return RedirectToAction("Order");
        }
        [HttpGet]
        public IActionResult Order()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                return RedirectToAction("Login", "Auth");
            }
            // Lấy dữ liệu từ Session nếu cần
            var orderDetailsJson = HttpContext.Session.GetString("OrderDetails");
            var orderDetails = string.IsNullOrEmpty(orderDetailsJson)
                ? new List<OrderDetail>()
                : Newtonsoft.Json.JsonConvert.DeserializeObject<List<OrderDetail>>(orderDetailsJson);
            // Tính tổng tiền
            var grandTotal = orderDetails!.Sum(item => item.TotalPrice);

            // Truyền dữ liệu vào View
            ViewBag.GrandTotal = grandTotal;
            // Truyền dữ liệu qua View
            var payment = _paymentRespository.GetAllPayment();

            dynamic dataModel = new ExpandoObject();
            dataModel.OrderDetails = orderDetails;
            dataModel.Payment = payment;

            return View(dataModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaymentMomo(OrderModel model)
        {
            model.OrderId = HttpContext.Session.GetString("OrderId")!;
            model.OrderDate = DateTime.Now;
            model.OrderType = "other";
            model.UserId = HttpContext.Session.GetString("UserId")!;
            model.OrderDate = DateTime.Now;
            var respose = await _momoService.CreatePaymentAsync(model);
            Console.WriteLine(JsonConvert.SerializeObject(respose, Formatting.Indented));
            HttpContext.Session.SetString("Order", Newtonsoft.Json.JsonConvert.SerializeObject(model));
            return Redirect(respose.PayUrl);
        }

        [HttpGet]
        public async Task<IActionResult> PaymentCallBackMomo()
        {
            var response = _momoService.PaymentExecuteAsync(HttpContext.Request.Query);
            Console.WriteLine(JsonConvert.SerializeObject(HttpContext.Request.Query, Formatting.Indented));
            Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));

            var orderJson = HttpContext.Session.GetString("Order");
            var order = string.IsNullOrEmpty(orderJson)
                ? new OrderModel()
                : Newtonsoft.Json.JsonConvert.DeserializeObject<OrderModel>(orderJson);
            var orderDetailsJson = HttpContext.Session.GetString("OrderDetails");
            var orderDetails = string.IsNullOrEmpty(orderDetailsJson)
                ? new List<OrderDetail>()
                : Newtonsoft.Json.JsonConvert.DeserializeObject<List<OrderDetail>>(orderDetailsJson);

            if(response.ErrorCode == "0")
            {
                var newOrder = await _orderRespository.CreateNewOrder(order!);
                var newOrderDetail = await _orderDetailRepository.CreateOrderDetail(orderDetails!);
                InvoiceModel model = new InvoiceModel();
                model = InvoiceMapping.ToInvoiceModel(order!, orderDetails!);
                model.CustomerName = HttpContext.Session.GetString("UserName")!;
                await _invoiceEmailService.SendInvoiceEmailAsync(model, "takatamashiho.tm2503@gmail.com");
            }

            return View(response);
        }
        [HttpPost]
        public IActionResult CreatePaymentUrlVnpay(OrderModel model)
        {
            model.OrderId = HttpContext.Session.GetString("OrderId")!;
            model.OrderDate = DateTime.Now;
            model.OrderType = "other";
            model.UserId = HttpContext.Session.GetString("UserId")!;
            var url = _vnPayService.CreatePaymentUrl(model, HttpContext);
            HttpContext.Session.SetString("Order", Newtonsoft.Json.JsonConvert.SerializeObject(model));

            return Redirect(url);
        }
        [HttpGet]
        public async Task<IActionResult> PaymentCallbackVnpay()
        {
            var response = _vnPayService.PaymentExecute(Request.Query);
            var orderJson = HttpContext.Session.GetString("Order");
            var order = string.IsNullOrEmpty(orderJson)
                ? new OrderModel()
                : Newtonsoft.Json.JsonConvert.DeserializeObject<OrderModel>(orderJson);
            var orderDetailsJson = HttpContext.Session.GetString("OrderDetails");
            var orderDetails = string.IsNullOrEmpty(orderDetailsJson)
                ? new List<OrderDetail>()
                : Newtonsoft.Json.JsonConvert.DeserializeObject<List<OrderDetail>>(orderDetailsJson);

            if (response.VnPayResponseCode == "00")
            {
                var newOrder = await _orderRespository.CreateNewOrder(order!);
                var newOrderDetail = await _orderDetailRepository.CreateOrderDetail(orderDetails!);
                InvoiceModel model = new InvoiceModel();
                model = InvoiceMapping.ToInvoiceModel(order!, orderDetails!);
                model.CustomerName = HttpContext.Session.GetString("UserName")!;
                await _invoiceEmailService.SendInvoiceEmailAsync(model, "takatamashiho.tm2503@gmail.com");
            }

            return View(response);
        }
        public IActionResult PaymentCallBack()
        {
            return View();
        }
    }
}
