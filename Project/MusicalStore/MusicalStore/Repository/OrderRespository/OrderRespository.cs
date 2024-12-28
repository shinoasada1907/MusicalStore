using DTO.IRepository;
using MusicalStore.Mapping;
using MusicalStore.Models;

namespace MusicalStore.Repository.OrderRespository
{
    public class OrderRespository : IOrderRespository
    {
        private readonly IDonHangRepository _donHangRepository;
        private readonly ITrangThaiRepository _trangThaiRepository;
        public OrderRespository(IDonHangRepository donHangRepository, ITrangThaiRepository trangThaiRepository)
        {
            _donHangRepository = donHangRepository;
            _trangThaiRepository = trangThaiRepository;
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
            var listOrder = OrderMapping.MapToOrderModels(orders);
            foreach(OrderModel item in listOrder)
            {
                var tt = _trangThaiRepository.GetTrangThaiById(item.StatusId);
                item.StatusModel = StatusMapping.MapToStatusModel(tt);
            }
            return listOrder;
        }

        public IEnumerable<StatusModel> GetAllStatus()
        {
            var tt = _trangThaiRepository.GetAllTrangThai();
            return StatusMapping.MapToStatuses(tt);
        }
    }
}
