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
                AccountId = taiKhoan.MaTk,
                AccountName = taiKhoan.TenTk,
                Email = taiKhoan.Email,
                CustomerId = taiKhoan.MaKh,
                EmployeeId = taiKhoan.MaNv,
                PermissionId = taiKhoan.MaPq
            };
        }

        public static TaiKhoan MapToTaiKhoan(Account account)
        {
            return new TaiKhoan
            {
                MaTk = account.AccountId,
                TenTk = account.AccountName,
                Email = account.Email,
                MaKh = account.CustomerId,
                MaNv = account.EmployeeId,
                MaPq = account.PermissionId
            };
        }
    }
}
