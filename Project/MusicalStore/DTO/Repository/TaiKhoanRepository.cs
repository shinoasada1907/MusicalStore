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

        public async Task<TaiKhoan> CapNhatTaiKhoan(TaiKhoan taiKhoan)
        {
            _context.TaiKhoans.Update(taiKhoan);
            await _context.SaveChangesAsync();
            return _context.TaiKhoans.FirstOrDefault(tk => tk.MaTk == taiKhoan.MaTk);
        }

        public bool KiemTraTaiKhoan(string tentk)
        {
            var taikhoan = _context.TaiKhoans.FirstOrDefault(tk => tk.TenTk == tentk);
            if (taikhoan != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<TaiKhoan> DangKyTaiKhoan(TaiKhoan taikhoan)
        {
            _context.TaiKhoans.Add(taikhoan);
            await _context.SaveChangesAsync();
            return _context.TaiKhoans.FirstOrDefault(tk => tk.MaTk == taikhoan.MaTk);
        }

        public TaiKhoan GetThongTinTaiKhoan(string tentk, string matkhau)
        {
            try
            {
                var taikhoan = _context.TaiKhoans.FirstOrDefault(tk => tk.TenTk == tentk && tk.MatKhau == matkhau);
                return taikhoan;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
