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
        public IEnumerable<Product> GetTopSellingProducts();
        public IEnumerable<Product> GetListProductByCategory(string category);
        public IEnumerable<Product> GetListProductByCategoryWithPage(string category, int page, int pageSize);
        public IEnumerable<Product> GetListCollectionProduct(string category, int page, int pageSize);
        public bool CheckQuantityProduct(string productId, int quantity);
    }
}
