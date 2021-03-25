using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PhoneBook.EF;
using PhoneBook.Models;
using PhoneBook.Repository;
using PhoneBook.Services.Interfaces;

namespace PhoneBook.Services
{
    [Authorize]
    public class PhoneBookService : Service<PhoneNumber>, IPhoneBookService
    {
        public PhoneBookService(IRepository<PhoneNumber> repository) : base(repository)
        {
        }

        public async Task Create(PhoneNumber item)
        {
            await this.repository.AddAsync(item);
            await this.repository.SaveChangesAsync();
        }
        
        public async Task Update(PhoneNumber item)
        {
            this.repository.Update(item);
            await this.repository.SaveChangesAsync();
        }
    }
}
