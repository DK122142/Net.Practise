using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PhoneBook.Repository
{
    public interface IRepository<T> where T : class
    {
        Task SaveChangesAsync();

        Task<T> FirstOrDefaultAsync();

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        Task<T> GetByIdAsync(params object[] keys);

        Task AddAsync(T entity);

        Task AddAsync(IEnumerable<T> entities);

        void Delete(T entity);

        void Delete(IEnumerable<T> entities);

        void Update(T entity);
        
        Task<IEnumerable<T>> SkipTake(int skip, int take);

        Task<int> CountAsync();
    }
}
