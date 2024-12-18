using System.ComponentModel.DataAnnotations.Schema;

namespace MusicalStore.Models
{
    public class Voucher
    {
        public string VoucherCode { get; set; } = null!;

        public int? DiscountValue { get; set; }

        public string? Description { get; set; }
    }
}
