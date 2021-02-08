using System;
using System.ComponentModel.DataAnnotations;

namespace EF.CodeFirst.Entities
{
    public class EmployeeDepartment
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        
        public int ShiftId {get; set; }
        public Shift Shift { get; set; }
        
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
