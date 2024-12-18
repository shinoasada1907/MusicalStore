namespace MusicalStore.Models
{
    public class Cart
    {
        public string CartId { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string ProductId { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
        public double? Price { get; set; } // Giá sản phẩm (Gia)
    }
}
