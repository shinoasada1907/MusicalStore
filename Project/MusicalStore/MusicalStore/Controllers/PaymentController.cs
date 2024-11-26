using Microsoft.AspNetCore.Mvc;
using MusicalStore.Models;
using MusicalStore.Models.Service.Vnpay;
using MusicalStore.Repository.Momo;
using MusicalStore.Repository.vnpay;
using Newtonsoft.Json;

namespace MusicalStore.Controllers
{
    public class PaymentController : Controller
    {
        private IMomoService _momoService;
        private readonly IVnPayService _vnPayService;
        public PaymentController(IMomoService momoService, IVnPayService vnPayService)
        {
            _momoService = momoService;
            _vnPayService = vnPayService;
        }
        [HttpGet]
        public IActionResult Order()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaymentMomo(OrderModel model)
        {
            var respose = await _momoService.CreatePaymentAsync(model);
            //Console.WriteLine(JsonConvert.SerializeObject(respose, Formatting.Indented));
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

    }
}
