using DTO.IRepository;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository
{
    public class GioHangRepository : IGioHangRepository
    {
        private readonly MusicalStoreContext _context;
        public GioHangRepository(MusicalStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GioHang>> AddGioHang(GioHang giohang)
        {
            var existGioHang = _context.GioHangs.FirstOrDefault(gh => gh.MaSp == giohang.MaSp && gh.MaSp == giohang.MaKh);
            if(existGioHang != null)
            {
                existGioHang.SoLuong += 1;
                _context.GioHangs.Update(existGioHang);
            }    
            else
            {
                _context.GioHangs.Add(giohang);
            }    
            
            await _context.SaveChangesAsync();
            var giohangs = _context.GioHangs.Where(gh => gh.MaKh == giohang.MaKh).ToList();
            return giohangs;
        }

        public async Task<IEnumerable<GioHang>> DeleteAllGioHang(string makh)
        {
            var giohangs = GetListGioHang(makh);
            _context.GioHangs.RemoveRange(giohangs);
            await _context.SaveChangesAsync();
            return _context.GioHangs.Where(gh => gh.MaKh == makh).ToList();
        }

        public async Task<IEnumerable<GioHang>> DeleteGioHang(string makh, string IdGioHang)
        {
            var hang = _context.GioHangs.FirstOrDefault(h => h.MaGh == IdGioHang);
            _context.GioHangs.Remove(hang!);
            await _context.SaveChangesAsync();
            return _context.GioHangs.Where(gh => gh.MaKh == makh).ToList();
        }

        public async Task<IEnumerable<GioHang>> DeleteGioHang(string makh, List<string> listId)
        {
            var giohangs = _context.GioHangs.Where(gh => listId.Contains(gh.MaGh)).ToList();
            _context.GioHangs.RemoveRange(giohangs);
            await _context.SaveChangesAsync();
            return _context.GioHangs.Where(gh => gh.MaKh == makh).ToList();
        }

        public IEnumerable<GioHang> GetListGioHang(string makh)
        {
            var giohang = _context.GioHangs.Where(gh => gh.MaKh == makh).ToList();
            return giohang;
        }
    }
}
