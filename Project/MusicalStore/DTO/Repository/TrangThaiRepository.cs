using DTO.IRepository;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository
{
    public class TrangThaiRepository : ITrangThaiRepository
    {
        private readonly MusicalStoreContext _context;
        public TrangThaiRepository(MusicalStoreContext context)
        {
            _context = context;
        }
        public IEnumerable<TinhTrang> GetAllTrangThai()
        {
            try
            {
                var tt = _context.TinhTrangs.Select(tt => new TinhTrang
                {
                    MaTt = tt.MaTt,
                    TenTt = tt.TenTt
                }).ToList();
                return tt;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }

        }

        public TinhTrang GetTrangThaiById(int id)
        {
            try
            {
                var tt = _context.TinhTrangs.FirstOrDefault(t => t.MaTt == id);
                return tt!;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}
