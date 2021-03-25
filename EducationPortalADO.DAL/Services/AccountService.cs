using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using EducationPortalADO.DAL.Entities;
using EducationPortalADO.DAL.Interfaces;

namespace EducationPortalADO.DAL.Services
{
    public class AccountService : IService<Account>
    {
        private readonly IRepository<Account> repository;

        public AccountService(IRepository<Account> repository)
        {
            this.repository = repository;
        }

        public Account Create(Account item)
        {
            return this.repository.Create(item);
        }

        public IEnumerable<Account> GetTopRows(int amount)
        {
            return this.repository.GetTopRows(amount);
        }

        public Account GetById(int id)
        {
            return this.repository.GetById(id);
        }

        public IEnumerable<Account> Find(Expression<Func<Account, bool>> predicate)
        {
            return this.repository.Find(predicate);
        }
        
        public Account Update(Account item)
        {
            return this.repository.Update(item);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }
    }
}
