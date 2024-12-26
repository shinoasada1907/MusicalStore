namespace MusicalStore.Models.Service
{
    public class InvoiceModel
    {
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public List<InvoiceItem> Items { get; set; }
        public decimal TotalAmount => Items.Sum(item => item.Quantity * item.UnitPrice);
    }
    public class InvoiceItem
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
