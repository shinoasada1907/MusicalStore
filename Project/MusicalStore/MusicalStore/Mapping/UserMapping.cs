using DTO.Models;
using MusicalStore.Models;

namespace MusicalStore.Mapping
{
    public class UserMapping
    {
        public static UserModel MapToUserModel(KhachHang khachHang)
        {
            return new UserModel
            {
                UID = khachHang.MaKh,
                UName = khachHang.TenKh,
                Email = khachHang.Email ?? string.Empty,
                SDT = khachHang.Sdt ?? string.Empty,
                Sex = khachHang.GioiTinh ?? string.Empty,
                Birthday = khachHang.NgaySinhKh?.ToDateTime(TimeOnly.MinValue) ?? DateTime.MinValue,
                Address = khachHang.DiaChi ?? string.Empty,
                Avatar = khachHang.AnhDaiDien ?? string.Empty
            };
        }

        public static KhachHang MapToKhachHang(UserModel userModel)
        {
            return new KhachHang
            {
                MaKh = userModel.UID,
                TenKh = userModel.UName,
                Email = string.IsNullOrWhiteSpace(userModel.Email) ? null : userModel.Email,
                Sdt = string.IsNullOrWhiteSpace(userModel.SDT) ? null : userModel.SDT,
                GioiTinh = string.IsNullOrWhiteSpace(userModel.Sex) ? null : userModel.Sex,
                NgaySinhKh = userModel.Birthday == DateTime.MinValue ? null : DateOnly.FromDateTime(userModel.Birthday),
                DiaChi = string.IsNullOrWhiteSpace(userModel.Address) ? null : userModel.Address,
                AnhDaiDien = userModel.Avatar ?? string.Empty
            };
        }

        public static IEnumerable<UserModel> MapToKhachHangs(IEnumerable<KhachHang> khachhangs)
        {
            return khachhangs.Select(khachhang => MapToUserModel(khachhang)).ToList();
        }
    }
}
