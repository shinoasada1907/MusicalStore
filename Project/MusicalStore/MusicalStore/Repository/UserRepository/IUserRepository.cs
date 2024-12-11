using MusicalStore.Models;

namespace MusicalStore.Repository.UserRepository
{
    public interface IUserRepository
    {
        public IEnumerable<UserModel> GetAllUser();
    }
}
