using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EF.CodeFirst.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        
        public string Name { get; set; }

        public string GroupName { get; set; }

        public ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }
    }
}
