using MusicalStore.Models;

namespace MusicalStore.Repository.UserRepository
{
    public interface IUserRepository
    {
        public IEnumerable<UserModel> GetAllUser();
        public Task<UserModel> RegisterNewUser(UserModel userModel);
        public Task<UserModel> UpdateNewUser(UserModel userModel);
        public UserModel GetUserInfor(string userId);
    }
}
