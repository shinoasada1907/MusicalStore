using MusicalStore.Models;

namespace MusicalStore.Repository.OrderRespository
{
    public interface IOrderRespository
    {
        public IEnumerable<OrderModel> GetAllOrder();
        public IEnumerable<OrderModel> GetAllOrderByCustomer(string customerId);
        public IEnumerable<StatusModel> GetAllStatus();
        public Task<OrderModel> CreateNewOrder(OrderModel model);
        public OrderModel GerOrderById(string orderId);
        public Task<IEnumerable<OrderModel>> UpdateStatusOrder(string orderId, string customerId, int statusId);
        public IEnumerable<OrderModel> GetOrderByStatus(string customerId, int statusId);
    }
}
