#nullable disable

namespace EF.DbFirst.Models
{
    public partial class SalesPerson
    {
        public int BusinessEntityId { get; set; }
        public int? EmployeeBusinessEntityId { get; set; }
        public string SalesQuota { get; set; }

        public virtual Employee EmployeeBusinessEntity { get; set; }
    }
}
