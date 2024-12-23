using MusicalStore.Models;

namespace MusicalStore.Repository.OrderDetailRepository
{
    public interface IOrderDetailRepository
    {
        public Task<OrderDetail> CreateOrderDetail(OrderDetail orderDetail);
    }
}
