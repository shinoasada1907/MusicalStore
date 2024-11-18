namespace MusicalStore.Models
{
    public class Order
    {
        public string OrderId { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.MinValue;
        public decimal TotalAmount { get; set; } = 0;
        public string Status { get; set; } = string.Empty;
    }
}
