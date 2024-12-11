using DTO.Models;
using MusicalStore.Models;

namespace MusicalStore.Mapping
{
    public class PositionMapping
    {
        public static PositionModel MapToPosition(ChucVu chucVu)
        {
            return new PositionModel
            {
                PositionId = chucVu.MaCv,
                PositionName = chucVu.TenCv,
                Salary = chucVu.MucLuong.ToString()
            };
        }

        //public static KhachHang MapToKhachHang(UserModel userModel)
        //{
        //    return new KhachHang
        //    {
        //        MaKh = userModel.UID,
        //        TenKh = userModel.UName,
        //        Email = string.IsNullOrWhiteSpace(userModel.Email) ? null : userModel.Email,
        //        Sdt = string.IsNullOrWhiteSpace(userModel.SDT) ? null : userModel.SDT,
        //        GioiTinh = string.IsNullOrWhiteSpace(userModel.Sex) ? null : userModel.Sex,
        //        NgaySinhKh = userModel.Birthday == DateTime.MinValue ? null : DateOnly.FromDateTime(userModel.Birthday),
        //        DiaChi = string.IsNullOrWhiteSpace(userModel.Address) ? null : userModel.Address
        //    };
        //}

        public static IEnumerable<PositionModel> MapToPositions(IEnumerable<ChucVu> chucVus)
        {
            return chucVus.Select(chucvu => MapToPosition(chucvu)).ToList();
        }

    }
}
