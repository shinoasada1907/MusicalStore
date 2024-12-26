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
                public Task<IEnumerable<SanPham>> AddNewSanPham(SanPham sanpham);
                public Task<IEnumerable<SanPham>> UpdateSanPham(SanPham sanpham);
                public Task<IEnumerable<SanPham>> DeleteSanPham(string masp);
                public IEnumerable<SanPham> GetTopSaleSanPham();
                public IEnumerable<SanPham> GetTopSellingProductsInMonth();
                public IEnumerable<SanPham> GetListSanPhamByCategory(string category);
                public IEnumerable<SanPham> GetCollectionProduct(string categoryName);

        }
}
