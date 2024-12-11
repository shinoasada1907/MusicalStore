using DTO.IRepository;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository
{
    public class TaiKhoanRepository : ITaiKhoanRepository
    {
        private readonly MusicalStoreContext _context;
        public TaiKhoanRepository(MusicalStoreContext context)
        {
            _context = context;
        }
        public TaiKhoan GetThongTinTaiKhoan(string tentk, string matkhau)
        {
            var taikhoan = _context.TaiKhoans.FirstOrDefault(tk => tk.TenTk == tentk && tk.MatKhau == matkhau);
            return taikhoan;
        }
    }
}
