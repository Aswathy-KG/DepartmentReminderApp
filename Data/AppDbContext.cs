using Microsoft.EntityFrameworkCore;
using DepartmentReminderApp.Models;

namespace DepartmentReminderApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Reminder> Reminders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasOne(d => d.ParentDepartment)
                .WithMany(d => d.SubDepartments)
                .HasForeignKey(d => d.ParentDepartmentId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Department>()
                .Navigation(d => d.SubDepartments)
                .UsePropertyAccessMode(PropertyAccessMode.Property); 
        }
    }
}
