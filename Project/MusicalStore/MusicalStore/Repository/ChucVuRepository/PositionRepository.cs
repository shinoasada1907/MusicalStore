using DTO.IRepository;
using MusicalStore.Mapping;
using MusicalStore.Models;

namespace MusicalStore.Repository.ChucVuRepository
{
    public class PositionRepository : IPositionRepository
    {
        private readonly IChucVuRepository _chucVuRepository;
        public PositionRepository(IChucVuRepository chucVuRepository)
        {
            _chucVuRepository = chucVuRepository;
        }
        public IEnumerable<PositionModel> GetPositions()
        {
            return PositionMapping.MapToPositions(_chucVuRepository.GetAllChucVu());
        }
    }
}
