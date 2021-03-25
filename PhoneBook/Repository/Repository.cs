using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhoneBook.EF;

namespace PhoneBook.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> table;
        private readonly DbContext context;

        public Repository(PhoneBookContext context)
        {
            this.context = context;
            this.table = context.Set<T>();
        }

        public async Task<IEnumerable<T>> SkipTake(int skip, int take)
        {
            return await this.table.Skip(skip).Take(take).ToListAsync();
        }
        
        public async Task<int> CountAsync()
        {
            return await this.table.CountAsync();
        }

        public virtual Task SaveChangesAsync()
        {
            return this.context.SaveChangesAsync();
        }

        public virtual async Task<T> FirstOrDefaultAsync()
        {
            return await this.table.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this.table.AsNoTracking().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate)
        {
            return await this.table.Where(predicate).ToListAsync();
        }

        public virtual Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return this.table.AnyAsync(predicate);
        }
        
        public virtual async Task<T> GetByIdAsync(params object[] keys)
        {
            return await this.table.FindAsync(keys).AsTask();
        }

        public virtual async Task AddAsync(T entity)
        {
            await this.table.AddAsync(entity);
        }

        public virtual async Task AddAsync(IEnumerable<T> entities)
        {
            await this.table.AddRangeAsync(entities);
        }

        public virtual void Delete(T entity)
        {
            this.table.Remove(entity);
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            this.table.RemoveRange(entities);
        }

        public virtual void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
