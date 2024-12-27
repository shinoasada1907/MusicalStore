using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.IRepository
{
    public interface IDonHangRepository
    {
        public IEnumerable<DonHang> GetListDonHang();
        public Task<DonHang> KhoiTaoDonHang(DonHang donHang);
        public Task<DonHang> CapNhatTrangThaiDonHang(string trangthai);
    }
}
