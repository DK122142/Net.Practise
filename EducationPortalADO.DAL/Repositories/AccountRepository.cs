using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EducationPortalADO.DAL.Entities;
using EducationPortalADO.DAL.Interfaces;

namespace EducationPortalADO.DAL.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        private readonly string connectionString;

        public AccountRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<Account> GetAll()
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = "SELECT * FROM accounts";

                using (var cmd = new SqlCommand(command, connection))
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
                                Role = (int) row.ItemArray[3]
                            };
                        }
                    }
                }
            }
        }

        public Account Get(int id)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = $"SELECT * FROM accounts WHERE id = {id}";

                using (var cmd = new SqlCommand(command, connection))
                {
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
                                Role = (int) row.ItemArray[3]
                            };
                        }
                    }
                }
            }

            return default;
        }

        public IEnumerable<Account> Find(Func<Account, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Account Create(Account item)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = @$"INSERT INTO accounts(login, password, role)
                                    VALUES ('{item.Login}', '{item.Password}', {item.Role})";

                using (var cmd = new SqlCommand(command, connection))
                {
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
                                Role = (int) row.ItemArray[3]
                            };
                        }
                    }
                }
            }

            return default;
        }

        public Account Update(Account item)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var command = @$"UPDATE accounts
                                    SET login = '{item.Login}', password = '{item.Password}', role = {item.Role}
                                    WHERE id = {item.Id}";

                using (var cmd = new SqlCommand(command, connection))
                {
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
                                Role = (int) row.ItemArray[3]
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
                var command = @$"DELETE FROM accounts
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
