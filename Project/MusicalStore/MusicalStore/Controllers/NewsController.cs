using Microsoft.AspNetCore.Mvc;
using MusicalStore.Data;
using MusicalStore.Models;

namespace MusicalStore.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Blog(int Id)
        {
            // Giả lập dữ liệu bài viết
            var blogPost = NewsData.listNews.FirstOrDefault(x => x.Id == Id);
            return View(blogPost);
        }
    }
}
