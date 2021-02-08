using System;
using System.Collections.Generic;

#nullable disable

namespace EF.DbFirst.Models
{
    public partial class EmployeeDepartment
    {
        public int DepartmentId { get; set; }
        public int ShiftId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Department Department { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Shift Shift { get; set; }
    }
}
