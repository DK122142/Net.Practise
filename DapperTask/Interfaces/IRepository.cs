using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DapperTask.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T item);

        Task<T> GetAsync(int id);

        Task<IEnumerable<T>> FindAsync<TValue>(Expression<Func<T, object>> expression, TValue value);

        Task<bool> UpdateAsync(T item);

        Task<bool> DeleteAsync(T item);
    }
}
