using DTO.IRepository;
using MusicalStore.Mapping;
using MusicalStore.Models;

namespace MusicalStore.Repository.OrderRespository
{
    public class OrderRespository :  IOrderRespository
    {
        private readonly IDonHangRepository _orderRepository;
        public OrderRespository(IDonHangRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<OrderModel> GetAllOrder()
        {
            var orders = _orderRepository.GetListDonHang();
            return OrderMapping.MapToOrderModels(orders);
        }
    }
}
