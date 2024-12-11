using MusicalStore.Models;

namespace MusicalStore.Repository.AccountRepository
{
    public interface IAccountRepository
    {
        public Account LoginAccount(string username, string password);
    }
}
