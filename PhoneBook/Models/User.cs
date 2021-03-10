using System;
using System.Collections.Generic;

namespace PhoneBook.Models
{
    public class User : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
