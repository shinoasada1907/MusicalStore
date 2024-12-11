using DTO.Models;

namespace MusicalStore.Models
{
    public class DetailVoucher
    {
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string ProductCode { get; set; } = null!;
        public string VoucherCode { get; set; } = null!;
        public Voucher Voucher { get; set; } = new Voucher();
    }
}
