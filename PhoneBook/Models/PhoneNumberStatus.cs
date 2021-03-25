using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.Models
{
    public class PhoneNumberStatus : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        ///  Relevant, Irrelevant, Requires clarification
        /// </summary>
        public string StatusType { get; set; }
    }
}
