using GuestBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuestBook.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        public AccountController(AppDbContext context)
        {
            _context = context;
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
                    HttpContext.Session.SetString("username", username);
                    return View("Success");
                }
            }

            ViewBag.error = "Invalid Account";
            return View("Index");

        }
        [HttpGet]
        public IActionResult Register() { 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

    }
}
