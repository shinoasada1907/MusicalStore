using DTO.Models;
using MusicalStore.Models;

namespace MusicalStore.Mapping
{
    public class VoucherMapping
    {
        // MaGiamGia -> Voucher
        public static Voucher MapToVoucher(MaGiamGia? maGiamGia)
        {
            return new Voucher
            {
                VoucherCode = maGiamGia?.MaGg ?? string.Empty,
                DiscountValue = maGiamGia?.GiaTriGiam ?? 0,
                Description = maGiamGia?.ChiTiet ?? string.Empty
            };
        }

        // Voucher -> MaGiamGia
        public static MaGiamGia MapToMaGiamGia(Voucher voucher)
        {
            return new MaGiamGia
            {
                MaGg = voucher.VoucherCode,
                GiaTriGiam = voucher.DiscountValue,
                ChiTiet = voucher.Description
            };
        }

        // IEnumerable<MaGiamGia> -> IEnumerable<Voucher>
        public static IEnumerable<Voucher> MapToVouchers(IEnumerable<MaGiamGia> maGiamGias)
        {
            return maGiamGias.Select(maGiamGia => MapToVoucher(maGiamGia)).ToList();
        }

        // IEnumerable<Voucher> -> IEnumerable<MaGiamGia>
        public static IEnumerable<MaGiamGia> MapToMaGiamGias(IEnumerable<Voucher> vouchers)
        {
            return vouchers.Select(voucher => MapToMaGiamGia(voucher)).ToList();
        }
    }
}
