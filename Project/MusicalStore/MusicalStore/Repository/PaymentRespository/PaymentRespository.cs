using DTO.IRepository;
using MusicalStore.Mapping;
using MusicalStore.Models;

namespace MusicalStore.Repository.PaymentRespository
{
    public class PaymentRespository : IPaymentRespository
    {
        private readonly IPtThanhToanRepository _ptthanhToanRepository;
        public PaymentRespository(IPtThanhToanRepository ptthanhToanRepository)
        {
            _ptthanhToanRepository = ptthanhToanRepository;
        }
        public IEnumerable<Payment> GetAllPayment()
        {
            var ptthanhtoan = _ptthanhToanRepository.GetListPtThanhToan();
            return PaymentMapping.MapToPaymentMethods(ptthanhtoan);
        }
    }
}
