using MusicalStore.Models;

namespace MusicalStore.Repository.UserRepository
{
    public interface IUserRepository
    {
        public IEnumerable<UserModel> GetAllUser();
        public UserModel RegisterNewUser();
        public UserModel GetUserInfor(string userId);
    }
}
