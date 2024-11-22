using MusicalStore.Models;

namespace MusicalStore.Data
{
    public class UserData
    {
        public static List<UserModel> ListUser = new List<UserModel>
        {
            new UserModel
            {
                UID = "KH001",
                UName = "Nguyễn Văn A",
                Email = "nguyenvana@example.com",
                SDT = "0987654321",
                Sex = "Nam",
                Birthday = new DateTime(1990, 5, 10),
                Address = "Hà Nội"
            },
            new UserModel
            {
                UID = "KH002",
                UName = "Trần Thị B",
                Email = "tranthib@example.com",
                SDT = "0912345678",
                Sex = "Nữ",
                Birthday = new DateTime(1985, 8, 20),
                Address = "Hồ Chí Minh"
            },
            new UserModel
            {
                UID = "KH003",
                UName = "Phan Minh C",
                Email = "phanminhc@example.com",
                SDT = "0923456789",
                Sex = "Nam",
                Birthday = new DateTime(1992, 3, 15),
                Address = "Đà Nẵng"
            },
            new UserModel
            {
                UID = "KH004",
                UName = "Lê Thị D",
                Email = "lethid@example.com",
                SDT = "0934567890",
                Sex = "Nữ",
                Birthday = new DateTime(1995, 12, 5),
                Address = "Cần Thơ"
            }
        };
    }
}
