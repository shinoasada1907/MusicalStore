using NuGet.Protocol;

namespace MusicalStore.Models
{
    public class Product
    {
        public string ProductCode { get; set; } = string.Empty; // Mã sản phẩm (MaSp)

        public string ProductName { get; set; } = string.Empty; // Tên sản phẩm (TenSp)

        public string? Brand { get; set; } // Hãng sản xuất (Hang)

        public string? Unit { get; set; } // Đơn vị tính (Dvt)

        public double? Price { get; set; } // Giá sản phẩm (Gia)

        public string? Description { get; set; } // Mô tả sản phẩm (MoTa)

        public string? ImageUrl { get; set; } // Đường dẫn hình ảnh (Hinh)

        public int? StockQuantity { get; set; } // Số lượng sản phẩm (Slsp)

        public string? CategoryCode { get; set; } // Mã loại sản phẩm (MaLsp)

        public bool IsInStock => StockQuantity.HasValue && StockQuantity > 0; // Sản phẩm còn hàng
        public DetailVoucher DetailVoucher { get; set; } = new DetailVoucher();
        public ProductDetail ProductDetail { get; set; } = new ProductDetail();
    }
}
