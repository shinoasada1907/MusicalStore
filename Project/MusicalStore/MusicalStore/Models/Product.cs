using NuGet.Protocol;

namespace MusicalStore.Models
{
    public class Product
    {
        public string Id { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string ProductDesc { get; set; } = string.Empty;
        public decimal ProductPrice { get; set; } = 0;
        public string CategoryId { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string DVT { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
    }
}
