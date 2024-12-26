using DTO.IRepository;
using DTO.Models;
using MusicalStore.Mapping;
using MusicalStore.Models;

namespace MusicalStore.Repository.OrderDetailRepository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly IChiTietDHRepository _chiTietDHRepository;
        public OrderDetailRepository(IChiTietDHRepository chiTietDHRepository)
        {
            _chiTietDHRepository = chiTietDHRepository;
        }
        public async Task<IEnumerable<OrderDetail>> CreateOrderDetail(List<OrderDetail> orderDetail)
        {
            var dhmapping = OrderDetailMapping.MapToListChiTietDH(orderDetail);
            var ctdh = await _chiTietDHRepository.TaoChiTietDonHang(dhmapping as List<CtDonHang>);
            var detail = OrderDetailMapping.MapToListDetail(ctdh);
            return detail;
        }
    }
}
