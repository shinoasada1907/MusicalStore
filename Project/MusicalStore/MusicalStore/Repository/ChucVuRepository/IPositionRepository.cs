using MusicalStore.Models;

namespace MusicalStore.Repository.ChucVuRepository
{
    public interface IPositionRepository
    {
        public IEnumerable<PositionModel> GetPositions();
    }
}
