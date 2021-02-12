using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperTask.Models;

namespace DapperTask.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Create(T item);

        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        // IEnumerable<T> Find(Func<T, Boolean> predicate);

        Task<bool> Update(T item);

        Task<bool> Delete(T item);
    }
}
