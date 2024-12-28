using MusicalStore.Models;

namespace MusicalStore.Repository.OrderRespository
{
    public interface IOrderRespository
    {
        public IEnumerable<OrderModel> GetAllOrder();
        public IEnumerable<StatusModel> GetAllStatus();
        public Task<OrderModel> CreateNewOrder(OrderModel model);
    }
}
