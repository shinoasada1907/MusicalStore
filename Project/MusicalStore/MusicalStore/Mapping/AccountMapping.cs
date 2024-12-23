using DTO.Models;
using MusicalStore.Models;

namespace MusicalStore.Mapping
{
    public class AccountMapping
    {
        public static Account MapToAccount(TaiKhoan taiKhoan)
        {
            return new Account
            {
                AccountId = taiKhoan.MaTk ?? string.Empty,
                AccountName = taiKhoan.TenTk ?? string.Empty,
                Email = taiKhoan.Email ?? string.Empty,
                Password = taiKhoan.MatKhau ?? string.Empty,
                CustomerId = taiKhoan.MaKh ?? string.Empty,
                EmployeeId = taiKhoan.MaNv ?? string.Empty,
                PermissionId = taiKhoan.MaPq ?? string.Empty
            };
        }

        public static TaiKhoan MapToTaiKhoan(Account? account)
        {
            return new TaiKhoan
            {
                MaTk = account!.AccountId,
                TenTk = account!.AccountName,
                MatKhau = account!.Password,
                Email = account!.Email,
                MaKh = account!.CustomerId,
                MaNv = account!.EmployeeId,
                MaPq = account!.PermissionId
            };
        }
    }
}
