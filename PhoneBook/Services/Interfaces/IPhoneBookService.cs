using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneBook.Models;

namespace PhoneBook.Services.Interfaces
{
    public interface IPhoneBookService
    {
        Task Create(PhoneNumber item, Guid userId);
        
        Task<PhoneNumber> GetById(Guid id);

        Task Update(PhoneNumber item, Guid userId);

        Task Delete(Guid id, Guid userId);

        IEnumerable<PhoneNumber> GetPageOfPhoneNumbers(int skip, int take);

        Task<int> TotalPhoneNumbers();
    }
}
