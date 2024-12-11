using DTO.Models;
using MusicalStore.Models;

namespace MusicalStore.Mapping
{
    public class PaymentMapping
    {
        // DTO -> Model
        public static Payment MappingToPaymentMethod(PtThanhToan ptThanhToan)
        {
            return new Payment
            {
                PaymentMethodId = ptThanhToan.MaPttt,
                MethodType = ptThanhToan.HinhThuc,
                PhoneNumber = ptThanhToan.Sdt,
                RecipientName = ptThanhToan.TenNhan,
                BankName = ptThanhToan.NganHang,
                AccountNumber = ptThanhToan.Stk
            };
        }

        // Model -> DTO
        public static PtThanhToan MappingToPtThanhToan(Payment payment)
        {
            return new PtThanhToan
            {
                MaPttt = payment.PaymentMethodId,
                HinhThuc = payment.MethodType,
                Sdt = payment.PhoneNumber,
                TenNhan = payment.RecipientName,
                NganHang = payment.BankName,
                Stk = payment.AccountNumber
            };
        }

        // IEnumerable<PtThanhToan> -> IEnumerable<PaymentMethod>
        public static IEnumerable<Payment> MapToPaymentMethods(IEnumerable<PtThanhToan> ptThanhToans)
        {
            return ptThanhToans.Select(ptThanhToan => MappingToPaymentMethod(ptThanhToan)).ToList();
        }

        // IEnumerable<PaymentMethod> -> IEnumerable<PtThanhToan>
        public static IEnumerable<PtThanhToan> MapToPtThanhToans(IEnumerable<Payment> paymentMethods)
        {
            return paymentMethods.Select(paymentMethod => MappingToPtThanhToan(paymentMethod)).ToList();
        }
    }
}
