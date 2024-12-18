using DTO.IRepository;
using DTO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository
{
    public class SanPhamRepository : ISanPhamRepository
    {
        private readonly MusicalStoreContext _context;
        public SanPhamRepository(MusicalStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SanPham>> AddNewSanPham(SanPham sanpham)
        {
            _context.SanPhams.Add(sanpham);
            await _context.SaveChangesAsync();

            return _context.SanPhams.Select(sp => new SanPham
            {
                MaSp = sp.MaSp,
                TenSp = sp.TenSp,
                Hang = sp.Hang,
                Dvt = sp.Dvt,
                Gia = sp.Gia,
                MoTa = sp.MoTa,
                Hinh = sp.Hinh,
                Slsp = sp.Slsp,
                MaLsp = sp.MaLsp
            }).ToList();
        }

        public async Task<IEnumerable<SanPham>> UpdateSanPham(SanPham sanpham)
        {
            _context.SanPhams.Update(sanpham);
            await _context.SaveChangesAsync();

            return _context.SanPhams.Select(sp => new SanPham
            {
                MaSp = sp.MaSp,
                TenSp = sp.TenSp,
                Hang = sp.Hang,
                Dvt = sp.Dvt,
                Gia = sp.Gia,
                MoTa = sp.MoTa,
                Hinh = sp.Hinh,
                Slsp = sp.Slsp,
                MaLsp = sp.MaLsp
            }).ToList();
        }
        public async Task<IEnumerable<SanPham>> DeleteSanPham(string masp)
        {
            var sanpham = _context.SanPhams.FirstOrDefault(sp => sp.MaSp == masp);
            _context.SanPhams.Remove(sanpham);
            await _context.SaveChangesAsync();

            return _context.SanPhams.Select(sp => new SanPham
            {
                MaSp = sp.MaSp,
                TenSp = sp.TenSp,
                Hang = sp.Hang,
                Dvt = sp.Dvt,
                Gia = sp.Gia,
                MoTa = sp.MoTa,
                Hinh = sp.Hinh,
                Slsp = sp.Slsp,
                MaLsp = sp.MaLsp
            }).ToList();
        }

        public IEnumerable<SanPham> GetListSanpham()
        {
            return _context.SanPhams.Select(sp => new SanPham
            {
                MaSp = sp.MaSp,
                TenSp = sp.TenSp,
                Hang = sp.Hang,
                Dvt = sp.Dvt,
                Gia = sp.Gia,
                MoTa = sp.MoTa,
                Hinh = sp.Hinh,
                Slsp = sp.Slsp,
                MaLsp = sp.MaLsp
            }).ToList();
        }

        public SanPham GetSanPhamById(string id)
        {
            var sanpham = _context.SanPhams.FirstOrDefault(sp => sp.MaSp == id);
            return sanpham;
        }
    }
}
