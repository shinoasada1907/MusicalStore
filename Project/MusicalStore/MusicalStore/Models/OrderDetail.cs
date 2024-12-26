namespace MusicalStore.Models
{
    public class OrderDetail
    {
        public string OrderDetailId { get; set; } = string.Empty;
        public string OrderId { get; set; } = string.Empty;
        public string ProductId { get; set; } = string.Empty;
        public string VoucherId { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
        public double UnitPrice { get; set; } = 0;
        public double TotalPrice { get; set; } = 0;
        public Product Product { get; set; } = new Product();
        public Voucher Voucher { get; set; } = new Voucher();
    }
}
