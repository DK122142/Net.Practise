using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.CodeFirst.Entities
{
    public class JobCandidate
    {
        [Key]
        public int JobCandidateId { get; set; }

        public Employee BusinessEntityId { get; set; }

        public string Resume { get; set; }
    }
}
