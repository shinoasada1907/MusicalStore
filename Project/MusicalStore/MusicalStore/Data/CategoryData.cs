using MusicalStore.Models;

namespace MusicalStore.Data
{
    public class CategoryData
    {
        public static List<Category> categories = new List<Category>
        {
            new Category
            {
                CategoryId = "Cat1",
                CategoryName = "Trống"
            },
            new Category
            {
                CategoryId = "Cat2",
                CategoryName = "Đàn Guitar"
            },
            new Category
            {
                CategoryId = "Cat3",
                CategoryName = "Đàn Piano"
            },
            new Category
            {
                CategoryId = "Cat4",
                CategoryName = "Khác"
            },
        };
    }
}
