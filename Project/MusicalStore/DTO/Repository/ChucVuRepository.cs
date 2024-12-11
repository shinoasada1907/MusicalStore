using DTO.IRepository;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository
{
    public class ChucVuRepository : IChucVuRepository
    {
        private readonly MusicalStoreContext _context;
        public ChucVuRepository(MusicalStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<ChucVu> GetAllChucVu()
        {
            return _context.ChucVus.Select(cv => new ChucVu
            {
                MaCv = cv.MaCv,
                TenCv = cv.TenCv,
                MucLuong = cv.MucLuong
            }).ToList();
        }

        public ChucVu GetChucVu(string macv)
        {
            var chucVu = _context.ChucVus.FirstOrDefault(c => c.MaCv == macv);
            return chucVu;
        }
    }
}
