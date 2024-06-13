using System;

namespace DepartmentReminderApp.Models
{
    public class Reminder
    {
        public int ReminderId { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public string Email { get; set; } // Add email address property

    }
}
