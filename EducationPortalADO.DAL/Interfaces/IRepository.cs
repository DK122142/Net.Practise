using System.Collections.Generic;

namespace EducationPortalADO.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Create(T item);

        IEnumerable<T> GetTop(int amount);

        T Get(int id);

        T Update(T item);

        void Delete(int id);
    }
}
