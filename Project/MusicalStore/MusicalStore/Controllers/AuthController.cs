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
        public AuthController(IAccountRepository accountRepository, IUserRepository userRepository, IStaffRepository staffRepository)
        {
            _accountRepository = accountRepository;
            _userRepository = userRepository;
            _staffRepository = staffRepository;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult RegisterUserInfo(string accountId, string userId)
        {
            Console.WriteLine(accountId + " - " + userId);
            return View();
        }
        [HttpGet]
        public IActionResult LoginAccount(string username, string password)
        {
            var account = _accountRepository.LoginAccount(username, password);
            if (account != null)
            {
                if (account.CustomerId != null)
                {
                    var userInfo = _userRepository.GetUserInfor(account.CustomerId);
                    HttpContext.Session.SetString("UserId", account.CustomerId);
                    HttpContext.Session.SetString("UserName", userInfo.UName);
                    HttpContext.Session.SetString("UserAvatar", "");
                }

                if (account.EmployeeId != null)
                {
                    var staffInfo = _staffRepository.GetStaffInfo(account.EmployeeId);
                    HttpContext.Session.SetString("StaffId", account.EmployeeId);
                    HttpContext.Session.SetString("StaffName", staffInfo.StaffName);
                    HttpContext.Session.SetString("StaffAvatar", "");
                    HttpContext.Session.SetString("Permission", account.PermissionId);
                }
            }

            return Json(account);
        }

        public IActionResult LogOutAccount()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult RegisterAccountUser(Account account)
        {
            account.AccountId = "TK" + FunctionApplication.GenerateId(5);
            account.CustomerId = "KH" + FunctionApplication.GenerateId(5);
            return RedirectToAction("RegisterUserInfo", "Auth", new {accountId = account.AccountId, userId = account.CustomerId});
        }

        [HttpPost]
        public IActionResult RegisterUserInfo(UserModel user)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
