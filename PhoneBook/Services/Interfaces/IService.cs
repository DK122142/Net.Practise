using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PhoneBook.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        
        Task Add(T entity);

        Task Add(IEnumerable<T> items);
        
        Task<IList<T>> All();

        Task<T> GetById(string id);
        
        void Update(T entity);

        void Update(IEnumerable<T> items);

        void Delete(T entity);

        void Delete(IEnumerable<T> entities);

        IQueryable<T> Where(Expression<Func<T, bool>> expression);
    }
}
