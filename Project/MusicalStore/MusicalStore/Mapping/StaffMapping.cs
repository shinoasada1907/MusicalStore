using DTO.Models;
using MusicalStore.Models;

namespace MusicalStore.Mapping
{
    public class StaffMapping
    {
        // NhanVien -> Staff
        public static Staff MappingToStaff(NhanVien? nhanVien)
        {
            return new Staff
            {
                StaffId = nhanVien?.Cccd ?? string.Empty, // Mapping CCCD to StaffId
                StaffName = nhanVien?.TenNv ?? string.Empty,
                Birthday = nhanVien!.NgaySinh.HasValue
                            ? nhanVien.NgaySinh.Value.ToDateTime(TimeOnly.MinValue)
                            : DateTime.MinValue,
                Sex = nhanVien?.GioiTinh ?? string.Empty,
                Phone = nhanVien?.DienThoai ?? string.Empty,
                Position = nhanVien?.MaCvNavigation?.TenCv ?? string.Empty // Assuming TenCv exists in ChucVu
            };
        }

        // Staff -> NhanVien
        public static NhanVien MappingToNhanVien(Staff staff)
        {
            return new NhanVien
            {
                Cccd = staff.StaffId,
                TenNv = staff.StaffName,
                NgaySinh = staff.Birthday != DateTime.MinValue
                           ? DateOnly.FromDateTime(staff.Birthday)
                           : null,
                GioiTinh = !string.IsNullOrEmpty(staff.Sex) ? staff.Sex : null,
                DienThoai = !string.IsNullOrEmpty(staff.Phone) ? staff.Phone : null,
                MaCv = null // Assuming Position mapping to MaCv is handled elsewhere
            };
        }

        // IEnumerable<NhanVien> -> IEnumerable<Staff>
        public static IEnumerable<Staff> MapToStaffs(IEnumerable<NhanVien> nhanViens)
        {
            return nhanViens.Select(nhanVien => MappingToStaff(nhanVien)).ToList();
        }

        // IEnumerable<Staff> -> IEnumerable<NhanVien>
        public static IEnumerable<NhanVien> MapToNhanViens(IEnumerable<Staff> staffs)
        {
            return staffs.Select(staff => MappingToNhanVien(staff)).ToList();
        }
    }
}
