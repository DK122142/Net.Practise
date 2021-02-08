using System;
using System.Collections.Generic;

#nullable disable

namespace EF.DbFirst.Models
{
    public partial class JobCandidate
    {
        public int JobCandidateId { get; set; }
        public int? BusinessEntityId1 { get; set; }
        public string Resume { get; set; }

        public virtual Employee BusinessEntityId1Navigation { get; set; }
    }
}
