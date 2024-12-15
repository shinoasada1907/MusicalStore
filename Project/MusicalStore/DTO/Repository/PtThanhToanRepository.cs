using DTO.IRepository;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository
{
    public class PtThanhToanRepository : IPtThanhToanRepository
    {
        private readonly MusicalStoreContext _context;
        public PtThanhToanRepository(MusicalStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<PtThanhToan> GetListPtThanhToan()
        {
            return _context.PtThanhToans.Select(pttt => new PtThanhToan
            {
                MaPttt = pttt.MaPttt,
                HinhThuc = pttt.HinhThuc,
                Sdt = pttt.Sdt,
                TenNhan = pttt.TenNhan,
                NganHang = pttt.NganHang,
                Stk = pttt.Stk,
            }).ToList();
        }
    }
}
