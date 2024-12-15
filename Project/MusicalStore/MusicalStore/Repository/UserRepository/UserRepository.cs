using DTO.IRepository;
using MusicalStore.Mapping;
using MusicalStore.Models;

namespace MusicalStore.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly IKhachHangRepository _khachHangRepository;
        public UserRepository(IKhachHangRepository khachHangRepository)
        {
            _khachHangRepository = khachHangRepository;
        }
        public IEnumerable<UserModel> GetAllUser()
        {
            var khachhang = _khachHangRepository.GetAllKhackHang();
            return UserMapping.MapToKhachHangs(khachhang);
        }

        public UserModel GetUserInfor(string userId)
        {
            try
            {
                var khach = _khachHangRepository.GetKhachHang(userId);
                var userInfo = UserMapping.MapToUserModel(khach);
                return userInfo;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public UserModel RegisterNewUser()
        {
            throw new NotImplementedException();
        }
    }
}
