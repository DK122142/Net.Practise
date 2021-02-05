using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.CodeFirst.Entities
{
    public class EmployeePayHistory
    {
        [Key]
        public int BusinessEntityId { get; set; }

        public DateTime RateChangeDate { get; set; }

        public float Rate { get; set; }

        public float PayFrequency { get; set; }
    }
}
