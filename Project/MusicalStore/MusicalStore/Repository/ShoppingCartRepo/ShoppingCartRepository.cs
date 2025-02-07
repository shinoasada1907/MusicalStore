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
            var shoppingCart = ShoppingCartMapping.MapToShoppingCartList(giohang);
            foreach (var item in shoppingCart)
            {
                var sanPham = _sanPhamRepository.GetSanPhamById(item.ProductId);
                item.Product = ProductMapping.MappingToProduct(sanPham);
            }

            return shoppingCart;
        }

        public Task<IEnumerable<ShoppingCart>> DeleteAllShoppingCart(string customerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShoppingCart>> DeleteShoppingCart(string customerId, string idCart)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ShoppingCart>> DeleteShoppingCart(string customerId, List<string> listId)
        {
            try
            {
                var giohangs = await _gioHangRepository.DeleteGioHang(customerId, listId);
                var shoppingCarts = ShoppingCartMapping.MapToShoppingCartList(giohangs);
                foreach (var item in shoppingCarts)
                {
                    var sanPham = _sanPhamRepository.GetSanPhamById(item.ProductId);
                    item.Product = ProductMapping.MappingToProduct(sanPham);
                }
                return shoppingCarts;
            }
            catch(Exception ex)
            {

                throw new NotImplementedException(ex.Message);
            }
        }

        public IEnumerable<ShoppingCart> GetShoppingCarts(string customerId)
        {
            var giohangs = _gioHangRepository.GetListGioHang(customerId);
            var cart = ShoppingCartMapping.MapToShoppingCartList(giohangs);
            foreach (var item in cart)
            {
                var sanpham = _sanPhamRepository.GetSanPhamById(item.ProductId);
                item.Product = ProductMapping.MappingToProduct(sanpham);
            }
            return cart;
        }
    }
}
