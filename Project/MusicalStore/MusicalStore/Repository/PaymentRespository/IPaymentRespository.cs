using MusicalStore.Models;

namespace MusicalStore.Repository.PaymentRespository
{
    public interface IPaymentRespository
    {
        public IEnumerable<Payment> GetAllPayment();
    }
}
