using DTO.IRepository;
using DTO.Repository;
using MusicalStore.Mapping;
using MusicalStore.Models;

namespace MusicalStore.Repository.CategoryRespository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ILoaiSanPhamRepository _loaiSanPhamRepository;

        public CategoryRepository(ILoaiSanPhamRepository loaiSanPhamRepository)
        {
            _loaiSanPhamRepository = loaiSanPhamRepository;
        }

        public IEnumerable<Category> GetCategorys()
        {
            return CategoryMapping.MapToCategorys(_loaiSanPhamRepository.GetAllLoaiSanPham());
        }
    }
}
