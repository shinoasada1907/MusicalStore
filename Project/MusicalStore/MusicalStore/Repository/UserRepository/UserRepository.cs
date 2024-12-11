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
    }
}
