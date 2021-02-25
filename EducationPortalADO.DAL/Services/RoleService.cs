using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using EducationPortalADO.DAL.Entities;
using EducationPortalADO.DAL.Interfaces;

namespace EducationPortalADO.DAL.Services
{
    public class RoleService : IService<Role>
    {
        private readonly IRepository<Role> repository;

        public RoleService(IRepository<Role> repository)
        {
            this.repository = repository;
        }

        public Role Create(Role item)
        {
            return this.repository.Create(item);
        }

        public IEnumerable<Role> GetTopRows(int amount)
        {
            return this.repository.GetTopRows(amount);
        }

        public Role GetById(int id)
        {
            return this.repository.GetById(id);
        }

        public IEnumerable<Role> Find(Expression<Func<Role, bool>> predicate)
        {
            return this.repository.Find(predicate);
        }

        public Role Update(Role item)
        {
            return this.repository.Update(item);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }
    }
}
