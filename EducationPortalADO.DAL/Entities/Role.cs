using System.ComponentModel.DataAnnotations.Schema;

namespace EducationPortalADO.DAL.Entities
{
    [Table("roles")]
    public class Role
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public Roles RoleType { get; set; }
        
        [Column("description")]
        public string Description { get; set; }
    }
}
