using MusicalStore.Models;

namespace MusicalStore.Data
{
    public class StaffData
    {
        public static List<Staff> staffList = new List<Staff>
        {
            new Staff
            {
                StaffId = "CCCD001",
                StaffName = "Nguyen Thi Mai",
                Birthday = new DateTime(1990, 5, 12),
                Sex = "Nữ",
                Phone = "0912345678",
                PositionId = "Quản lý"
            },
            new Staff
            {
                StaffId = "CCCD002",
                StaffName = "Tran Minh Tuấn",
                Birthday = new DateTime(1985, 3, 25),
                Sex = "Nam",
                Phone = "0909876543",
                PositionId = "Nhân viên"
            },
            new Staff
            {
                StaffId = "CCCD003",
                StaffName = "Le Thi Lan",
                Birthday = new DateTime(1988, 7, 22),
                Sex = "Nữ",
                Phone = "0987654321",
                PositionId = "Kế toán"
            },
            new Staff
            {
                StaffId = "CCCD004",
                StaffName = "Pham Quang Hieu",
                Birthday = new DateTime(1992, 11, 30),
                Sex = "Nam",
                Phone = "0931234567",
                PositionId = "Lễ tân"
            },
            new Staff
            {
                StaffId = "CCCD005",
                StaffName = "Nguyen Thi Hoa",
                Birthday = new DateTime(1993, 1, 18),
                Sex = "Nữ",
                Phone = "0901234567",
                PositionId = "Marketing"
            }
        };
    }
}
