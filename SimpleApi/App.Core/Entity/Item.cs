using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Entity
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Cost { get; set; }

        public string Nds { get; set; }

        public string Description { get; set; }

        public string Manufacturer { get; set; }

        public bool? Refrigerate { get; set; }

        public IEnumerable<Contract> Contracts { get; set; }
    }
}