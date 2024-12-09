using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository
{
    public class DonHangRespository
    {
        private readonly MusicalStoreContext _context;
        public DonHangRespository(MusicalStoreContext context)
        {
            _context = context;
        }

        //public IEnumerable<DonHang> GetListDonHang()
        //{
        //    return _context.DonHangs.Select(dh => new DonHang
        //    {
        //        MaDh = dh.MaCv,
        //        MaNv = dh.MaNv,
        //        TenNv = dh.TenNv,
        //        GioiTinh = dh.GioiTinh,
        //        NgaySinh = dh.NgaySinh,
        //        DienThoai = dh.DienThoai,
        //        Cccd = dh.Cccd,
        //    }).ToList();
        //}
    }
}
