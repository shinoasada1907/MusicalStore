using DTO.Models;
using MusicalStore.Models;

namespace MusicalStore.Mapping
{
    public class ShoppingCartMapping
    {
        // Map từ ShoppingCart sang GioHang
        public static GioHang MapToGioHang(ShoppingCart? shoppingCart)
        {
            return new GioHang
            {
                MaGh = shoppingCart!.CartId,
                MaSp = shoppingCart!.ProductId,
                MaKh = shoppingCart!.CustomerId,
                SoLuong = shoppingCart!.Quantity,
                Gia = shoppingCart!.Price
            };
        }

        // Map từ GioHang sang ShoppingCart
        public static ShoppingCart MapToShoppingCart(GioHang? gioHang)
        {
            return new ShoppingCart
            {
                CartId = gioHang!.MaGh,
                ProductId = gioHang!.MaSp,
                CustomerId = gioHang!.MaKh,
                Quantity = gioHang!.SoLuong,
                Price = gioHang!.Gia ?? 0 // Xử lý null cho Gia
            };
        }

        // Map danh sách từ ShoppingCart sang GioHang
        public static List<GioHang> MapToGioHangList(IEnumerable<ShoppingCart> shoppingCartList)
        {
            if (shoppingCartList == null)
                throw new ArgumentNullException(nameof(shoppingCartList));

            return shoppingCartList.Select(MapToGioHang).ToList();
        }

        // Map danh sách từ GioHang sang ShoppingCart
        public static List<ShoppingCart> MapToShoppingCartList(IEnumerable<GioHang> gioHangList)
        {
            if (gioHangList == null)
                throw new ArgumentNullException(nameof(gioHangList));

            return gioHangList.Select(MapToShoppingCart).ToList();
        }
    }
}
