using DTO.IRepository;
using MusicalStore.Mapping;
using MusicalStore.Models;

namespace MusicalStore.Repository.OrderRespository
{
    public class OrderRespository :  IOrderRespository
    {
        private readonly IOrderRespository _nhanVienRepository;
        public OrderRespository(IOrderRespository nhanVienRepository)
        {
            _nhanVienRepository = nhanVienRepository;
        }
        public IEnumerable<Staff> GetAllStaff()
        {
            var nhanvien = _nhanVienRepository.GetListNhanVien();
            return StaffMapping.MapToStaffs(nhanvien);
        }
    }
}
