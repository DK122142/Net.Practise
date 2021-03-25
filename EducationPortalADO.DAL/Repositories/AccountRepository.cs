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
    public class AccountRepository : IRepository<Account>
    {
        private readonly string connectionString;
        private readonly SqlQueryHelper sqlQueryHelper;

        public AccountRepository(string connectionString)
        {
            this.connectionString = connectionString;
            this.sqlQueryHelper = new SqlQueryHelper();
        }

        public IEnumerable<Account> GetTopRows(int amount)
        {
            var command = @"SELECT TOP @amount * FROM accounts";

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
                            yield return new Account
                            {
                                Id = (int) row.ItemArray[0],
                                Login = (string) row.ItemArray[1],
                                Password = (string) row.ItemArray[2],
                                RoleId = (int) row.ItemArray[3]
                            };
                        }
                    }
                }
            }
        }

        public Account GetById(int id)
        {
            var command = @"SELECT * FROM accounts WHERE id = @id";

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
                            return new Account
                            {
                                Id = (int) row.ItemArray[0],
                                Login = (string) row.ItemArray[1],
                                Password = (string) row.ItemArray[2],
                                RoleId = (int) row.ItemArray[3]
                            };
                        }
                    }
                }
            }

            return default;
        }

        public IEnumerable<Account> Find(Expression<Func<Account, Boolean>> predicate)
        {
            return this.Select($@"SELECT * 
FROM accounts
WHERE {this.sqlQueryHelper.SqlFromPredicate(predicate)}");
        }

        public Account Create(Account item)
        {
            var command = @"INSERT INTO accounts(login, password, role)
                                    VALUES (@login, @password, @role)";

            using (var connection = new SqlConnection(this.connectionString))
            {
                using (var cmd = new SqlCommand(command, connection))
                {
                    cmd.Parameters.AddWithValue("@login", item.Login);
                    cmd.Parameters.AddWithValue("@password", item.Password);
                    // account role id
                    cmd.Parameters.AddWithValue("@role", item.RoleId);

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        var resultTable = new DataTable();
                        adapter.Fill(resultTable);

                        foreach (DataRow row in resultTable.Rows)
                        {
                            return new Account
                            {
                                Id = (int) row.ItemArray[0],
                                Login = (string) row.ItemArray[1],
                                Password = (string) row.ItemArray[2],
                                RoleId = (int) row.ItemArray[3]
                            };
                        }
                    }
                }
            }

            return default;
        }

        public Account Update(Account item)
        {
            var command = @"UPDATE accounts
                                    SET login = @login, password = @password, role = @role
                                    WHERE id = @id";

            using (var connection = new SqlConnection(this.connectionString))
            {
                using (var cmd = new SqlCommand(command, connection))
                {
                    cmd.Parameters.AddWithValue("@login", item.Login);
                    cmd.Parameters.AddWithValue("@password", item.Password);
                    cmd.Parameters.AddWithValue("@role", item.RoleId);
                    cmd.Parameters.AddWithValue("@id", item.Id);

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        var resultTable = new DataTable();
                        adapter.Fill(resultTable);

                        foreach (DataRow row in resultTable.Rows)
                        {
                            return new Account
                            {
                                Id = (int) row.ItemArray[0],
                                Login = (string) row.ItemArray[1],
                                Password = (string) row.ItemArray[2],
                                RoleId = (int) row.ItemArray[3]
                            };
                        }
                    }
                }
            }

            return default;
        }

        public void Delete(int id)
        {
            var command = @"DELETE FROM accounts
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

        private IEnumerable<Account> Select(string query)
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
                            yield return new Account
                            {
                                Id = (int) row.ItemArray[0],
                                Login = (string) row.ItemArray[1],
                                Password = (string) row.ItemArray[2],
                                RoleId = (int) row.ItemArray[3]
                            };
                        }
                    }
                }
            }
        }
    }
}
