using DTO.IRepository;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository
{
    public class CTSanPhamRepository : ICTSanPhamRepository
    {
        private readonly MusicalStoreContext _context;
        public CTSanPhamRepository(MusicalStoreContext context)
        {
            _context = context;
        }
        public CtSanPham GetCTSanPham(string masp)
        {
            var CTSP = _context.CtSanPhams.FirstOrDefault(sp => sp.MaCtsp == masp);
            return CTSP;
        }
    }
}
