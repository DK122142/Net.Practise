using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.CodeFirst.Entities
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public string GroupName { get; set; }

        public ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }
    }
}
