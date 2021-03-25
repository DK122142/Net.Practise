using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EducationPortalADO.DAL.Interfaces
{
    public interface IService<T> where T : class
    {
        T Create(T item);
        
        IEnumerable<T> GetTopRows(int amount);
        
        T GetById(int id);

        IEnumerable<T> Find(Expression<Func<T, Boolean>> predicate);
        
        T Update(T item);

        void Delete(int id);
    }
}
