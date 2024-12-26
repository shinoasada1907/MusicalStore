using MusicalStore.Models;

namespace MusicalStore.Repository.VoucherRepo
{
    public interface IVoucherRepository
    {
        public Voucher GetVoucherById(string voucherId);
    }
}
