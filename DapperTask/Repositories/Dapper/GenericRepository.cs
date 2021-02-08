using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
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
            var properties = typeof(T).GetProperties().ToList().Select(p => p.Name).Where(n => n != "Id");

            var columns = string.Join(",", properties);

            var values = string.Join(",", properties.Select(p => $"@{p}"));

            using (var db = new SqlConnection(this.connectionString))
            {
                await db.ExecuteAsync($@"INSERT INTO {typeof(T).Name} ({columns}) VALUES ({values})", item);
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (var db = new SqlConnection(this.connectionString))
            {
                return await db.QueryAsync<T>($@"SELECT * FROM [{typeof(T).Name}]");
            }
        }

        public async Task<T> Get(int id)
        {
            using (var db = new SqlConnection(this.connectionString))
            {
                return await db.QueryFirstOrDefaultAsync<T>($@"SELECT * FROM [{typeof(T).Name}] WHERE Id = {id}");
            }
        }
        
        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
