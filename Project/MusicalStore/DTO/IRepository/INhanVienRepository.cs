using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.IRepository
{
    public interface INhanVienRepository
    {
        public IEnumerable<NhanVien> GetListNhanVien();
        public Task<IEnumerable<NhanVien>> AddNewNhanVien(NhanVien nhanvien);
        public Task<IEnumerable<NhanVien>> UpdateNhanVien(NhanVien nhanvien);
    }
}
