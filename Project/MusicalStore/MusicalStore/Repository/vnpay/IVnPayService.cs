using MusicalStore.Models;
using MusicalStore.Models.Service.Vnpay;

namespace MusicalStore.Repository.vnpay
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(OrderModel model, HttpContext context);
        PaymentResponseModel PaymentExecute(IQueryCollection collections);

    }
}
