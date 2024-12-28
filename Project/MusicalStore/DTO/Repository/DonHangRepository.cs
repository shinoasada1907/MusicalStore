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

        public async Task<IEnumerable<DonHang>> CapNhatTrangThaiDonHang(string makh, string madh, int trangthai)
        {
            try
            {
                var donhang = _context.DonHangs.FirstOrDefault(d => d.MaDh == madh);
                donhang!.MaTt = trangthai;
                _context.DonHangs.Update(donhang);
                await _context.SaveChangesAsync();
                return _context.DonHangs.Where(d => d.MaKh == makh).ToList();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }

        }

        public IEnumerable<DonHang> GetListDonHang()
        {
            return _context.DonHangs.Select(dh => new DonHang
            {
                MaDh = dh.MaDh,
                TongTienHang = dh.TongTienHang,
                NgayLap = dh.NgayLap,
                MaKh = dh.MaKh,
                MaTt = dh.MaTt,
                MaPttt = dh.MaPttt,
                MaKhNavigation = dh.MaKhNavigation,
                MaPtttNavigation = dh.MaPtttNavigation,
                MaTtNavigation = dh.MaTtNavigation,
            }).ToList();
        }

        public async Task<DonHang> KhoiTaoDonHang(DonHang donHang)
        {
            _context.DonHangs.Add(donHang);
            await _context.SaveChangesAsync();
            var don = _context.DonHangs.FirstOrDefault(d => d.MaDh == donHang.MaDh);
            return don!;
        }
    }
}