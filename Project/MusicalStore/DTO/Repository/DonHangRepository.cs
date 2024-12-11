using DTO.IRepository;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository
{
    public class DonHangRepository : IDonHangRepository
    {
        private readonly MusicalStoreContext _context;
        public DonHangRepository(MusicalStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<DonHang> GetListDonHang()
        {
            return _context.DonHangs.Select(dh => new DonHang
            {
                MaDh = dh.MaDh,
                TongTienHang = dh.TongTienHang,
                TongTt = dh.TongTt,
                NgayLap = dh.NgayLap,
                TinhTrang = dh.TinhTrang,
                MaKh = dh.MaKh,
                MaTt = dh.MaTt,
                MaPttt = dh.MaPttt,
                MaKhNavigation = dh.MaKhNavigation,
                MaPtttNavigation = dh.MaPtttNavigation,
                MaTtNavigation = dh.MaTtNavigation,
            }).ToList();
        }
    }
}