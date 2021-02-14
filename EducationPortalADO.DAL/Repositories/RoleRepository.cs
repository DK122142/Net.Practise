using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using EducationPortalADO.DAL.Entities;
using EducationPortalADO.DAL.Infrastructure;
using EducationPortalADO.DAL.Interfaces;

namespace EducationPortalADO.DAL.Repositories
{
    public class RoleRepository : IRepository<Role>
    {
        private readonly string connectionString;
        private readonly SqlQueryHelper sqlQueryHelper;

        public RoleRepository(string connectionString)
        {
            this.connectionString = connectionString;
            this.sqlQueryHelper = new SqlQueryHelper();
        }

        public IEnumerable<Role> GetTopRows(int amount)
        {
            var command = "SELECT TOP @amount * FROM roles_new";

            using (var connection = new SqlConnection(this.connectionString))
            {
                using (var cmd = new SqlCommand(command, connection))
                {
                    cmd.Parameters.AddWithValue("@amount", amount);

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        var resultTable = new DataTable();
                        adapter.Fill(resultTable);

                        foreach (DataRow row in resultTable.Rows)
                        {
                            yield return new Role
                            {
                                Id = (int) row.ItemArray[0],
                                RoleType = (Roles)(int) row.ItemArray[1],
                                Description = row.ItemArray[2] == null ?
                                    (string) row.ItemArray[2] :
                                    string.Empty
                            };
                        }
                    }
                }
            }
        }

        public Role GetById(int id)
        {
            var command = @"SELECT * FROM roles_new WHERE id = @id";

            using (var connection = new SqlConnection(this.connectionString))
            {
                using (var cmd = new SqlCommand(command, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        var resultTable = new DataTable();
                        adapter.Fill(resultTable);

                        foreach (DataRow row in resultTable.Rows)
                        {
                            return new Role
                            {
                                Id = (int) row.ItemArray[0],
                                RoleType = (Roles)(int) row.ItemArray[1],
                                Description = row.ItemArray[2] == null ?
                                    (string) row.ItemArray[2] :
                                    string.Empty
                            };
                        }
                    }
                }
            }

            return default;
        }

        public IEnumerable<Role> Find(Expression<Func<Role, bool>> predicate)
        {
            return this.Select($@"SELECT * 
FROM roles_new
WHERE {this.sqlQueryHelper.SqlFromPredicate(predicate)}");
        }

        public Role Create(Role item)
        {
            var command = @"INSERT INTO roles_new(type, description)
                                    VALUES (@type, @description)";

            using (var connection = new SqlConnection(this.connectionString))
            {
                using (var cmd = new SqlCommand(command, connection))
                {
                    cmd.Parameters.AddWithValue("@type", (int) item.RoleType);
                    cmd.Parameters.AddWithValue("@description", item.RoleType);

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        var resultTable = new DataTable();
                        adapter.Fill(resultTable);

                        foreach (DataRow row in resultTable.Rows)
                        {
                            return new Role
                            {
                                Id = (int) row.ItemArray[0],
                                RoleType = (Roles)(int) row.ItemArray[1],
                                Description = row.ItemArray[2] == null ?
                                    (string) row.ItemArray[2] :
                                    string.Empty
                            };
                        }
                    }
                }
            }

            return default;
        }

        public Role Update(Role item)
        {
            var command = @"UPDATE roles_new
                                    SET type = @type, description = @description
                                    WHERE id = @id";

            using (var connection = new SqlConnection(this.connectionString))
            {
                using (var cmd = new SqlCommand(command, connection))
                {
                    cmd.Parameters.AddWithValue("@type", (int) item.RoleType);
                    cmd.Parameters.AddWithValue("@description", item.RoleType);
                    cmd.Parameters.AddWithValue("@id", item.Id);

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        var resultTable = new DataTable();
                        adapter.Fill(resultTable);

                        foreach (DataRow row in resultTable.Rows)
                        {
                            return new Role
                            {
                                Id = (int) row.ItemArray[0],
                                RoleType = (Roles)(int) row.ItemArray[1],
                                Description = row.ItemArray[2] == null ?
                                    (string) row.ItemArray[2] :
                                    string.Empty
                            };
                        }
                    }
                }
            }

            return default;
        }

        public void Delete(int id)
        {
            var command = @"DELETE FROM roles_new
                                    WHERE id = @id";

            using (var connection = new SqlConnection(this.connectionString))
            {
                using (var cmd = new SqlCommand(command, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        var resultTable = new DataTable();
                        adapter.Fill(resultTable);
                    }
                }
            }
        }

        private IEnumerable<Role> Select(string query)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                using (var cmd = new SqlCommand(query, connection))
                {
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        var resultTable = new DataTable();
                        adapter.Fill(resultTable);

                        foreach (DataRow row in resultTable.Rows)
                        {
                            yield return new Role
                            {
                                Id = (int) row.ItemArray[0],
                                RoleType = (Roles)(int) row.ItemArray[1],
                                Description = row.ItemArray[2] == null ?
                                    (string) row.ItemArray[2] :
                                    string.Empty
                            };
                        }
                    }
                }
            }
        }
    }
}
