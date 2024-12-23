using DTO.IRepository;
using DTO.Models;
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
        public Task<OrderDetail> CreateOrderDetail(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }
    }
}
