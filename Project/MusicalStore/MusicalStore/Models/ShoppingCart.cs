namespace MusicalStore.Models
{
    public class ShoppingCart
    {
        public string CartId { get; set; } = string.Empty;
        public string ProductId { get; set; } = string.Empty;
        public string CustomerId { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
        public double Price { get; set; } = 0;
        public Product Product { get; set; } = new Product();
    }
}
