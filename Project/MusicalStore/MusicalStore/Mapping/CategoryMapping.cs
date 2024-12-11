using DTO.Models;
using MusicalStore.Models;

namespace MusicalStore.Mapping
{
    public class CategoryMapping
    {
        public static Category MapToCategory(LoaiSanPham? loaisanPham)
        {
            return new Category
            {
                CategoryId = loaisanPham?.MaLsp ?? string.Empty,
                CategoryName = loaisanPham?.TenLsp ?? string.Empty,
            };
        }

        public static LoaiSanPham MapToLoaiSanPham(Category category)
        {
            return new LoaiSanPham
            {
                MaLsp = category.CategoryId,
                TenLsp = category.CategoryName,
            };
        }

        public static IEnumerable<Category> MapToCategorys(IEnumerable<LoaiSanPham> loaisanPhams)
        {
            return loaisanPhams.Select(loaisanpham => MapToCategory(loaisanpham)).ToList();
        }
    }
}
