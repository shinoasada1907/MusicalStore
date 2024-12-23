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

        //Thêm mới chi tiết ctsp
        public async Task<IEnumerable<CtSanPham>> AddNewCtSanPham(CtSanPham ctsanpham)
        {
            _context.CtSanPhams.Add(ctsanpham);
            await _context.SaveChangesAsync();

            return _context.CtSanPhams.Select(ctsp => new CtSanPham
            {
                MaCtsp = ctsp.MaCtsp,
                GioiThieu = ctsp.GioiThieu,
                ThongSo = ctsp.ThongSo,
                TinhNang = ctsp.TinhNang,
            }).ToList();
        }

        public async Task<IEnumerable<CtSanPham>> DeleteCtSanPham(string mactsp)
        {
            var ctsanpham = _context.CtSanPhams.FirstOrDefault(ctsp => ctsp.MaCtsp == mactsp);
            _context.CtSanPhams.Remove(ctsanpham);
            await _context.SaveChangesAsync();

            return _context.CtSanPhams.Select(ctsp => new CtSanPham
            {
                MaCtsp = ctsp.MaCtsp,
                GioiThieu = ctsp.GioiThieu,
                ThongSo = ctsp.ThongSo,
                TinhNang = ctsp.TinhNang,
            }).ToList();
        }
    

        public CtSanPham GetCTSanPham(string mactsp)
        {
            var ctsp = _context.CtSanPhams.FirstOrDefault(ctsp => ctsp.MaCtsp == mactsp);
            return ctsp;
        }

        public async Task<IEnumerable<CtSanPham>> UpdateCtSanPham(CtSanPham ctsanpham)
        {
            _context.CtSanPhams.Update(ctsanpham);
            await _context.SaveChangesAsync();

            return _context.CtSanPhams.Select(ctsp => new CtSanPham
            {
                MaCtsp = ctsp.MaCtsp,
                GioiThieu = ctsp.GioiThieu,
                ThongSo = ctsp.ThongSo,
                TinhNang = ctsp.TinhNang,
            }).ToList();
        }
    }
}
