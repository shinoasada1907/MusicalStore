using DTO.IRepository;
using MusicalStore.Mapping;
using MusicalStore.Models;

namespace MusicalStore.Repository.OrderRespository
{
    public class OrderRespository : IOrderRespository
    {
        private readonly IDonHangRepository _donHangRepository;
        private readonly ITrangThaiRepository _trangThaiRepository;
        private readonly IKhachHangRepository _khachHangRepository;
        public OrderRespository(IDonHangRepository donHangRepository, ITrangThaiRepository trangThaiRepository, IKhachHangRepository khachHangRepository)
        {
            _donHangRepository = donHangRepository;
            _trangThaiRepository = trangThaiRepository;
            _khachHangRepository = khachHangRepository;
        }

        public async Task<OrderModel> CreateNewOrder(OrderModel model)
        {
            var orderMapping = OrderMapping.MappingToDonHang(model);
            var donHangMoi = await _donHangRepository.KhoiTaoDonHang(orderMapping);
            var newOrder = OrderMapping.MappingToOrderModel(donHangMoi);
            return newOrder;
        }

        public OrderModel GerOrderById(string orderId)
        {
            var donHang = _donHangRepository.GetDonHangById(orderId);
            var khach = _khachHangRepository.GetKhachHang(donHang.MaKh);
            var order = OrderMapping.MappingToOrderModel(donHang);
            order.UserModel = UserMapping.MapToUserModel(khach);
            return order;
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

        public IEnumerable<OrderModel> GetAllOrderByCustomer(string customerId)
        {
            var orders = _donHangRepository.GetListDonHangKhachHang(customerId);
            var listOrder = OrderMapping.MapToOrderModels(orders);
            foreach (OrderModel item in listOrder)
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

        public IEnumerable<OrderModel> GetOrderByStatus(string customerId, int statusId)
        {
            var orders = _donHangRepository.GetDonHangTrangThai(customerId, statusId);
            var listOrder = OrderMapping.MapToOrderModels(orders);
            foreach (OrderModel item in listOrder)
            {
                var tt = _trangThaiRepository.GetTrangThaiById(item.StatusId);
                item.StatusModel = StatusMapping.MapToStatusModel(tt);
            }
            return listOrder;
        }

        public async Task<IEnumerable<OrderModel>> UpdateStatusOrder(string orderId, string customerId, int statusId)
        {
            var donhang = await _donHangRepository.CapNhatTrangThaiDonHang(orderId, customerId, statusId);
            var listOrder = OrderMapping.MapToOrderModels(donhang);
            foreach (OrderModel item in listOrder)
            {
                var tt = _trangThaiRepository.GetTrangThaiById(item.StatusId);
                item.StatusModel = StatusMapping.MapToStatusModel(tt);
            }
            return listOrder;
        }
    }
}
