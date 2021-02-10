using System.Collections.Generic;
using EducationPortalADO.DAL.Entities;
using EducationPortalADO.DAL.Interfaces;

namespace EducationPortalADO.DAL.Services
{
    public class RoleService : IService<Role>
    {
        private IRepository<Role> repository;

        public RoleService(IRepository<Role> repository)
        {
            this.repository = repository;
        }

        public Role Create(Role item)
        {
            return this.repository.Create(item);
        }

        public IEnumerable<Role> GetTop(int amount)
        {
            return this.repository.GetTop(amount);
        }

        public Role Get(int id)
        {
            return this.repository.Get(id);
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
