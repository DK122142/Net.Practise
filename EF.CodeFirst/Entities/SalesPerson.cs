using System.ComponentModel.DataAnnotations;

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
