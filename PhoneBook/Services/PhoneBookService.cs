using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PhoneBook.EF;
using PhoneBook.Models;
using PhoneBook.Services.Interfaces;

namespace PhoneBook.Services
{
    [Authorize]
    public class PhoneBookService : IPhoneBookService
    {
        private readonly PhoneBookContext context;

        public PhoneBookService(PhoneBookContext context)
        {
            this.context = context;
        }

        public async Task Create(PhoneNumber item)
        {
            await this.context.PhoneNumbers.AddAsync(item);
            await this.context.SaveChangesAsync();
        }

        public async Task<PhoneNumber> GetById(Guid id)
        {
            return await this.context.PhoneNumbers.SingleAsync(pn => pn.Id.Equals(id));
        }

        public async Task Update(PhoneNumber item, Guid userId)
        {
            var pn = await this.GetById(item.Id);

            if (pn.Creator.Id != userId)
            {
                return;
            }

            this.context.PhoneNumbers.Update(item);
            await this.context.SaveChangesAsync();
        }

        public async Task Delete(Guid id, Guid userId)
        {
            var pn = await this.GetById(id);
            
            if (pn.Creator.Id != userId)
            {
                return;
            }

            this.context.PhoneNumbers.Remove(pn);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PhoneNumber>> GetPageOfPhoneNumbers(int skip, int take)
        {
            return await this.context.PhoneNumbers.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<int> TotalPhoneNumbers()
        {
            return await this.context.PhoneNumbers.CountAsync();
        }
    }
}
