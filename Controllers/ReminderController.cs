using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DepartmentReminderApp.Data;
using DepartmentReminderApp.Models;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace DepartmentReminderApp.Controllers
{
    public class ReminderController : Controller
    {
        private readonly AppDbContext _context;

        public ReminderController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Reminders.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReminderId,Title,DateTime,Email")] Reminder reminder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reminder);
                await _context.SaveChangesAsync();

                await SendEmail(reminder);

                return RedirectToAction(nameof(Index));
            }
            return View(reminder);
        }

        private async Task SendEmail(Reminder reminder)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Aswathy", "aswathikg22@gmail.com")); 
            message.To.Add(new MailboxAddress("", reminder.Email));
            message.Subject = "Reminder Notification";
            message.Body = new TextPart("plain")
            {
                Text = $"You have a reminder titled '{reminder.Title}' scheduled for {reminder.DateTime}."
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false); 
                await client.AuthenticateAsync("elscarlet520@gmail.com", "lxns paxr xbfq zduo"); //This is the App password .
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            var reminder = await _context.Reminders.FindAsync(id);
            if (reminder == null)
            {
                return NotFound();
            }

            _context.Reminders.Remove(reminder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
