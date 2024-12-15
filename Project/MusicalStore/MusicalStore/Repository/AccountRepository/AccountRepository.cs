using DTO.IRepository;
using MusicalStore.Mapping;
using MusicalStore.Models;

namespace MusicalStore.Repository.AccountRepository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ITaiKhoanRepository _taiKhoanRepository;
        public AccountRepository(ITaiKhoanRepository taiKhoanRepository)
        {
            _taiKhoanRepository = taiKhoanRepository;
        }
        public Account LoginAccount(string username, string password)
        {
            try
            {
                var taikhoan = _taiKhoanRepository.GetThongTinTaiKhoan(username, password);
                var account = AccountMapping.MapToAccount(taikhoan);
                return account;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Account RegisterAccount(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
