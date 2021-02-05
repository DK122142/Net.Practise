using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.CodeFirst.Entities
{
    public class SalesPerson
    {
        [Key]
        public int BusinessEntityId { get; set; }

        public Employee Employee { get; set; }

        public string SalesQuota { get; set; }
    }
}
