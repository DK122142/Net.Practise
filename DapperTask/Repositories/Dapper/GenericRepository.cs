using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using DapperExtensions;
using DapperTask.Interfaces;
using Microsoft.Data.SqlClient;

namespace DapperTask.Repositories.Dapper
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly string connectionString;

        public GenericRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task CreateAsync(T item)
        {
            using (var db = new SqlConnection(this.connectionString))
            {
                await SqlMapperExtensions.InsertAsync(db, item);
            }
        }

        public async Task<T> GetAsync(int id)
        {
            using (var db = new SqlConnection(this.connectionString))
            {
                return await SqlMapperExtensions.GetAsync<T>(db, id);
            }
        }

        public async Task<IEnumerable<T>> FindAsync<TValue>(Expression<Func<T, object>> expression, TValue value)
        {
            using (var db = new SqlConnection(this.connectionString))
            {
                var predicate = Predicates.Field<T>(expression, Operator.Eq, value);
                return await db.GetListAsync<T>(predicate);
            }
        }


        public async Task<bool> UpdateAsync(T item)
        {
            using (var db = new SqlConnection(this.connectionString))
            {
                return await SqlMapperExtensions.UpdateAsync(db, item);
            }
        }

        public async Task<bool> DeleteAsync(T item)
        {
            using (var db = new SqlConnection(this.connectionString))
            {
                return await SqlMapperExtensions.DeleteAsync(db, item);
            }
        }
    }
}
