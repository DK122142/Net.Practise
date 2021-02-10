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

        public IEnumerable<Account> GetTop(int amount)
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
                                Role = (int) row.ItemArray[3]
                            };
                        }
                    }
                }
            }
        }

        public Account Get(int id)
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
                                Role = (int) row.ItemArray[3]
                            };
                        }
                    }
                }
            }

            return default;
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
                    cmd.Parameters.AddWithValue("@role", item.Role);

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
            var command = @"UPDATE accounts
                                    SET login = @login, password = @password, role = @role
                                    WHERE id = @id";

            using (var connection = new SqlConnection(this.connectionString))
            {
                using (var cmd = new SqlCommand(command, connection))
                {
                    cmd.Parameters.AddWithValue("@login", item.Login);
                    cmd.Parameters.AddWithValue("@password", item.Password);
                    cmd.Parameters.AddWithValue("@role", item.Role);
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
    }
}
