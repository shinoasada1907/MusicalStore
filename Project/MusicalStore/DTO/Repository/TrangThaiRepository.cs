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
        public IEnumerable<TinhTrang> GetAllTrangThai()
        {
            throw new NotImplementedException();
        }
    }
}
