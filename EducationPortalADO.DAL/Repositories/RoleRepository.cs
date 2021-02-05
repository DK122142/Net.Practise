using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EducationPortalADO.DAL.Entities;
using EducationPortalADO.DAL.Interfaces;

namespace EducationPortalADO.DAL.Repositories
{
    public class RoleRepository : IRepository<Role>
    {
        private readonly string connectionString;

        public RoleRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Role> GetAll()
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = "SELECT * FROM roles_new";

                using (var cmd = new SqlCommand(command, connection))
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

        public Role Get(int id)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = $"SELECT * FROM roles_new WHERE id = {id}";

                using (var cmd = new SqlCommand(command, connection))
                {
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

        public IEnumerable<Role> Find(Func<Role, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Role Create(Role item)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = @$"INSERT INTO roles_new(type, description)
                                    VALUES ({(int)item.RoleType}, '{item.RoleType}')";

                using (var cmd = new SqlCommand(command, connection))
                {
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
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = @$"UPDATE roles_new
                                    SET type = {(int)item.RoleType}, description = '{item.Description}'
                                    WHERE id = {item.Id}";

                using (var cmd = new SqlCommand(command, connection))
                {
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
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = @$"DELETE FROM roles_new
                                    WHERE id = {id}";

                using (var cmd = new SqlCommand(command, connection))
                {
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        var resultTable = new DataTable();
                        adapter.Fill(resultTable);
                    }
                }
            }
        }
    }
}
