using DTO.IRepository;
using DTO.Repository;
using Microsoft.CodeAnalysis;
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
        private readonly ILoaiSanPhamRepository _loaiSanPhamRepsoritory;
        public ProductRepository(ISanPhamRepository sanPhamRepository, IChiTietGiamGiaRepository chiTietGiamGiaRepository, ICTSanPhamRepository cTSanPhamRepository, IGiamGiaRepository giamGiaRepository, ILoaiSanPhamRepository loaiSanPhamRepsoritory)
        {
            _sanPhamRepository = sanPhamRepository;
            _chiTietGiamGiaRepository = chiTietGiamGiaRepository;
            _cTSanPhamRepository = cTSanPhamRepository;
            _giamGiaRepository = giamGiaRepository;
            _loaiSanPhamRepsoritory = loaiSanPhamRepsoritory;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            var sanpham = _sanPhamRepository.GetListSanpham();
            var products = ProductMapping.MapToProducts(sanpham);
            foreach (var item in products)
            {
                var loaisanpham = _loaiSanPhamRepsoritory.GetLoaiSanPham(item.CategoryCode) ?? new DTO.Models.LoaiSanPham();
                item.Category = CategoryMapping.MapToCategory(loaisanpham);
            }
            return products;
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
            if (!string.IsNullOrEmpty(detailVoucher.VoucherCode))
            {
                var giamGia = _giamGiaRepository.GetMaGiamGia(chiTietGG.MaGg);
                detailVoucher.Voucher = VoucherMapping.MapToVoucher(giamGia);
            }

            var product = ProductMapping.MappingToProduct(sanpham);
            product.DetailVoucher = detailVoucher ?? new DetailVoucher();
            product.ProductDetail = ProductDetailMapping.MapToProductDetail(chiTietSP);
            return product;
        }

        public async Task<IEnumerable<Product>> AddNewProduct(Product product)
        {
            var sanpham = ProductMapping.MappingToSanPham(product);
            var listSanPham = await _sanPhamRepository.AddNewSanPham(sanpham);
            var listProduct = ProductMapping.MapToProducts(listSanPham);
            foreach (var item in listProduct)
            {
                var loaisanpham = _loaiSanPhamRepsoritory.GetLoaiSanPham(item.CategoryCode);
                item.Category = CategoryMapping.MapToCategory(loaisanpham);
            }
            return listProduct;
        }

        public async Task<IEnumerable<Product>> UpdateProduct(Product product)
        {
            var sanpham = ProductMapping.MappingToSanPham(product);
            var listSanPham = await _sanPhamRepository.UpdateSanPham(sanpham);
            var listProduct = ProductMapping.MapToProducts(listSanPham);
            foreach (var item in listProduct)
            {
                var loaisanpham = _loaiSanPhamRepsoritory.GetLoaiSanPham(item.CategoryCode);
                item.Category = CategoryMapping.MapToCategory(loaisanpham);
            }
            return listProduct;
        }

        public async Task<IEnumerable<Product>> DeleteProduct(string productId)
        {
            var listSanPham = await _sanPhamRepository.DeleteSanPham(productId);
            var listProduct = ProductMapping.MapToProducts(listSanPham);
            foreach (var item in listProduct)
            {
                var loaisanpham = _loaiSanPhamRepsoritory.GetLoaiSanPham(item.CategoryCode);
                item.Category = CategoryMapping.MapToCategory(loaisanpham);
            }
            return listProduct;
        }

        //Lấy top sản phẩm
        public IEnumerable<Product> GetTopSellingProducts()
        {
            var listSanPham = _sanPhamRepository.GetTopSellingProductsInMonth();
            var listProduct = ProductMapping.MapToProducts(listSanPham);
            foreach (var item in listProduct)
            {
                var loaisanpham = _loaiSanPhamRepsoritory.GetLoaiSanPham(item.CategoryCode);
                item.Category = CategoryMapping.MapToCategory(loaisanpham);
            }
            return listProduct;

        }

        public IEnumerable<Product> GetListProductByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetListProductByCategoryWithPage(string category, int page, int pageSize)
        {
            var products = _sanPhamRepository.GetListSanPhamByCategory(category).OrderBy(p => p.MaLsp).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return ProductMapping.MapToProducts(products);
        }
    }
}
