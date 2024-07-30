using Azure.Identity;
using LocalStorageVaCookies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics;

namespace LocalStorageVaCookies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDBContext _dbContext;
        public HomeController(ILogger<HomeController> logger, MyDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            //trước khi truy cập index => lấy cookies có sẵn
            var duLieuNguoiDung = Request.Cookies["user"];
            ViewBag.DuLieuNguoiDung = duLieuNguoiDung;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([Bind("UserName,Password")] string username, string password)
        {
            bool isFound = _dbContext.Users.Any(x => x.UserName.Equals(username) && x.Password.Equals(username));
            if (isFound == true)
            {
                //Khởi tạo cookies
                CookieOptions options = new CookieOptions();
                //set thời gian hết hạn của cookies
                options.Expires = DateTimeOffset.Now.AddDays(1); //Tính từ lúc bấm login, thời gian hết hạn sẽ + 1 ngày
                Response.Cookies.Append("user", username);
                return View("Index");
            }     
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
