using MusicalStore.Models;

namespace MusicalStore.Repository.ProductRepo
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public IEnumerable<Product> GetListProductWithPage(int page, int pageSize);
        public Product GetProductById(string id);
        public Task<IEnumerable<Product>> AddNewProduct(Product product);
        public Task<IEnumerable<Product>> UpdateProduct(Product product);
        public Task<IEnumerable<Product>> DeleteProduct(string productId);
    }
}
