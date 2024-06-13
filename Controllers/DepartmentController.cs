using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DepartmentReminderApp.Data;
using DepartmentReminderApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DepartmentReminderApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DepartmentController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index(int? id)
        {
            IQueryable<Department> query = _context.Departments.Include(d => d.ParentDepartment);

            if (id.HasValue)
            {
                query = query.Where(d => d.ParentDepartmentId == id);
            }
            else
            {
                query = query.Where(d => d.ParentDepartmentId == null);
            }

            var departments = await query.ToListAsync();

            foreach (var department in departments)
            {
                await _context.Entry(department)
                    .Collection(d => d.SubDepartments)
                    .LoadAsync();
            }

            return View(departments);
        }

        public async Task<IActionResult> Details(int id)
        {
            var department = await _context.Departments
                .Include(d => d.ParentDepartment)
                .Include(d => d.SubDepartments)
                .FirstOrDefaultAsync(d => d.DepartmentId == id);

            if (department == null)
            {
                return NotFound();
            }

            await LoadSubDepartments(department);

            return View(department);
        }

        private async Task LoadSubDepartments(Department department)
        {
            if (department.SubDepartments != null)
            {
                foreach (var subDept in department.SubDepartments)
                {
                    await _context.Entry(subDept)
                        .Collection(d => d.SubDepartments)
                        .LoadAsync();

                    await LoadSubDepartments(subDept);
                }
            }
        }


        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                if (department.DepartmentLogoFile != null && department.DepartmentLogoFile.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + department.DepartmentLogoFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    Directory.CreateDirectory(uploadsFolder);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await department.DepartmentLogoFile.CopyToAsync(fileStream);
                    }

                    department.DepartmentLogo = uniqueFileName;
                }

                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", department.ParentDepartmentId);
            return View(department);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", department.ParentDepartmentId);
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentId,DepartmentName,DepartmentLogoFile,ParentDepartmentId")] Department department)
        {
            if (id != department.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (department.DepartmentLogoFile != null)
                    {
                    }
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.DepartmentId))
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
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", department.ParentDepartmentId);
            return View(department);
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.DepartmentId == id);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        
    }
}
