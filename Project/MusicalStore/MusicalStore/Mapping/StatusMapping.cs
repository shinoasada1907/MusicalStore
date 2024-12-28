using DTO.Models;
using MusicalStore.Models;

namespace MusicalStore.Mapping
{
    public class StatusMapping
    {
        public static StatusModel MapToStatusModel(TinhTrang? tinhTrang)
        {
            return new StatusModel
            {
                StatusId = tinhTrang!.MaTt.ToString(),
                StatusName = tinhTrang.TenTt
            };
        }

        public static TinhTrang MapToTinhTrang(StatusModel? status)
        {
            return new TinhTrang
            {
                MaTt = Convert.ToInt32(status!.StatusId ?? "0"),
                TenTt = status.StatusName
            };
        }

        public static IEnumerable<StatusModel> MapToStatuses(IEnumerable<TinhTrang> tinhTrangs)
        {
            return tinhTrangs.Select(tinhTrang => MapToStatusModel(tinhTrang)).ToList();
        }
    }
}
