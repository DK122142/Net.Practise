using System;
using System.Collections.Generic;

#nullable disable

namespace EF.DbFirst.Models
{
    public partial class EmployeePayHistory
    {
        public DateTime RateChangeDate { get; set; }
        public int? EmployeeBusinessEntityId { get; set; }
        public float Rate { get; set; }
        public float PayFrequency { get; set; }

        public virtual Employee EmployeeBusinessEntity { get; set; }
    }
}
