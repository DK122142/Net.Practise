using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.Models
{
    public class User : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
