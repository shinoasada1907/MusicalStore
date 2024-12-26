using DTO.IRepository;
using MusicalStore.Mapping;
using MusicalStore.Models;

namespace MusicalStore.Repository.OrderRespository
{
    public class OrderRespository : IOrderRespository
    {
        private readonly IDonHangRepository _donHangRepository;
        public OrderRespository(IDonHangRepository donHangRepository)
        {
            _donHangRepository = donHangRepository;
        }

        public async Task<OrderModel> CreateNewOrder(OrderModel model)
        {
            var orderMapping = OrderMapping.MappingToDonHang(model);
            var donHangMoi = await _donHangRepository.KhoiTaoDonHang(orderMapping);
            var newOrder = OrderMapping.MappingToOrderModel(donHangMoi);
            return newOrder;
        }

        public IEnumerable<OrderModel> GetAllOrder()
        {
            var orders = _donHangRepository.GetListDonHang();
            return OrderMapping.MapToOrderModels(orders);
        }
    }
}
