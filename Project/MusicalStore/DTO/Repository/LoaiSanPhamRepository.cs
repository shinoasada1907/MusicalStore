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

        public IEnumerable<LoaiSanPham> GetAllLoaiSanPham()
        {
            return _context.LoaiSanPhams.Select(lsp => new LoaiSanPham
            {
                MaLsp = lsp.MaLsp,
                TenLsp = lsp.TenLsp,
            }).ToList();
        }

        public LoaiSanPham GetLoaiSanPham(string malsp)
        {
            var loaisanPham = _context.LoaiSanPhams.FirstOrDefault(c => c.MaLsp == malsp);
            return loaisanPham;
        }
    }
}
