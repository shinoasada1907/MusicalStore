using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.IRepository
{
    public interface ILoaiSanPhamRepository
    {
        public LoaiSanPham GetLoaiSanPham(string malsp);
        public IEnumerable<LoaiSanPham> GetAllLoaiSanPham();
    }
}
