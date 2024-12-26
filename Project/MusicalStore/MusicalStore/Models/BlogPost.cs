namespace MusicalStore.Models
{
    public class BlogPost
    {
        public int Id { get; set; } // Mã bài viết
        public string Title { get; set; } = string.Empty; // Tiêu đề bài viết
        public string Content { get; set; } = string.Empty; // Nội dung bài viết
        public string Author { get; set; } = string.Empty; // Tác giả bài viết
        public DateTime PublishedDate { get; set; } // Ngày xuất bản
        public string ImageUrl { get; set; } = string.Empty; // Đường dẫn ảnh minh họa
    }
}
