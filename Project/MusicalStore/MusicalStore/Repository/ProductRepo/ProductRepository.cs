using DTO.IRepository;
using DTO.Repository;
using MusicalStore.Mapping;
using MusicalStore.Models;

namespace MusicalStore.Repository.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        private readonly ISanPhamRepository _sanPhamRepository;
        private readonly ILoaiSanPhamRepository _loaiSanPhamRepsoritory;
        public ProductRepository(ISanPhamRepository sanPhamRepository, ILoaiSanPhamRepository loaiSanPhamRepsoritory)
        {
            _sanPhamRepository = sanPhamRepository;
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
            var product = _sanPhamRepository.GetSanPhamById(id);
            Console.WriteLine($"Product {product.MaSp}");
            return ProductMapping.MappingToProduct(product);
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
    }
}
