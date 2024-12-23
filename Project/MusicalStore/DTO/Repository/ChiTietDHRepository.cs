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
        public async Task<CtDonHang> TaoChiTietDonHang(CtDonHang ctDonHang)
        {
            _context.CtDonHangs.Add(ctDonHang);
            await _context.SaveChangesAsync();
            var ctdh = _context.CtDonHangs.FirstOrDefault(ct => ct.MaCtDh == ctDonHang.MaCtDh);
            return ctdh!;
        }
    }
}
