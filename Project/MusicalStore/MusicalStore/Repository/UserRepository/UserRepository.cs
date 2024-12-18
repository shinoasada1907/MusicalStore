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

        public async Task<UserModel> RegisterNewUser(UserModel userModel)
        {
            var khachHang = UserMapping.MapToKhachHang(userModel);
            var user = await _khachHangRepository.DangKyThongTinKhachHang(khachHang);
            var userMapping = UserMapping.MapToUserModel(user);
            return userMapping;
        }

        public async Task<UserModel> UpdateNewUser(UserModel userModel)
        {
            var user = UserMapping.MapToKhachHang(userModel);
            var khach = await _khachHangRepository.CapNhatThongTinKhachHang(user);
            var khachhang = UserMapping.MapToUserModel(khach);
            return khachhang;
        }
    }
}
