using DTO.IRepository;
using MusicalStore.Models;

namespace MusicalStore.Repository.VoucherRepo
{ 
    public class VoucherRepository : IVoucherRepository
    {
        private readonly IGiamGiaRepository _giamGiaRepository;
        public VoucherRepository(IGiamGiaRepository giamGiaRepository)
        {
            _giamGiaRepository = giamGiaRepository;
        }
        public Voucher GetVoucherById(string voucherId)
        {
            throw new NotImplementedException();
        }
    }
}
