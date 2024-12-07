using DTO.Models;
using MusicalStore.Models;

namespace MusicalStore.Mapping
{
    public class ProductMapping
    {
        public static Product MappingToProduct(SanPham sanPham)
        {
            return new Product
            {
                ProductCode = sanPham.MaSp,
                ProductName = sanPham.TenSp,
                Brand = sanPham.Hang,
                Unit = sanPham.Dvt,
                Price = sanPham.Gia,
                Description = sanPham.MoTa,
                ImageUrl = sanPham.Hinh,
                StockQuantity = sanPham.Slsp,
                CategoryCode = sanPham.MaLsp
            };
        }

        public static SanPham MappingToSanPham(Product product)
        {
            return new SanPham
            {

            };
        }

        public static IEnumerable<Product> MapToProducts(IEnumerable<SanPham> sanPhams)
        {
            return sanPhams.Select(sanPham => MappingToProduct(sanPham)).ToList();
        }
    }
}
