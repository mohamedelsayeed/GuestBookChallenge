//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using GuestBookChallenge.Models;
//using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

//namespace GuestBookChallenge.Controllers
//{
//    public class RepliesController : Controller
//    {
//        private readonly AppDbContext _context;
//        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _appEnvironment;

//        public RepliesController(AppDbContext context, IHostingEnvironment appEnvironment)
//        {
//            _context = context;
//            _appEnvironment = appEnvironment;
//        }


//        public IActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var reply = _context.Replys
//                .Include(r => r.Message)
//                .Include(r => r.User)
//                .FirstOrDefault(m => m.Id == id);
//            if (reply == null)
//            {
//                return NotFound();
//            }

//            return View(reply);
//        }


//        // POST: Replies/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       

//        // GET: Replies/Edit/5
//        public IActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var reply = _context.Replys.Find(id);
//            if (reply == null)
//            {
//                return NotFound();
//            }
//            ViewData["MessageId"] = new SelectList(_context.Messages, "Id", "Body", reply.MessageId);
//            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", reply.UserId);
//            return View(reply);
//        }


//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Edit(int id, [Bind("Id,Body,Pic,UserId,MessageId")] Reply reply)
//        {
//            if (id != reply.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(reply);
//                    _context.SaveChanges();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ReplyExists(reply.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["MessageId"] = new SelectList(_context.Messages, "Id", "Body", reply.MessageId);
//            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", reply.UserId);
//            return View(reply);
//        }

//        public IActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var reply = _context.Replys
//                .Include(r => r.Message)
//                .Include(r => r.User)
//                .FirstOrDefault(m => m.Id == id);
//            if (reply == null)
//            {
//                return NotFound();
//            }

//            return View(reply);
//        }

//        // POST: Replies/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public IActionResult DeleteConfirmed(int id)
//        {
//            var reply = _context.Replys.Find(id);
//            _context.Replys.Remove(reply);
//            _context.SaveChanges();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool ReplyExists(int id)
//        {
//            return _context.Replys.Any(e => e.Id == id);
//        }
//    }
   
//}
