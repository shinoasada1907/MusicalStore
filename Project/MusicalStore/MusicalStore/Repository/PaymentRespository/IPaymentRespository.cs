using MusicalStore.Models;

namespace MusicalStore.Repository.PaymentRespository
{
    public interface IPaymentRespository
    {
        public IEnumerable<Payment> GetAllPayment();
        public Task<IEnumerable<Payment>> AddNewPayment(Payment payment);
        public Task<IEnumerable<Payment>> UpdatePayment(Payment payment);
        public Task<IEnumerable<Payment>> DeletePayment(string paymentmethodId);
        public Payment GetPaymentById(string id);  
    }
}
