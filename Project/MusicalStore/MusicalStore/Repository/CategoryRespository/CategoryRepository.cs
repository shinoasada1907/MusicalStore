using DTO.IRepository;
using DTO.Repository;
using Microsoft.EntityFrameworkCore;
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
            return CategoryMapping.MapToCategories(_loaiSanPhamRepository.GetAllLoaiSanPham());
        }

        public string GetCategoryNameById(string categoryId)
        {
            // Lấy danh mục từ repository
            var loaiSanPham = _loaiSanPhamRepository.GetAllLoaiSanPham()
                                .FirstOrDefault(x => x.MaLsp == categoryId);

            // Trả về tên danh mục hoặc chuỗi rỗng nếu không tồn tại
            return loaiSanPham?.TenLsp ?? string.Empty;
        }
    }
}
