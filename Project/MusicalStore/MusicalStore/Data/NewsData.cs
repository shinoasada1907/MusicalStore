using MusicalStore.Models;

namespace MusicalStore.Data
{
    public class NewsData
    {
        public static List<BlogPost> listNews = new List<BlogPost>()
        {
            new BlogPost
            {
                Id = 1,
                Title = "CONCERT GHIBLI IN TOWN",
                Content = @"
                    <p>🎶 Bạn là fan âm nhạc chữa lành đến từ nhà Ghibli? Bạn yêu thích những giai điệu du dương, đầy cảm xúc trong từng thước phim của Hayao Miyazaki?</p>
                    <h3>1.  𝐒𝐚𝐢𝐠𝐨𝐧 𝐖𝐢𝐧𝐝𝐬</h3>
                    <p>⛩ GHIBLI IN TOWN 2024 đã chính thức trở lại sau sự đón nhận nồng nhiệt của khán giả từ concert năm 2023. Cũng trong concert lần này, 𝐒𝐚𝐢𝐠𝐨𝐧 𝐖𝐢𝐧𝐝𝐬 hân hạnh chào đón sự trở lại của dàn hợp xướng hàng đầu Việt Nam - 𝐒𝐚𝐢𝐠𝐨𝐧 𝐂𝐡𝐨𝐢𝐫.</p>
                    <h3>2. Những giai điệu quen thuộc</h3>
                    <p>GHIBLI IN TOWN 2024 sẽ tiếp tục đưa khán giả đắm chìm trong những giai điệu thân thuộc đầy hoài niệm, nhưng vẫn đầy mới lạ và thú vị với các bản phối hoàn toàn mới từ các bộ phim hoạt hình nổi tiếng như: 𝑇𝑜𝑡𝑜𝑟𝑜, 𝑆𝑝𝑖𝑟𝑖𝑡𝑒𝑑 𝐴𝑤𝑎𝑦, 𝑀𝑜𝑛𝑜𝑘𝑒, 𝑃𝑜𝑟𝑐𝑜 𝑅𝑜𝑠𝑠𝑜, 𝑁𝑎𝑢𝑠𝑖𝑐𝑎𝑎̈ 𝑜𝑓 𝑡ℎ𝑒 𝑉𝑎𝑙𝑙𝑒𝑦 𝑜𝑓 𝑡ℎ𝑒 𝑊𝑖𝑛𝑑, 𝐾𝑖𝑘𝑖'𝑠 𝐷𝑒𝑙𝑖𝑣𝑒𝑟𝑦 𝑆𝑒𝑟𝑣𝑖𝑐𝑒, 𝑃𝑜𝑛𝑦𝑜,...</p>
                    <h3>3. Thông tin chi tiết</h3>
                    <p>⏰Thời gian: 20:00, ngày 02-03-04.8.2024
🏦Địa điểm: Phòng Hòa Nhạc - Nhạc Viện TP Hồ Chí Minh, 112 Nguyễn Du, Phường Bến Thành, Quận 1, TPHCM</p>",
                Author = "Nh Y Music",
                PublishedDate = Convert.ToDateTime("19/10/2024"),
                ImageUrl = "/images/ghibli.png"
            },


            new BlogPost
            {
                Id = 2,
                Title = "Expecto Patronum! CONCERT OF CHILDHOOD MEMORY",
                Content = @"
                    <p>CONCERT OF CHILDHOOD MEMORY - PATRONUM CHÍNH THỨC TRỞ LẠI VÀO THÁNG 7 NÀY!!!</p>
                    <h3>Harry Potter - Expecto Patronum</h3>
                    <p>⚡️Lấy cảm hứng từ câu thần chú trong Harry Potter - Expecto Patronum, năm nay Concert of Childhood Memory 2022 tiếp tục mở ra thế giới của phép thuật. Thế giới ấy có thể sẽ thách thức hơn, nhiều điều bất ngờ hơn nhưng cũng sẽ diệu kỳ và phi thường!</p>
                    <h3>Thần hộ mệnh</h3>
                    <p>⚡️ Và để gọi tên ""Thần hộ mệnh"" của chính mình, hãy cùng chậm lại và nhìn thật sâu vào bên trong. Giống như những nhân vật trong chuỗi phim Harry Potter, Concert of Childhood Memory cũng là những đứa trẻ lần đầu tập lớn. Trong quá trình trưởng thành chúng mình nhận ra thế giới phép thuật không chỉ có sự sống động rực rỡ, mà còn có cả những tổn thương những rào cản ngăn mình chạm vào hạnh phúc. Chúng mình tin rằng, hạnh phúc không phải là đích đến. Hạnh phúc là một quá trình thực hành để nhận ra mọi khoảnh khắc đều có thể lóe sáng và trở thành một ký ức tươi đẹp. Dù chắc chắn sẽ phải đối mặt với không ít những phút giây lạc đường trong đêm tối, nhưng ""đứa trẻ bên trong mỗi người"" sẽ là nguồn suối vô tận giúp gợi nhớ và bảo vệ những kí ức sâu thăm bên trong; và âm nhạc chính là chất xúc tác tuyệt diệu nhất giúp chúng ta triệu hồi những cảm xúc ấy.</p>
                    <h3>Expecto Patronum! Hãy để ánh sáng bên trong bạn được thắp lên!</h3>
                    <p>⚡️ Trải qua 7 năm cùng các bạn lớn, chúng mình tin rằng đã có những giây phút hạnh phúc được chia sẻ giữa chúng ta. Đối với Concert of Childhood Memory, “thần hộ mệnh” mang dáng vẻ của những giai điệu, của giọt nước mắt lăn trên má, nụ cười trên đôi môi các bạn.

⚡️ Mượn những ký ức, vẽ lại những kỷ niệm, tô màu cho cảm xúc, chơi lên những thanh âm, Concert of Childhood Memory Patronum liệu có thể khơi gợi lại những khoảnh khắc tươi đẹp nhất trong bạn?

Expecto Patronum! Hãy để ánh sáng bên trong bạn được thắp lên!</p>",
                Author = "Nh Y Music",
                PublishedDate = Convert.ToDateTime("03/07/2024"),
                ImageUrl = "/images/harrypotter.jpg"
            },
             new BlogPost
            {
                Id = 3,
                Title = "SUNGHA JUNG CONCERT TẠI VIỆT NAM",
                Content = @"
                    <p>Tự sáng tác và chuyển soạn rất nhiều bản nhạc với phong cách đa dạng, Sungha Jung đã phát hành album solo thứ 10 “All The Best” ra mắt tháng 8/2024.
Đây là năm thứ 7 Sungha Jung có tour diễn tại Việt Nam.</p>
                    <h3>1. Fingerstyle</h3>
                    <p>Thể loại guitar độc tấu mới mẻ, phát triển mạnh tại Việt Nam trong những năm gần đây. Mô tả đơn giản, đó là chỉ với một cây guitar người chơi có thể mang đến âm thanh của cả một ban nhạc (one-man band). Fingerstyle tạo ra cái nhìn hoàn toàn mới về cây guitar và đang thu hút sự quan tâm của cộng đồng đối với nền guitar của nước ta hiện nay.</p>
                    <h3>2. Sungha Jung</h3>
                    <p>Chơi guitar từ khi 10 tuổi, Sungha Jung được mệnh danh là “Thần đồng guitar Hàn Quốc” và đã sớm trở nên nổi tiếng, đặc biệt trên YouTube với hơn 991 triệu lượt view và trên 3 triệu người theo dõi (tính đến tháng 4.2015). Trong số 15 giải thưởng anh đã đạt được trên YouTube, có đến 6 giải “No.1”.
Tự sáng tác và chuyển soạn rất nhiều bản nhạc với phong cách đa dạng, Sungha Jung đã phát hành album solo thứ 10 “All The Best” ra mắt tháng 8/2024.
Đây là năm thứ 7 Sungha Jung có tour diễn tại Việt Nam.</p>
                    <h3>3. All The Best</h3>
                    <p>Album đánh dấu cột mốc album solo thứ 10 của Sungha Jung sẽ được bày bán tại concert. Các hạng vé package và VIP đã bao gồm album đi kèm. </p>",
                Author = "Nh Y Music",
                PublishedDate = Convert.ToDateTime("10/9/2024"),
                ImageUrl = "/images/sunghajung.jpg"
            },
            
         
            new BlogPost
            {
                Id = 4,
                Title = "Pop Ballad Revolution: Những Giải Pháp Khi Đệm Guitar",
                Content = @"
                    <p>Pop Ballad là một thể loại nhạc phổ biến và được rất nhiều người yêu thích khi chơi guitar. Tuy nhiên, để đạt được hiệu quả tốt nhất khi đệm guitar cho dòng nhạc này, bạn cần chú ý đến một số yếu tố.</p>
                    <h3>1. Chọn nhạc cụ phù hợp</h3>
                    <p>Việc chọn lựa một cây guitar phù hợp là yếu tố quan trọng nhất để bạn có thể tạo nên những giai điệu ballad sâu lắng và truyền cảm. Dù là dòng acoustic với âm thanh ấm áp, tự nhiên hay classic guitar với âm sắc cổ điển, bạn đều có thể tìm thấy một cây đàn phù hợp để thể hiện phong cách riêng. Hãy cân nhắc kỹ về chất liệu gỗ, kích thước đàn và loại dây đàn để chọn được cây đàn ưng ý nhất. Đừng ngần ngại đến các cửa hàng nhạc cụ để được tư vấn trực tiếp hoặc tham khảo ý kiến của những người có kinh nghiệm..</p>
                    <h3>2. Luyện tập cách giữ nhịp</h3>
                    <p>Nhịp điệu ổn định là yếu tố cốt lõi để giữ được cảm xúc và chất lượng của bài hát ballad khi đệm. Mỗi nhịp phách đều cần được nhấn nhá rõ ràng, giúp người nghe dễ dàng hòa mình vào câu chuyện mà bài hát kể. Nhịp điệu chậm rãi, đều đặn sẽ tạo nên không gian trầm lắng, phù hợp với những ca khúc ballad buồn. Để có thể chơi ballad một cách chuyên nghiệp, bạn cần phải luyện tập nhịp điệu một cách thường xuyên. Việc giữ nhịp ổn định không chỉ giúp bạn chơi đàn chính xác hơn mà còn giúp bạn tự tin hơn khi biểu diễn.</p>
                    <h3>3. Thực hành các kỹ thuật cơ bản</h3>
                    <p>Arpeggio và strumming không chỉ là những kỹ thuật cơ bản mà còn là nền tảng để tạo nên những bản Pop Ballad đa dạng và phong phú. Bằng cách kết hợp linh hoạt các pattern arpeggio và strumming khác nhau, bạn có thể tạo ra những giai điệu độc đáo, từ những đoạn intro nhẹ nhàng, sâu lắng đến những đoạn chorus sôi động, đầy năng lượng. Để thành thạo arpeggio và strumming, đòi hỏi bạn phải luyện tập thường xuyên và kiên trì. Bằng cách luyện tập các bài tập cơ bản, bạn sẽ dần làm quen với các pattern và có thể sáng tạo ra những pattern riêng của mình.</p>",
                Author = "Nh Y Music",
                PublishedDate = Convert.ToDateTime("03/07/2024"),
                ImageUrl = "/images/pop-ballad-revolution.jpg"
            },
        };
    }
}
