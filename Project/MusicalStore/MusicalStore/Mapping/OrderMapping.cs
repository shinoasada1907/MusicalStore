using DTO.Models;
using MusicalStore.Models;

namespace MusicalStore.Mapping
{
    public class OrderMapping
    {
        // DonHang -> OrderModel
        public static OrderModel MappingToOrderModel(DonHang? donHang)
        {
            return new OrderModel
            {
                OrderId = donHang!.MaDh,
                UserId = donHang.MaKh ?? string.Empty,
                UserName = donHang.MaKhNavigation?.TenKh ?? string.Empty, // Assuming KhachHang has TenKh
                OrderDate = donHang.NgayLap.ToDateTime(TimeOnly.MinValue),
                TotalAmount = (decimal)donHang.TongTienHang,
                StatusId = donHang.MaTt ?? 0, // Assuming TinhTrang has TenTt
                PaymentId = donHang.MaPttt ?? string.Empty,
                OrderInfo = GenerateOrderInfo(donHang) // Helper function for detailed order info
            };
        }

        // OrderModel -> DonHang
        public static DonHang MappingToDonHang(OrderModel? orderModel)
        {
            return new DonHang
            {
                MaDh = orderModel!.OrderId,
                MaKh = string.IsNullOrEmpty(orderModel.UserId) ? null : orderModel.UserId,
                NgayLap = DateOnly.FromDateTime(orderModel.OrderDate),
                TongTienHang = (double)orderModel.TotalAmount,
                MaTt = orderModel.StatusId, 
                MaPttt = string.IsNullOrEmpty(orderModel.PaymentId) ? null : orderModel.PaymentId
            };
        }

        // IEnumerable<DonHang> -> IEnumerable<OrderModel>
        public static IEnumerable<OrderModel> MapToOrderModels(IEnumerable<DonHang> donHangs)
        {
            return donHangs.Select(donHang => MappingToOrderModel(donHang)).ToList();
        }

        // IEnumerable<OrderModel> -> IEnumerable<DonHang>
        public static IEnumerable<DonHang> MapToDonHangs(IEnumerable<OrderModel> orderModels)
        {
            return orderModels.Select(orderModel => MappingToDonHang(orderModel)).ToList();
        }

        // Helper function to generate detailed order info
        private static string GenerateOrderInfo(DonHang donHang)
        {
            // Example logic to construct order details (can be customized)
            return $"Order ID: {donHang.MaDh}, Total: , Status: ";
        }
    }
}
