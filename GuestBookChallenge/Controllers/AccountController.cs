using GuestBookChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace GuestBookChallenge.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context; 
        private readonly IHostingEnvironment _appEnvironment;

        public AccountController(AppDbContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;


        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username != null && password != null)
            {
                var user = _context.Users.FirstOrDefault(a => a.UserName == username && a.Password == password);
                if (user != null)
                {
                    HttpContext.Session.SetInt32("UID", user.Id);
                    return RedirectToAction("Index","Messages");
                }
            }

            ViewBag.error = "Invalid Account";
            return View();

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            var files = HttpContext.Request.Form.Files;
            var fileName = "";
            if (files.FirstOrDefault() != null)
            {
                var pic = files.FirstOrDefault();
                var allowedExten = new List<string> { ".jpg", ".png" };
                if (!allowedExten.Contains(Path.GetExtension(pic.FileName).ToLower()))
                {
                    ModelState.AddModelError("Pic", "Only png and jpg files are allowed");
                    return View(user);
                }
                if (pic.Length > 1048576)
                {
                    ModelState.AddModelError("Pic", "Only can't be more than 1 MB");
                    return View(user);
                }
                var uploads = Path.Combine(_appEnvironment.WebRootPath, "Uploads");

                fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(pic.FileName);
                using var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create);

                pic.CopyTo(fileStream);


            }
            if (ModelState.IsValid)
            {
                user.ProfilePic = fileName;

                _context.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login","Account");
            }
            return View(user);
        }

    }
}
