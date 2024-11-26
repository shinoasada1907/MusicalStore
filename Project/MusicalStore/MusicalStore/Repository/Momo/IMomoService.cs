using MusicalStore.Models;
using MusicalStore.Models.Service.Momo;

namespace MusicalStore.Repository.Momo
{
    public interface IMomoService
    {
        Task<MomoCreatePaymentResponseModel> CreatePaymentAsync(OrderModel model);
        MomoExecuteResponseModel PaymentExecuteAsync(IQueryCollection collection);
    }
}
