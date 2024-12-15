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
                public Task<IEnumerable<NhanVien>> AddNhanVien(NhanVien nhanvien);
                public Task<IEnumerable<NhanVien>> UpdateNhanVien(NhanVien nhanvien);
                public NhanVien GetInfoNhanVien(string manv);
                public Task<IEnumerable<NhanVien>> DeleteNhanVien(string manv);
                public NhanVien GetNhanVienById(string id);
        }
}
