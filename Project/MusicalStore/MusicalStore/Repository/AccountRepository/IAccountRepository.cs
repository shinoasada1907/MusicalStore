using MusicalStore.Models;

namespace MusicalStore.Repository.AccountRepository
{
    public interface IAccountRepository
    {
        public Account LoginAccount(string username, string password);
        public Task<Account> RegisterAccount(Account account);
        public Task<Account> UpdateAccount(Account account);
        public Account GetAccountInfor(string username);
        public bool CheckExistsUser(string username);
    }
}
