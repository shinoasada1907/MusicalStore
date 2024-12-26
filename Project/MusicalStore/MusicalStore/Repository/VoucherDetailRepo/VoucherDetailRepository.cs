using DTO.IRepository;
using MusicalStore.Models;
using MusicalStore.Repository.VoucherDetailRepo;

namespace MusicalStore.Repository.VoucherDetailRepo
{
    public class VoucherDetailRepository : IVoucherDetailRepository
    {
        private readonly IChiTietGiamGiaRepository _chiTietGiamGiaRepository;
        public VoucherDetailRepository(IChiTietGiamGiaRepository chiTietGiamGiaRepository)
        {
            _chiTietGiamGiaRepository = chiTietGiamGiaRepository;
        }
            public VoucherDetail GetVoucherProduct(string productId)
        {
            throw new NotImplementedException();
        }
    }
}
