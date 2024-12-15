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

        //Them PTTT
        public async Task<IEnumerable<PtThanhToan>> AddNewPtThanhToan(PtThanhToan ptthanhtoan)
        {
            _context.PtThanhToans.Add(ptthanhtoan);
            await _context.SaveChangesAsync();

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

        //Xoa PTTT
         public async Task<IEnumerable<PtThanhToan>> DeletePtThanhToan(string mapttt)
        {
            var ptthanhtoan = _context.PtThanhToans.FirstOrDefault(pttt => pttt.MaPttt == mapttt);
            _context.PtThanhToans.Remove(ptthanhtoan);
            await _context.SaveChangesAsync();

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
        //Cap nhat PTTT
        public async Task<IEnumerable<PtThanhToan>> UpdatePtThanhToan(PtThanhToan ptthanhtoan)
        {
            _context.PtThanhToans.Update(ptthanhtoan);
            await _context.SaveChangesAsync();

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

        //Lay danh sach PTTT
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
        public PtThanhToan GetPtThanhToanById(string id)
        {
            return _context.PtThanhToans.FirstOrDefault(pttt => pttt.MaPttt == id);
        }
    }
}
