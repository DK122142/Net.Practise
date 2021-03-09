using System;

namespace PhoneBook.Models
{
    public class PhoneNumberStatus
    {
        public Guid Id { get; set; }

        // Relevant, Irrelevant, Requires clarification
        public string StatusType { get; set; }
    }
}
