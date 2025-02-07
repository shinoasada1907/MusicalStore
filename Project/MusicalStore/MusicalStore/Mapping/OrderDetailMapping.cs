using DTO.Models;
using MusicalStore.Models;

namespace MusicalStore.Mapping
{
    public class OrderDetailMapping
    {
        public static OrderDetail MapToOrderDetail(CtDonHang? ctDonHang)
        {
            return new OrderDetail
            {
                OrderDetailId = ctDonHang!.MaCtDh,
                OrderId = ctDonHang.MaDh ?? string.Empty,
                ProductId = ctDonHang.MaSP ?? string.Empty,
                Quantity = ctDonHang.SoLuong,
                UnitPrice = ctDonHang.Gia ?? 0,
                TotalPrice = ctDonHang.Tong ?? 0// Add voucher mapping logic here if applicable
            };
        }

        public static CtDonHang MapToCtDonHang(OrderDetail? orderDetail)
        {
            return new CtDonHang
            {
                MaCtDh = orderDetail!.OrderDetailId,
                MaDh = orderDetail.OrderId,
                MaSP = orderDetail.ProductId,
                SoLuong = orderDetail.Quantity,
                Gia = orderDetail.UnitPrice,
                Tong = orderDetail.TotalPrice
            };
        }

        public static IEnumerable<OrderDetail> MapToListDetail(IEnumerable<CtDonHang>? donHangs)
        {
            return donHangs!.Select(donHang => MapToOrderDetail(donHang)).ToList();
        }

        public static IEnumerable<CtDonHang> MapToListChiTietDH(IEnumerable<OrderDetail>? details)
        {
            return details!.Select(detail => MapToCtDonHang(detail)).ToList();
        }
    }
}
