namespace MusicalStore.Models
{
    public class VoucherDetail
    {
        public DateOnly? StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public string ProductCode { get; set; } = null!;

        public string VoucherCode { get; set; } = null!;
    }
}
