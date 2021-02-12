using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using DapperTask.Interfaces;
using DapperTask.Models;
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

        public async Task Create(T item)
        {
            using (var db = new SqlConnection(this.connectionString))
            {
                await db.InsertAsync(item);
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (var db = new SqlConnection(this.connectionString))
            {
                return await db.GetAllAsync<T>();
            }
        }

        public async Task<T> Get(int id)
        {
            using (var db = new SqlConnection(this.connectionString))
            {
                return await db.GetAsync<T>(id);
            }
        }
        
        public async Task<bool> Update(T item)
        {
            using (var db = new SqlConnection(this.connectionString))
            {
                return await db.UpdateAsync(item);
            }
        }

        public async Task<bool> Delete(T item)
        {
            using (var db = new SqlConnection(this.connectionString))
            {
                return await db.DeleteAsync(item);
            }
        }
    }
}
