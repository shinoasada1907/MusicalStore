using DTO.IRepository;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository
{
    public class ChiTietDHRepository : IChiTietDHRepository
    {
        private readonly MusicalStoreContext _context;
        public ChiTietDHRepository(MusicalStoreContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CtDonHang>> TaoChiTietDonHang(List<CtDonHang> ctDonHang)
        {
            _context.CtDonHangs.AddRange(ctDonHang);
            await _context.SaveChangesAsync();
            var maCtDhList = ctDonHang.Select(ct => ct.MaCtDh).ToList();
            var ctdh = _context.CtDonHangs.Where(ct => maCtDhList.Contains(ct.MaCtDh)).ToList();
            return ctdh!;
        }
    }
}
