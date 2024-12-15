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

        public TaiKhoan DangKyTaiKhoan(TaiKhoan taikhoan)
        {
            throw new NotImplementedException();
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
