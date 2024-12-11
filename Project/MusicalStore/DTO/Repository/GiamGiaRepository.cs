using DTO.IRepository;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Repository
{
    public class GiamGiaRepository : IGiamGiaRepository
    {
        private readonly MusicalStoreContext _context;
        public GiamGiaRepository(MusicalStoreContext context)
        {
            _context = context;
        }
        public IEnumerable<MaGiamGia> GetAllMaGiamGia()
        {
            throw new NotImplementedException();
        }

        public MaGiamGia GetMaGiamGia(string magiam)
        {
            var giamGia = _context.MaGiamGia.FirstOrDefault(mg => mg.MaGg == magiam);
            return giamGia;
        }
    }
}
