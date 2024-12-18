using DTO.IRepository;
using MusicalStore.Mapping;
using MusicalStore.Models;
using System.Security.Principal;

namespace MusicalStore.Repository.AccountRepository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ITaiKhoanRepository _taiKhoanRepository;
        public AccountRepository(ITaiKhoanRepository taiKhoanRepository)
        {
            _taiKhoanRepository = taiKhoanRepository;
        }

        public bool CheckExistsUser(string username)
        {
            return _taiKhoanRepository.KiemTraTaiKhoan(username);
        }

        public Account GetAccountInfor(string username)
        {
            throw new NotImplementedException();
        }

        public Account LoginAccount(string username, string password)
        {
            try
            {
                var taikhoan = _taiKhoanRepository.GetThongTinTaiKhoan(username, password);
                if (taikhoan != null)
                {
                    var account = AccountMapping.MapToAccount(taikhoan);
                    return account;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<Account> RegisterAccount(Account account)
        {
            var acc = AccountMapping.MapToTaiKhoan(account);
            var taikhoan = await _taiKhoanRepository.DangKyTaiKhoan(acc);
            return AccountMapping.MapToAccount(taikhoan);
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            var acc = AccountMapping.MapToTaiKhoan(account);
            var taikhoan = await _taiKhoanRepository.CapNhatTaiKhoan(acc);
            return AccountMapping.MapToAccount(taikhoan);
        }
    }
}
