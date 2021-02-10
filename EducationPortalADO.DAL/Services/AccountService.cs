using System.Collections.Generic;
using EducationPortalADO.DAL.Entities;
using EducationPortalADO.DAL.Interfaces;

namespace EducationPortalADO.DAL.Services
{
    public class AccountService : IService<Account>
    {
        private IRepository<Account> repository;

        public AccountService(IRepository<Account> repository)
        {
            this.repository = repository;
        }

        public Account Create(Account item)
        {
            return this.repository.Create(item);
        }

        public IEnumerable<Account> GetTop(int amount)
        {
            return this.repository.GetTop(amount);
        }

        public Account Get(int id)
        {
            return this.repository.Get(id);
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
