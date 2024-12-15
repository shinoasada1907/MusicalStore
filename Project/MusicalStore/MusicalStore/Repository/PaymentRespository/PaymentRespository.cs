using DTO.IRepository;
using DTO.Models;
using DTO.Repository;
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
        //Them 
        public async Task<IEnumerable<Payment>> AddNewPayment(Payment payment)
        {
            var ptthanhtoan = PaymentMapping.MappingToPtThanhToan(payment);
            var listPtThanhtoan = await _ptthanhToanRepository.AddNewPtThanhToan(ptthanhtoan);
            var listPayment = PaymentMapping.MapToPaymentMethods(listPtThanhtoan);
            return listPayment;
        }
        //Xoa
        public async Task<IEnumerable<Payment>> DeletePayment(string paymentmethodId)
        {
            var listPtThanhtoan = await _ptthanhToanRepository.DeletePtThanhToan(paymentmethodId);
            var listPayment = PaymentMapping.MapToPaymentMethods(listPtThanhtoan);
            return listPayment;
        }
        //Cap nhat
        public async Task<IEnumerable<Payment>> UpdatePayment(Payment payment)
        {
            var ptthanhtoan = PaymentMapping.MappingToPtThanhToan(payment);
            var listPtThanhtoan = await _ptthanhToanRepository.UpdatePtThanhToan(ptthanhtoan);
            var listPayment = PaymentMapping.MapToPaymentMethods(listPtThanhtoan);
            return listPayment;
        }
        //Lay 
        public IEnumerable<Payment> GetAllPayment()
        {
            var ptthanhtoan = _ptthanhToanRepository.GetListPtThanhToan();
            return PaymentMapping.MapToPaymentMethods(ptthanhtoan);
        }

        public Payment GetPaymentById(string id)
        {
            var payment = _ptthanhToanRepository.GetPtThanhToanById(id);
            Console.WriteLine($"Staff {payment.MaPttt}");
            return PaymentMapping.MappingToPaymentMethod(payment);
        }


    }
}
