using DTO.Models;
using MusicalStore.Models;

namespace MusicalStore.Mapping
{
    public class ProductMapping
    {
        //DTO -> Project
        public static Product MappingToProduct(SanPham? sanPham)
        {
            return new Product
            {
                ProductCode = sanPham?.MaSp ?? string.Empty,
                ProductName = sanPham?.TenSp ?? string.Empty,
                Brand = sanPham?.Hang ?? string.Empty,
                Unit = sanPham?.Dvt ?? string.Empty,
                Price = sanPham?.Gia ?? 0,
                Description = sanPham?.MoTa ?? string.Empty,
                ImageUrl = sanPham?.Hinh ?? string.Empty,
                StockQuantity = sanPham?.Slsp ?? 0,
                CategoryCode = sanPham?.MaLsp ?? string.Empty
            };
        }

        //Project -> DTO
        public static SanPham MappingToSanPham(Product? product)
        {
            return new SanPham
            {
                MaSp = product.ProductCode,
                TenSp = product.ProductName,
                Hang = product.Brand,
                Dvt = product.Unit,
                Gia = product.Price,
                MoTa = product.Description,
                Hinh = product.ImageUrl,
                Slsp = product.StockQuantity,
                MaLsp = product.CategoryCode
            };
        }

        public static IEnumerable<Product> MapToProducts(IEnumerable<SanPham> sanPhams)
        {
            return sanPhams.Select(sanPham => MappingToProduct(sanPham)).ToList();
        }
    }
}
