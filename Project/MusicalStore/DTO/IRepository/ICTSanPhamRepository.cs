using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.IRepository
{
    public interface ICTSanPhamRepository
    {
        public CtSanPham GetCTSanPham(string masp);
        public Task<IEnumerable<CtSanPham>> AddNewCtSanPham(CtSanPham ctsanpham);
        public Task<IEnumerable<CtSanPham>> UpdateCtSanPham(CtSanPham ctsanpham);
        public Task<IEnumerable<CtSanPham>> DeleteCtSanPham(string mactsp);

    }
}
