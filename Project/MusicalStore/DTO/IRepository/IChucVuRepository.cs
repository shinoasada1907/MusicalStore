using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.IRepository
{
    public interface IChucVuRepository
    {
        public ChucVu GetChucVu(string macv);
        public IEnumerable<ChucVu> GetAllChucVu();
    }
}
