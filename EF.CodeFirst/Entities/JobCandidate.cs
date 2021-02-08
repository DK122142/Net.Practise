using System.ComponentModel.DataAnnotations;

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
