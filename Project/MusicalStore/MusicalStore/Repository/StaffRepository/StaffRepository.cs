using DTO.IRepository;
using MusicalStore.Mapping;
using MusicalStore.Models;

namespace MusicalStore.Repository.StaffRepository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly INhanVienRespository _nhanVienRepository;
        public StaffRepository(INhanVienRespository nhanVienRepository)
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
