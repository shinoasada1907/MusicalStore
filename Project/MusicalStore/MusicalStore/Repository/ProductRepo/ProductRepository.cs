using DTO.IRepository;
using DTO.Repository;
using MusicalStore.Mapping;
using MusicalStore.Models;

namespace MusicalStore.Repository.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        private readonly ISanPhamRepository _sanPhamRepository;
        public ProductRepository(ISanPhamRepository sanPhamRepository)
        {
            _sanPhamRepository = sanPhamRepository;
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

        public IEnumerable<Product> GetProductById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
