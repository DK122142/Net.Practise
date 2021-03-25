﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.Models
{
    public class PhoneNumber : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Address { get; set; }

        public string Number { get; set; }

        public DateTime Added { get; set; }

        public DateTime Updated { get; set; }

        public virtual PhoneNumberStatus Status { get; set; }

        public virtual User Creator { get; set; }
    }
}
