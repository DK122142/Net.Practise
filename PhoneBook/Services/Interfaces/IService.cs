using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PhoneBook.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetPageAsync(int pageNumber, int itemsOnPage);

        Task<T> GetByIdAsync(Guid id);
        
        Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate);

        Task DeleteAsync(Guid id);

        Task<int> TotalCountAsync();
    }
}
