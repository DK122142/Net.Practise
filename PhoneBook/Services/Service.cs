using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PhoneBook.Models;
using PhoneBook.Repository;
using PhoneBook.Services.Interfaces;

namespace PhoneBook.Services
{
    public class Service<T> : IService<T> where T : class, IEntity
    {
        
        protected readonly IRepository<T> repository;

        public Service(IRepository<T> repository)
        {
            this.repository = repository;
        }
        
        public virtual async Task<IEnumerable<T>> GetPageAsync(int pageNumber, int itemsOnPage)
        {
            return await this.repository.SkipTake((pageNumber - 1) * itemsOnPage, itemsOnPage);
        }
        
        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await this.repository.GetByIdAsync(id);
        }

        public virtual async Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate)
        {
           return await this.repository.FindBy(predicate);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await this.repository.GetByIdAsync(id);

            this.repository.Delete(entity);

            await this.repository.SaveChangesAsync();
        }

        public async Task<int> TotalCountAsync()
        {
            return await this.repository.CountAsync();
        }
    }
}
