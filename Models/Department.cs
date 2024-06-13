using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DepartmentReminderApp.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentLogo { get; set; }
        public int? ParentDepartmentId { get; set; }

        [ForeignKey("ParentDepartmentId")]
        public Department ParentDepartment { get; set; }

        public ICollection<Department> SubDepartments { get; set; } = new List<Department>();

        [NotMapped]
        public IFormFile DepartmentLogoFile { get; set; }

        [NotMapped]
        public IEnumerable<Department> AllParentDepartments { get; set; }
    }
}
