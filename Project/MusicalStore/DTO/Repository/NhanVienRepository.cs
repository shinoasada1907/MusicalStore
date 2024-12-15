using DTO.IRepository;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository
{
    public class NhanVienRepository : INhanVienRepository
    {
        private readonly MusicalStoreContext _context;
        public NhanVienRepository(MusicalStoreContext context)
        {
            _context = context;
        }
        public NhanVien GetNhanVienById(string id)
        {
            return _context.NhanViens.FirstOrDefault(nv => nv.MaNv == id);
        }
        public async Task<IEnumerable<NhanVien>> AddNhanVien(NhanVien nhanvien)
        {
            _context.NhanViens.Add(nhanvien);
            await _context.SaveChangesAsync();

            return _context.NhanViens.Select(nv => new NhanVien
            {
                MaCv = nv.MaCv,
                MaNv = nv.MaNv,
                TenNv = nv.TenNv,
                GioiTinh = nv.GioiTinh,
                NgaySinh = nv.NgaySinh,
                DienThoai = nv.DienThoai,
                Cccd = nv.Cccd,
            }).ToList();
        }
        public async Task<IEnumerable<NhanVien>> UpdateNhanVien(NhanVien nhanvien)
        {
            _context.NhanViens.Update(nhanvien);
            await _context.SaveChangesAsync();

            return _context.NhanViens.Select(nv => new NhanVien
            {
                MaCv = nv.MaCv,
                MaNv = nv.MaNv,
                TenNv = nv.TenNv,
                GioiTinh = nv.GioiTinh,
                NgaySinh = nv.NgaySinh,
                DienThoai = nv.DienThoai,
                Cccd = nv.Cccd,
            }).ToList();
        }public async Task<IEnumerable<NhanVien>> DeleteNhanVien(string manv)
        {
            var nhanvien = _context.NhanViens.FirstOrDefault(nv => nv.MaNv == manv);
            _context.NhanViens.Remove(nhanvien);
            await _context.SaveChangesAsync();

            return _context.NhanViens.Select(nv => new NhanVien
            {
                MaCv = nv.MaCv,
                MaNv = nv.MaNv,
                TenNv = nv.TenNv,
                GioiTinh = nv.GioiTinh,
                NgaySinh = nv.NgaySinh,
                DienThoai = nv.DienThoai,
                Cccd = nv.Cccd,
            }).ToList();
        }

        public IEnumerable<NhanVien> GetListNhanVien()
        {
            return _context.NhanViens.Select(nv => new NhanVien
            {
                MaCv = nv.MaCv,
                MaNv = nv.MaNv,
                TenNv = nv.TenNv,  
                GioiTinh = nv.GioiTinh, 
                NgaySinh = nv.NgaySinh, 
                DienThoai = nv.DienThoai,
                Cccd  = nv.Cccd,
            }).ToList();
        }
    }
}
