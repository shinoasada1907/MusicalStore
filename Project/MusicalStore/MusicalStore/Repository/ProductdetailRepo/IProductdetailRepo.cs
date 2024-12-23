using MusicalStore.Data;
using MusicalStore.Models;

namespace MusicalStore.Repository.ProductdetailRepo
{
    public interface IProductdetailRepo
    {
        public ProductDetail GetProductdetaiById(string id);
        public Task<IEnumerable<ProductDetail>> AddNewProductDetail(ProductDetail productdetail);
        public Task<IEnumerable<ProductDetail>> UpdateProductDetail(ProductDetail productdetail);
        public Task<IEnumerable<ProductDetail>> DeleteProductDetail(string productdetailcode);
    }
}
