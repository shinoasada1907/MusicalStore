using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.IRepository
{
    public interface IGioHangRepository
    {
        public IEnumerable<GioHang> GetListGioHang(string makh);
        public Task<IEnumerable<GioHang>> AddGioHang(GioHang giohang);
        public Task<IEnumerable<GioHang>> DeleteGioHang(string makh, string IdGioHang);
        public Task<IEnumerable<GioHang>> DeleteGioHang(string makh, List<string> listId);
        public Task<IEnumerable<GioHang>> DeleteAllGioHang(string makh);
    }
}
