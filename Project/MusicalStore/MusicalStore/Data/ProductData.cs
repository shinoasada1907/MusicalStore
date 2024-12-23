using MusicalStore.Models;

namespace MusicalStore.Data
{
    public class ProductData
    {
        public static List<Product> ProductsSale = new List<Product>
        {
            //GetTopSellingProducts()
            new Product
            {
                ProductCode = Guid.NewGuid().ToString(),
                ProductName = "Yamaha P-45",
                Description = "Đàn piano điện Yamaha P-45 với thiết kế nhỏ gọn, phù hợp cho cả người mới học và người chơi chuyên nghiệp.",
                ImageUrl = "Piano/Yamaha_P45.jpg",
                CategoryCode = "Cat1",
                Price = 15000000
            },
            new Product
            {
                ProductCode = Guid.NewGuid().ToString(),
                ProductName = "Roland FP-30X",
                Description = "Roland FP-30X cung cấp âm thanh và bàn phím đẳng cấp, lý tưởng cho việc biểu diễn và luyện tập.",
                ImageUrl = "Piano/Roland_FP30X.jpg",
                CategoryCode = "Cat1",
                Price = 18000000
            },
            new Product
            {
                ProductCode = Guid.NewGuid().ToString(),
                ProductName = "Kawai GL-10",
                Description = "Đàn piano cơ Kawai GL-10 mang đến âm thanh tuyệt hảo và thiết kế tinh tế.",
                ImageUrl = "Piano/Kawai_GL10.jpg",
                CategoryCode = "Cat3",
                Price = 82000000
            },
            new Product
            {
                ProductCode = Guid.NewGuid().ToString(),
                ProductName = "Casio PX-870",
                Description = "Đàn piano điện Casio PX-870 với thiết kế sang trọng và công nghệ âm thanh hiện đại.",
                ImageUrl = "Piano/Casio_PX870.jpg",
                CategoryCode = "Cat1",
                Price = 14000000
            }
        };

        public static List<Product> ListProduct = new List<Product>
        {
            new Product
            {
                ProductCode = Guid.NewGuid().ToString(),
                ProductName = "Yamaha PSR-E373",
                Description = "Đàn organ Yamaha PSR-E373 phù hợp cho người mới học, với đa dạng âm thanh và tính năng.",
                ImageUrl = "Organ/Yamaha_PSR_E373.jpg",
                CategoryCode = "Cat2",
                Price = 8000000
            },
            new Product
            {
                ProductCode = Guid.NewGuid().ToString(),
                ProductName = "Korg B2",
                Description = "Đàn piano điện Korg B2 với âm thanh chất lượng cao, thích hợp cho cả người học và người chơi chuyên nghiệp.",
                ImageUrl = "Piano/Korg_B2.jpg",
                CategoryCode = "Cat1",
                Price = 12000000
            },
            new Product
            {
                ProductCode = Guid.NewGuid().ToString(),
                ProductName = "Casio CDP-S150",
                Description = "Casio CDP-S150 với thiết kế siêu gọn nhẹ và bàn phím mô phỏng đàn piano cơ.",
                ImageUrl = "Piano/Casio_CDP_S150.jpg",
                CategoryCode = "Cat1",
                Price = 11000000
            },
            new Product
            {
                ProductCode = Guid.NewGuid().ToString(),
                ProductName = "Roland RP102",
                Description = "Đàn piano điện Roland RP102 là sự lựa chọn hoàn hảo cho người mới bắt đầu và gia đình.",
                ImageUrl = "Piano/Roland_RP102.jpg",
                CategoryCode = "Cat1",
                Price = 20000000
            },
            new Product
            {
                ProductCode = Guid.NewGuid().ToString(),
                ProductName = "Kawai KDP120",
                Description = "Đàn piano điện Kawai KDP120 với âm thanh trung thực và thiết kế sang trọng.",
                ImageUrl = "Piano/Kawai_KDP120.jpg",
                CategoryCode = "Cat1",
                Price = 18000000
            },
            new Product
            {
                ProductCode = Guid.NewGuid().ToString(),
                ProductName = "Yamaha CLP-735",
                Description = "Yamaha CLP-735 thuộc dòng Clavinova nổi tiếng, mang lại trải nghiệm chơi piano như đàn cơ thực sự.",
                ImageUrl = "Piano/Yamaha_CLP735.jpg",
                CategoryCode = "Cat3",
                Price = 45000000
            },
            new Product
            {
                ProductCode = Guid.NewGuid().ToString(),
                ProductName = "Casio Privia PX-S3000",
                Description = "Casio Privia PX-S3000 với thiết kế mỏng nhất thế giới, đầy đủ tính năng biểu diễn chuyên nghiệp.",
                ImageUrl = "Piano/Casio_PX_S3000.jpg",
                CategoryCode = "Cat1",
                Price = 18000000
            }
        };
    }
}
