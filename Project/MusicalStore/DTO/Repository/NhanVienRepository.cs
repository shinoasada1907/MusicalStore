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

        public async Task<IEnumerable<NhanVien>> AddNewNhanVien(NhanVien nhanvien)
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

        public NhanVien GetInfoNhanVien(string manv)
        {
            try
            {
                var nhanvien = _context.NhanViens.FirstOrDefault(nv => nv.MaNv == manv);
                return nhanvien;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
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

        public Task<IEnumerable<NhanVien>> UpdateNhanVien(NhanVien nhanvien)
        {
            throw new NotImplementedException();
        }
    }
}
