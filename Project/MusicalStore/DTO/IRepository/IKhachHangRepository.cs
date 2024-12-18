using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.IRepository
{
    public interface IKhachHangRepository
    {
        public IEnumerable<KhachHang> GetAllKhackHang();
        public KhachHang GetKhachHang(string makh);
        public Task<KhachHang> DangKyThongTinKhachHang(KhachHang khachHang);
        public Task<KhachHang> CapNhatThongTinKhachHang(KhachHang khachHang);
    }
}
