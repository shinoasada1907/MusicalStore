using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.IRepository
{
    public interface IChiTietDHRepository
    {
        public Task<IEnumerable<CtDonHang>> TaoChiTietDonHang(List<CtDonHang> ctDonHang);
    }
}
