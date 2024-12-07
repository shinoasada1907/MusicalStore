using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.IRepository
{
    public interface ISanPhamRepository
    {
        public IEnumerable<SanPham> GetListSanpham();
        public SanPham GetSanPhamById(string id);
    }
}
