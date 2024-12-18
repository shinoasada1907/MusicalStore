using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MusicalStore.Function;
using MusicalStore.Models;
using MusicalStore.Repository.AccountRepository;
using MusicalStore.Repository.StaffRepository;
using MusicalStore.Repository.UserRepository;

namespace MusicalStore.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AuthController(IAccountRepository accountRepository, IUserRepository userRepository, IStaffRepository staffRepository, IWebHostEnvironment webHostEnvironment)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
            _staffRepository = staffRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult RegisterUserInfo(string userId, string email)
        {
            ViewData["CustomerId"] = userId;
            ViewData["Email"] = email;
            return View();
        }
        [HttpGet]
        public IActionResult LoginAccount(string username, string password)
        {

            var account = _accountRepository.LoginAccount(username, password);
            if (account != null)
            {
                if (!string.IsNullOrEmpty(account.CustomerId))
                {
                    var userInfo = _userRepository.GetUserInfor(account.CustomerId);
                    HttpContext.Session.SetString("UserId", account.CustomerId);
                    HttpContext.Session.SetString("UserName", userInfo.UName);
                    HttpContext.Session.SetString("UserAvatar", userInfo.Avatar ?? "");
                    HttpContext.Session.SetString("Email", userInfo.Email);
                    HttpContext.Session.SetString("Address", userInfo.Address);
                    HttpContext.Session.SetString("Phone", userInfo.SDT);
                }

                if (!string.IsNullOrEmpty(account.EmployeeId))
                {
                    var staffInfo = _staffRepository.GetStaffInfo(account.EmployeeId);
                    HttpContext.Session.SetString("StaffId", account.EmployeeId);
                    HttpContext.Session.SetString("StaffName", staffInfo.StaffName);
                    HttpContext.Session.SetString("StaffAvatar", "");
                    HttpContext.Session.SetString("Permission", account.PermissionId);
                }
                return Json(account);
            }
            else
            {
                return Json(null);
            }

        }

        public IActionResult LogOutAccount()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult CheckExistsUser(string username)
        {
            Console.WriteLine(_accountRepository.CheckExistsUser(username));
            return Json(new
            {
                result = _accountRepository.CheckExistsUser(username)
            });
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAccountUser(Account account)
        {
            //account.AccountId = "TK" + FunctionApplication.GenerateId(5);
            //account.CustomerId = "KH" + FunctionApplication.GenerateId(5);
            //account.PermissionId = "PQ03";
            UserModel user = new UserModel { UID = account.CustomerId };
            var customer = await _userRepository.RegisterNewUser(user);
            var acc = await _accountRepository.RegisterAccount(account);
            return Json("Đăng ký thành công");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUserInformation(UserModel user)
        {
            var userInfor = await _userRepository.UpdateNewUser(user);
            HttpContext.Session.SetString("UserId", userInfor.UID);
            HttpContext.Session.SetString("UserName", userInfor.UName);
            HttpContext.Session.SetString("UserAvatar", userInfor.Avatar);
            return Json(userInfor);
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is empty");
            }

            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var fileName = Path.GetFileNameWithoutExtension(file.FileName);
            var fileExtension = Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, file.FileName);
            int counter = 1;

            // Kiểm tra và tạo tên tệp mới nếu tệp đã tồn tại
            while (System.IO.File.Exists(filePath))
            {
                filePath = Path.Combine(uploadsFolder, $"{fileName}_{counter}{fileExtension}");
                counter++;
            }

            // Lưu tệp tin
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Trả về tên tệp đã được lưu
            return Ok(new { FilePath = Path.GetFileName(filePath) });
        }
        [HttpGet]
        public IActionResult GetAccount(string username)
        {
            return Json("");
        }
    }
}
