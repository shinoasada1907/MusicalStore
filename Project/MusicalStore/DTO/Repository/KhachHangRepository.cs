using DTO.IRepository;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository
{
    public class KhachHangRepository : IKhachHangRepository
    {
        private readonly MusicalStoreContext _context;
        public KhachHangRepository(MusicalStoreContext context)
        {
            _context = context;
        }
        public IEnumerable<KhachHang> GetAllKhackHang()
        {
            return _context.KhachHangs.Select(sp=>new KhachHang
            {
                MaKh = sp.MaKh,
                TenKh = sp.TenKh,
                Email = sp.Email,
                Sdt = sp.Sdt,
                GioiTinh = sp.GioiTinh,
                NgaySinhKh = sp.NgaySinhKh,
                DiaChi = sp.DiaChi
            }).ToList();
        }

        public KhachHang GetKhachHang(string makh)
        {
            var khachhang = _context.KhachHangs.FirstOrDefault(kh => kh.MaKh == makh);
            return khachhang;
        }
    }
}
