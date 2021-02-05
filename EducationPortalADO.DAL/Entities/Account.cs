using System.ComponentModel.DataAnnotations.Schema;

namespace EducationPortalADO.DAL.Entities
{
    [Table("accounts")]
    public class Account
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("login")]
        public string Login { get; set; }
        
        [Column("password")]
        public string Password { get; set; }
        
        [Column("role")]
        public int Role { get; set; }
    }
}
