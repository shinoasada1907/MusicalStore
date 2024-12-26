using MusicalStore.Models;

namespace MusicalStore.Repository.OrderRespository
{
    public interface IOrderRespository
    {
        public IEnumerable<OrderModel> GetAllOrder();
        public Task<OrderModel> CreateNewOrder(OrderModel model);
    }
}
