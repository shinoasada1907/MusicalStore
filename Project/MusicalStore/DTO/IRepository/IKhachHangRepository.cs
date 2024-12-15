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
        public KhachHang DangKyThongTinKhachHang(KhachHang khachHang);
    }
}
