using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using App.Core.Entity;
using Microsoft.EntityFrameworkCore;
using AppContext = App.DataAccess.Context.AppContext;

namespace App.DataAccess.Repository
{
    internal class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppContext dbContext;

        public Repository(AppContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdWithIncludesAsync(int id, IEnumerable<Expression<Func<T, dynamic>>> includes = null, bool isNoTracking = true)
        {
            var query = isNoTracking ? this.dbContext.Set<T>().AsNoTracking() : this.dbContext.Set<T>().AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return await query.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}