using DTO.IRepository;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository
{
    public class LoaiSanPhamRepository : ILoaiSanPhamRepository
    {
        private readonly MusicalStoreContext _context;
        public LoaiSanPhamRepository(MusicalStoreContext context)
        {
            _context = context;
        }
        public LoaiSanPham GetLoaiSanPham(string malsp)
        {
            var lsp = _context.LoaiSanPhams.FirstOrDefault(l => l.MaLsp == malsp);
            return lsp;
        }
    }
}
