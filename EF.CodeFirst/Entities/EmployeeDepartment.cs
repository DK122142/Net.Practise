using System;
using System.ComponentModel.DataAnnotations;

namespace EF.CodeFirst.Entities
{
    public class EmployeeDepartment
    {
        [Key]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        [Key]
        public int ShiftId {get; set; }
        public Shift Shift { get; set; }

        [Key]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Key]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
