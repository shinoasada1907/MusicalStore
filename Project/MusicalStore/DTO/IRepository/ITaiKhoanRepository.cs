using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.IRepository
{
    public interface ITaiKhoanRepository
    {
        public TaiKhoan GetThongTinTaiKhoan(string tentk, string matkhau);
        public TaiKhoan DangKyTaiKhoan(TaiKhoan taikhoan);
    }
}
