using Microsoft.AspNetCore.Mvc;

namespace MusicalStore.Controllers
{
    public class AuthController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult RegisterUserInfo()
        {
            return View();
        }
        public IActionResult LoginAccount(string username, string password)
        {
            return View();
        }
    }
}
