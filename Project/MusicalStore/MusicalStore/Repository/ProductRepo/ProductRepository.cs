using DTO.IRepository;
using DTO.Repository;
using MusicalStore.Mapping;
using MusicalStore.Models;

namespace MusicalStore.Repository.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        private readonly ISanPhamRepository _sanPhamRepository;
        private readonly IChiTietGiamGiaRepository _chiTietGiamGiaRepository;
        private readonly ICTSanPhamRepository _cTSanPhamRepository;
        private readonly IGiamGiaRepository _giamGiaRepository;
        public ProductRepository(ISanPhamRepository sanPhamRepository, IChiTietGiamGiaRepository chiTietGiamGiaRepository, ICTSanPhamRepository cTSanPhamRepository, IGiamGiaRepository giamGiaRepository)
        {
            _sanPhamRepository = sanPhamRepository;
            _chiTietGiamGiaRepository = chiTietGiamGiaRepository;
            _cTSanPhamRepository = cTSanPhamRepository;
            _giamGiaRepository = giamGiaRepository;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            var products = _sanPhamRepository.GetListSanpham();
            return ProductMapping.MapToProducts(products);
        }

        public IEnumerable<Product> GetListProductWithPage(int page, int pageSize)
        {
            var products = _sanPhamRepository.GetListSanpham().OrderBy(p => p.MaLsp).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return ProductMapping.MapToProducts(products);
        }

        public Product GetProductById(string id)
        {
            var sanpham = _sanPhamRepository.GetSanPhamById(id);
            var chiTietSP = _cTSanPhamRepository.GetCTSanPham(sanpham.MaCtsp);
            var chiTietGG = _chiTietGiamGiaRepository.GetChiTietGiamGia(id);
            var detailVoucher = DetailVoucherMapping.MapToDetailVoucher(chiTietGG);
            if(!string.IsNullOrEmpty(detailVoucher.VoucherCode))
            {
                var giamGia = _giamGiaRepository.GetMaGiamGia(chiTietGG.MaGg);
                detailVoucher.Voucher = VoucherMapping.MapToVoucher(giamGia);
            }

            var product = ProductMapping.MappingToProduct(sanpham);
            product.DetailVoucher = detailVoucher ?? new DetailVoucher();
            product.ProductDetail = ProductDetailMapping.MapToProductDetail(chiTietSP);
            return product;
        }
    }
}
