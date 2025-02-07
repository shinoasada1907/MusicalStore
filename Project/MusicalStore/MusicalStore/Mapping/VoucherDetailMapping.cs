using DTO.Models;
using MusicalStore.Models;

namespace MusicalStore.Mapping
{
    public class VoucherDetailMapping
    {
        // Map ChiTietGiamGia to VoucherDetail
        public static VoucherDetail ToVoucherDetail(ChiTietGiamGia chiTietGiamGia)
        {
            if (chiTietGiamGia == null) throw new ArgumentNullException(nameof(chiTietGiamGia));

            return new VoucherDetail
            {
                StartDate = chiTietGiamGia.NgayBd,
                EndDate = chiTietGiamGia.NgayKt,
                ProductCode = chiTietGiamGia.MaSp,
                VoucherCode = chiTietGiamGia.MaGg
            };
        }

        // Map VoucherDetail to ChiTietGiamGia
        public static ChiTietGiamGia ToChiTietGiamGia(VoucherDetail voucherDetail)
        {
            if (voucherDetail == null) throw new ArgumentNullException(nameof(voucherDetail));

            return new ChiTietGiamGia
            {
                NgayBd = voucherDetail.StartDate,
                NgayKt = voucherDetail.EndDate,
                MaSp = voucherDetail.ProductCode,
                MaGg = voucherDetail.VoucherCode
            };
        }
    }
}
