using DTO.IRepository;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository
{
    public class ChiTietGiamGiaRepository : IChiTietGiamGiaRepository
    {
        private readonly MusicalStoreContext _context;
        public ChiTietGiamGiaRepository(MusicalStoreContext context)
        {
            _context = context;
        }
        public ChiTietGiamGia GetChiTietGiamGia(string masp)
        {
            var chitiet = _context.ChiTietGiamGia.FirstOrDefault(ct => ct.MaSp == masp);

            return chitiet;
        }
    }
}
