using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuestBookChallenge.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace GuestBookChallenge.Controllers
{
    public class MessagesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _appEnvironment;
        Respone respone = new Respone();
        public MessagesController(AppDbContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            var uid = HttpContext.Session.GetInt32("UID");
            if (uid == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewData["UserId"] = uid;
            var appDbContext = _context.Messages.Include(m => m.User).ThenInclude(m => m.Replies).ToList();
            return View(appDbContext);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = _context.Messages
                .Include(m => m.User)
                .FirstOrDefault(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        //public IActionResult Create()
        //{
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name");
        //    return View();
        //}

        [HttpPost]
        public IActionResult Create(Message message)
        {
            try
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
                        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", message.UserId);
                        return View(message);
                    }
                    if (pic.Length > 1048576)
                    {
                        ModelState.AddModelError("Pic", "Only can't be more than 1 MB");
                        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", message.UserId);
                        return View(message);
                    }
                    var uploads = Path.Combine(_appEnvironment.WebRootPath, "Uploads");

                    fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(pic.FileName);
                    using var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create);

                    pic.CopyTo(fileStream);


                }
                if (ModelState.IsValid)
                {
                    message.CreatedDate = DateTime.Now;
                    message.Pic = fileName;
                    _context.Add(message);
                    _context.SaveChanges();
                }
                respone.response = message.Id;
                respone.msg = "saved";
                return Json(respone);
            }
            catch (Exception ex)
            {
                respone.response = -1;
                respone.msg = "error";
                return Json(respone);
            }

        }
        [HttpPost]
        public IActionResult AddReply(ReplyVM reply)
        {
            try
            {
                var files = HttpContext.Request.Form.Files;
                var fileName = "";
                if (files.FirstOrDefault() != null)
                {
                    var pic = files.FirstOrDefault();
                    var allowedExten = new List<string> { ".jpg", ".png" };

                    var uploads = Path.Combine(_appEnvironment.WebRootPath, "Uploads");

                    fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(pic.FileName);
                    using var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create);

                    pic.CopyTo(fileStream);


                }
                var replyObj = new Reply();
                replyObj.Body = reply.Body;
                replyObj.MessageId = reply.MessageId;
                replyObj.UserId = reply.UserId;
                replyObj.CreatedDate = DateTime.Now;
                replyObj.Pic = fileName;

                _context.Add(replyObj);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //log exception
                return Json("0");
            }

            return Json("1");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = _context.Messages.Find(id);
            if (message == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", message.UserId);
            return View(message);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,Body,UserId")] Message message)
        {
            if (id != message.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(message);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MessageExists(message.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", message.UserId);
            return View(message);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = _context.Messages
                .Include(m => m.User)
                .FirstOrDefault(m => m.Id == id);
            if (message == null)
            {
                return NotFound();
            }

            return View(message);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var message = _context.Messages.Find(id);
            var replies = _context.Replys.Where(a => a.MessageId == id);

            _context.Replys.RemoveRange(replies);

            _context.Messages.Remove(message);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool MessageExists(int id)
        {
            return _context.Messages.Any(e => e.Id == id);
        }


        [HttpGet]
        public IActionResult GetData(int? id = 2)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reply = _context.Replys.Where(a => a.MessageId == id).Include(a => a.User).ToList();
            if (reply == null)
            {
                return NotFound();
            }

            return PartialView("_reply", reply);


        }
        [HttpGet]
        public IActionResult GetMessage(int? id = 2)
        {
            if (id == null)
            {
                return NotFound();
            }

            var message = _context.Messages.Where(a => a.Id == id).Include(a => a.User).ThenInclude(a => a.Replies).FirstOrDefault();
            if (message == null)
            {
                return NotFound();
            }
            var uid = HttpContext.Session.GetInt32("UID");

            ViewData["UserId"] = uid;

            return PartialView("_Message", message);


        }
    }
    public class ReplyVM
    {
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public string Body { get; set; }
        public string Pic { get; set; }
    }
}
