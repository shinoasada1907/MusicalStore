using Microsoft.Extensions.Options;
using MusicalStore.Models;
using MusicalStore.Models.Service.Momo;
using Newtonsoft.Json;
using RestSharp;
using System.Security.Cryptography;
using System.Text;

namespace MusicalStore.Repository.Momo
{
    public class MomoService : IMomoService
    {
        private readonly IOptions<MomoOptionModel> _options;
        public MomoService(IOptions<MomoOptionModel> options)
        {
            _options = options;
        }
        public async Task<MomoCreatePaymentResponseModel> CreatePaymentAsync(OrderModel model)
        {
            var rawData =
             $"partnerCode={_options.Value.PartnerCode}" +
             $"&accessKey={_options.Value.AccessKey}" +
             $"&requestId={model.OrderId}" +
             $"&amount={model.TotalAmount}" +
             $"&orderId={model.OrderId}" +
             $"&orderInfo={model.OrderInfo}" +
             $"&returnUrl={_options.Value.ReturnUrl}" +
             $"&notifyUrl={_options.Value.NotifyUrl}" +
             $"&extraData=";

            var signature = ComputeHmacSha256(rawData, _options.Value.SecretKey);

            var client = new RestClient(_options.Value.MomoApiUrl);
            var request = new RestRequest() { Method = Method.Post };
            request.AddHeader("Content-Type", "application/json; charset=UTF-8");

            // Create an object representing the request data
            var requestData = new
            {
                accessKey = _options.Value.AccessKey,
                partnerCode = _options.Value.PartnerCode,
                requestType = _options.Value.RequestType,
                notifyUrl = _options.Value.NotifyUrl,
                returnUrl = _options.Value.ReturnUrl,
                orderId = model.OrderId,
                amount = model.TotalAmount.ToString(),
                orderInfo = model.OrderInfo,
                requestId = model.OrderId,
                extraData = "",
                signature
            };

            request.AddParameter("application/json", JsonConvert.SerializeObject(requestData), ParameterType.RequestBody);

            var response = await client.ExecuteAsync(request);
            var momoResponse = JsonConvert.DeserializeObject<MomoCreatePaymentResponseModel>(response.Content!);
            Console.WriteLine(JsonConvert.SerializeObject(response.Content));
            return momoResponse!;

        }

        public MomoExecuteResponseModel PaymentExecuteAsync(IQueryCollection collection)
        {

            var partnerCode = collection.FirstOrDefault(s => s.Key == "partnerCode").Value.FirstOrDefault();
            var accessKey = collection.FirstOrDefault(s => s.Key == "accessKey").Value.FirstOrDefault();
            var requestId = collection.FirstOrDefault(s => s.Key == "requestId").Value.FirstOrDefault();
            var amount = collection.FirstOrDefault(s => s.Key == "amount").Value.FirstOrDefault();
            var orderId = collection.FirstOrDefault(s => s.Key == "orderId").Value.FirstOrDefault();
            var orderInfo = collection.FirstOrDefault(s => s.Key == "orderInfo").Value.FirstOrDefault();
            var orderType = collection.FirstOrDefault(s => s.Key == "orderType").Value.FirstOrDefault();
            var transId = collection.FirstOrDefault(s => s.Key == "transId").Value.FirstOrDefault();
            var message = collection.FirstOrDefault(s => s.Key == "message").Value.FirstOrDefault();
            var localMessage = collection.FirstOrDefault(s => s.Key == "localMessage").Value.FirstOrDefault();
            var responseTime = collection.FirstOrDefault(s => s.Key == "responseTime").Value.FirstOrDefault();
            var errorCode = collection.FirstOrDefault(s => s.Key == "errorCode").Value.FirstOrDefault();
            var payType = collection.FirstOrDefault(s => s.Key == "payType").Value.FirstOrDefault();
            var extraData = collection.FirstOrDefault(s => s.Key == "extraData").Value.FirstOrDefault();
            var signature = collection.FirstOrDefault(s => s.Key == "signature").Value.FirstOrDefault();


            return new MomoExecuteResponseModel()
            {
                PartnerCode = partnerCode!,
                AccessKey = accessKey!,
                RequestId = requestId!,
                Amount = amount!,
                OrderId = orderId!,
                OrderInfo = orderInfo!,
                OrderType = orderType!,
                TransId = transId!,
                Message = message!,
                LocalMessage = localMessage!,
                ResponseTime = responseTime!,
                ErrorCode = errorCode!,
                PayType = payType!,
                ExtraData = extraData!,
                Signature = signature!
            };

        }

        private string ComputeHmacSha256(string message, string secretKey)
        {
            var keyBytes = Encoding.UTF8.GetBytes(secretKey);
            var messageBytes = Encoding.UTF8.GetBytes(message);

            byte[] hashBytes;

            using (var hmac = new HMACSHA256(keyBytes))
            {
                hashBytes = hmac.ComputeHash(messageBytes);
            }

            var hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            return hashString;
        }

    }
}
