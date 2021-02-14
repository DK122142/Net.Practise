using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EducationPortalADO.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Create(T item);

        /// <summary>
        /// Method gets specified amount of rows from the table.
        /// </summary>
        /// <param name="amount"> Number of rows to get from table </param>
        /// <returns>List of entities</returns>
        IEnumerable<T> GetTopRows(int amount);
        
        T GetById(int id);

        IEnumerable<T> Find(Expression<Func<T, Boolean>> predicate);
        
        T Update(T item);

        void Delete(int id);
    }
}
