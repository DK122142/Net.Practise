using System;

namespace PhoneBook.Models
{
    public class PhoneNumberStatus
    {
        public Guid Id { get; set; }

        /// <summary>
        ///  Relevant, Irrelevant, Requires clarification
        /// </summary>
        public string StatusType { get; set; }
    }
}
