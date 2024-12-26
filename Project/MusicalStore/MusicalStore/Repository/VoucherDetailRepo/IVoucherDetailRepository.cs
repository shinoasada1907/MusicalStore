using MusicalStore.Models;

namespace MusicalStore.Repository.VoucherDetailRepo
{
    public interface IVoucherDetailRepository
    {
        public VoucherDetail GetVoucherProduct(string productId);
    }
}
