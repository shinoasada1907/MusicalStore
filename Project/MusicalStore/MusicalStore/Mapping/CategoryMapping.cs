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
                TenLsp = category.CategoryName
            };
        }

        // IEnumerable<LoaiSanPham> -> IEnumerable<Category>
        public static IEnumerable<Category> MapToCategories(IEnumerable<LoaiSanPham> loaiSanPhams)
        {
            return loaiSanPhams.Select(loaiSanPham => MapToCategory(loaiSanPham)).ToList();
        }

        // IEnumerable<Category> -> IEnumerable<LoaiSanPham>
        public static IEnumerable<LoaiSanPham> MapToLoaiSanPhams(IEnumerable<Category> categories)
        {
            return categories.Select(category => MapToLoaiSanPham(category)).ToList();
        }
    }
}
