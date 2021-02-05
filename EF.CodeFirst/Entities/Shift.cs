using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.CodeFirst.Entities
{
    public class Shift
    {
        [Key]
        public int ShiftId { get; set; }

        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }
    }
}
