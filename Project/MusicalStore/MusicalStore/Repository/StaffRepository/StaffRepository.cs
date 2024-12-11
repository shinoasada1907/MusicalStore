using DTO.IRepository;
using MusicalStore.Mapping;
using MusicalStore.Models;

namespace MusicalStore.Repository.StaffRepository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IChucVuRepository _chucVuRepository;
        public StaffRepository(INhanVienRepository nhanVienRepository, IChucVuRepository chucVuRepository)
        {
            _nhanVienRepository = nhanVienRepository;
            _chucVuRepository = chucVuRepository;
        }

        public async Task<IEnumerable<Staff>> AddNewStaff(Staff staff)
        {
            var nhanvien = StaffMapping.MappingToNhanVien(staff);
            var listNhanVien = await _nhanVienRepository.AddNewNhanVien(nhanvien);
            var listStaff = StaffMapping.MapToStaffs(listNhanVien);
            foreach (var item in listStaff)
            {
                var chuvu = _chucVuRepository.GetChucVu(item.PositionId);
                item.Potition = PositionMapping.MapToPosition(chuvu);
            }
            return listStaff;
        }

        public IEnumerable<Staff> GetAllStaff()
        {
            var nhanvien = _nhanVienRepository.GetListNhanVien();
            var staff = StaffMapping.MapToStaffs(nhanvien);
            foreach(var item in staff)
            {
                var chuvu = _chucVuRepository.GetChucVu(item.PositionId);
                item.Potition = PositionMapping.MapToPosition(chuvu);
            }
            return staff;
        }

    }
}
