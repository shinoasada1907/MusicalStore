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
        public Task<TaiKhoan> DangKyTaiKhoan(TaiKhoan taikhoan);
        public Task<TaiKhoan> CapNhatTaiKhoan(TaiKhoan taiKhoan);
        public bool KiemTraTaiKhoan(string tentk);
    }
}
