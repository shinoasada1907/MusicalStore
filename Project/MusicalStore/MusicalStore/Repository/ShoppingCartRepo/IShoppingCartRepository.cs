using DTO.Models;
using MusicalStore.Models;

namespace MusicalStore.Repository.ShoppingCartRepo
{
    public interface IShoppingCartRepository
    {
        public IEnumerable<ShoppingCart> GetShoppingCarts(string customerId);
        public Task<IEnumerable<ShoppingCart>> AddShoppingCart(ShoppingCart cart);
        public Task<IEnumerable<ShoppingCart>> DeleteShoppingCart(string customerId, string idCart);
        public Task<IEnumerable<ShoppingCart>> DeleteShoppingCart(string customerId, List<string> listId);
        public Task<IEnumerable<ShoppingCart>> DeleteAllShoppingCart(string customerId);
    }
}
