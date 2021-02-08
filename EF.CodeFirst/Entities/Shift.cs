using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EF.CodeFirst.Entities
{
    [Index(nameof(Name), nameof(StartTime), nameof(EndTime), IsUnique = true)]
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
