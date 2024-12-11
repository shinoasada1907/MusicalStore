using DTO.Models;
using MusicalStore.Models;

namespace MusicalStore.Mapping
{
    public class DetailVoucherMapping
    {
        // ChiTietGiamGia -> DetailVoucher
        public static DetailVoucher MapToDetailVoucher(ChiTietGiamGia? chiTietGiamGia)
        {
            return new DetailVoucher
            {
                StartDate = chiTietGiamGia?.NgayBd ?? DateOnly.MinValue,
                EndDate = chiTietGiamGia?.NgayKt ?? DateOnly.MinValue,
                ProductCode = chiTietGiamGia?.MaSp ?? string.Empty,
                VoucherCode = chiTietGiamGia?.MaGg ?? string.Empty
            };
        }

        // DetailVoucher -> ChiTietGiamGia
        public static ChiTietGiamGia MapToChiTietGiamGia(DetailVoucher? detailVoucher)
        {
            return new ChiTietGiamGia
            {
                NgayBd = detailVoucher.StartDate,
                NgayKt = detailVoucher.EndDate,
                MaSp = detailVoucher.ProductCode,
                MaGg = detailVoucher.VoucherCode
            };
        }

        // IEnumerable<ChiTietGiamGia> -> IEnumerable<DetailVoucher>
        public static IEnumerable<DetailVoucher> MapToDetailVouchers(IEnumerable<ChiTietGiamGia> chiTietGiamGias)
        {
            return chiTietGiamGias.Select(chiTiet => MapToDetailVoucher(chiTiet)).ToList();
        }

        // IEnumerable<DetailVoucher> -> IEnumerable<ChiTietGiamGia>
        public static IEnumerable<ChiTietGiamGia> MapToChiTietGiamGias(IEnumerable<DetailVoucher> detailVouchers)
        {
            return detailVouchers.Select(detail => MapToChiTietGiamGia(detail)).ToList();
        }
    }
}
