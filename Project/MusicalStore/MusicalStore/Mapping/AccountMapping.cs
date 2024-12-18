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

        public static TaiKhoan MapToTaiKhoan(Account account)
        {
            return new TaiKhoan
            {
                MaTk = account.AccountId ?? string.Empty,
                TenTk = account.AccountName ?? string.Empty,
                MatKhau = account.Password ?? string.Empty,
                Email = account.Email ?? string.Empty,
                MaKh = account.CustomerId ?? string.Empty,
                MaNv = account.EmployeeId ?? string.Empty,
                MaPq = account.PermissionId ?? string.Empty
            };
        }
    }
}
