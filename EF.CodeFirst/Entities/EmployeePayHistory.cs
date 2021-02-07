using System;
using System.ComponentModel.DataAnnotations;

namespace EF.CodeFirst.Entities
{
    public class EmployeePayHistory
    {
        public Employee Employee { get; set; }

        [Key]
        public DateTime RateChangeDate { get; set; }

        public float Rate { get; set; }

        public float PayFrequency { get; set; }
    }
}
