using AspNetCoreGeneratedDocument;
using DTO.IRepository;
using MusicalStore.Mapping;
using MusicalStore.Models;

namespace MusicalStore.Repository.ShoppingCartRepo
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly IGioHangRepository _gioHangRepository;
        private readonly ISanPhamRepository _sanPhamRepository;
        public ShoppingCartRepository(IGioHangRepository gioHangRepository, ISanPhamRepository sanPhamRepository)
        {
            _gioHangRepository = gioHangRepository;
            _sanPhamRepository = sanPhamRepository;
        }
        public async Task<IEnumerable<ShoppingCart>> AddShoppingCart(ShoppingCart cart)
        {
            var gh = ShoppingCartMapping.MapToGioHang(cart);
            var giohang = await _gioHangRepository.AddGioHang(gh);
            return ShoppingCartMapping.MapToShoppingCartList(giohang);
        }

        public Task<IEnumerable<ShoppingCart>> DeleteAllShoppingCart(string customerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShoppingCart>> DeleteShoppingCart(string customerId, string idCart)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShoppingCart>> DeleteShoppingCart(string customerId, List<string> listId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShoppingCart> GetShoppingCarts(string customerId)
        {
            var giohangs = _gioHangRepository.GetListGioHang(customerId);
            var cart = ShoppingCartMapping.MapToShoppingCartList(giohangs);
            foreach(var item in cart)
            {
                var sanpham = _sanPhamRepository.GetSanPhamById(item.ProductId);
                item.Product = ProductMapping.MappingToProduct(sanpham);
            }
            return cart;
        }
    }
}
