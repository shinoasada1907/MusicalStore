using DTO.IRepository;
using DTO.Models;
using MusicalStore.Mapping;
using MusicalStore.Models;
using MusicalStore.Repository.ProductRepo;

namespace MusicalStore.Repository.OrderDetailRepository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly IChiTietDHRepository _chiTietDHRepository;
        private readonly ISanPhamRepository _sanPhamRepository;
        public OrderDetailRepository(IChiTietDHRepository chiTietDHRepository, ISanPhamRepository sanPhamRepository)
        {
            _chiTietDHRepository = chiTietDHRepository;
            _sanPhamRepository = sanPhamRepository;
        }
        public async Task<IEnumerable<OrderDetail>> CreateOrderDetail(List<OrderDetail> orderDetail)
        {
            var dhmapping = OrderDetailMapping.MapToListChiTietDH(orderDetail);
            var ctdh = await _chiTietDHRepository.TaoChiTietDonHang(dhmapping as List<CtDonHang>);
            var detail = OrderDetailMapping.MapToListDetail(ctdh);
            return detail;
        }

        public IEnumerable<OrderDetail> GetAllOrderDetail(string customerId)
        {
            var ctdh = _chiTietDHRepository.GetAllChiTietDonHang(customerId);
            var orderdetail = OrderDetailMapping.MapToListDetail(ctdh);
            foreach (OrderDetail item in orderdetail)
            {
                var sanpham = _sanPhamRepository.GetSanPhamById(item.ProductId);
                item.Product = ProductMapping.MappingToProduct(sanpham);
            }
            return orderdetail;
        }

        public IEnumerable<OrderDetail> GetOrderDetailByStatus(string customerId, int statusId)
        {
            var ctdh = _chiTietDHRepository.GetChiTietDonTrangThai(customerId, statusId);
            var orderdetail = OrderDetailMapping.MapToListDetail(ctdh);
            foreach (OrderDetail item in orderdetail)
            {
                var sanpham = _sanPhamRepository.GetSanPhamById(item.ProductId);
                item.Product = ProductMapping.MappingToProduct(sanpham);
            }
            return orderdetail;
        }
    }
}
