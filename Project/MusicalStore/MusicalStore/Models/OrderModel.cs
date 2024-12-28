namespace MusicalStore.Models
{
    public class OrderModel
    {
        public string OrderId { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.MinValue;
        public decimal TotalAmount { get; set; } = 0;
        public string Status { get; set; } = string.Empty;
        public int StatusId { get; set; } = 1;
        public string OrderInfo { get; set; } = string.Empty;
        public string PaymentId { get; set; } = string.Empty;
        public string OrderType { get; set; } = string.Empty;
        public StatusModel StatusModel { get; set; } = new StatusModel();
    }
}
