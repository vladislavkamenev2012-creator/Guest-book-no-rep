using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Guestbook.Models;
using System.Linq;
using Guestbook.Data;

namespace Guestbook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var messages = _context.Messages
                .Include(m => m.User)
                .OrderByDescending(m => m.MessageDate)
                .ToList();

            ViewBag.IsAuthenticated = HttpContext.Session.GetInt32("UserId") != null;
            ViewBag.UserName = HttpContext.Session.GetString("UserName");

            return View(messages);
        }

        [HttpPost]
        public IActionResult AddMessage(string messageText)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!string.IsNullOrWhiteSpace(messageText))
            {
                var msg = new Message
                {
                    Id_User = userId.Value,
                    MessageText = messageText,
                    MessageDate = DateTime.Now
                };
                _context.Messages.Add(msg);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}