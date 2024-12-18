using DTO.Models;
using MusicalStore.Models;

namespace MusicalStore.Mapping
{
    public class ProductDetailMapping
    {
        public static ProductDetail MapToProductDetail(CtSanPham? ctSanPham)
        {
            return new ProductDetail
            {
                ProductDetailCode = ctSanPham?.MaCtsp ?? string.Empty,
                Introduction = ctSanPham?.GioiThieu ?? string.Empty,
                Specifications = ctSanPham?.ThongSo ?? string.Empty,
                Features = ctSanPham?.TinhNang ?? string.Empty
            };
        }

        public static CtSanPham MapToCtSanPham(ProductDetail? productDetail)
        {
            return new CtSanPham
            {
                MaCtsp = productDetail?.ProductDetailCode ?? string.Empty,
                GioiThieu = productDetail?.Introduction ?? string.Empty,
                ThongSo = productDetail?.Specifications ?? string.Empty,
                TinhNang = productDetail?.Features ?? string.Empty
            };
        }
    }
}
