using DTO.Models;
using MusicalStore.Models;

namespace MusicalStore.Mapping
{
    public class ProductMapping
    {
        //DTO -> Project
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

        //Project -> DTO
        public static SanPham MappingToSanPham(Product product)
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
