using DTO.IRepository;
using DTO.Repository;
using MusicalStore.Mapping;
using MusicalStore.Models;

namespace MusicalStore.Repository.ProductdetailRepo
{
    public class ProductdetailRepo : IProductdetailRepo
    {
        private readonly ICTSanPhamRepository _ctsanPhamRepository;
        public ProductdetailRepo(ICTSanPhamRepository ctsanPhamRepository)
        {
            _ctsanPhamRepository = ctsanPhamRepository;
          
        }
        public async Task<IEnumerable<ProductDetail>> AddNewProductDetail(ProductDetail productdetail)
        {
            var ctsanpham = ProductDetailMapping.MapToCtSanPham(productdetail);
            var listCtSanPham = await _ctsanPhamRepository.AddNewCtSanPham(ctsanpham);
            var listProductDetail = ProductDetailMapping.MapToProductDetails(listCtSanPham);
             return listProductDetail;
        }

        public async Task<IEnumerable<ProductDetail>> DeleteProductDetail(string productdetailcode)
        {
            var listCtSanPham = await _ctsanPhamRepository.DeleteCtSanPham(productdetailcode);
            var listProductDetail = ProductDetailMapping.MapToProductDetails(listCtSanPham);
            return listProductDetail;
        }

        public ProductDetail GetProductdetaiById(string id)
        {
            var ctsanpham = _ctsanPhamRepository.GetCTSanPham(id);
            var productdetail = ProductDetailMapping.MapToProductDetail(ctsanpham);
            return productdetail;
        }

        public async Task<IEnumerable<ProductDetail>> UpdateProductDetail(ProductDetail productdetail)
        {
            var ctsanpham = ProductDetailMapping.MapToCtSanPham(productdetail);
            var listCtSanPham = await _ctsanPhamRepository.UpdateCtSanPham(ctsanpham);
            var listProductDetail = ProductDetailMapping.MapToProductDetails(listCtSanPham);
            return listProductDetail;
        }
    }
}
