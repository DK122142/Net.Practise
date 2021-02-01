using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace SQL.ADO.Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", false)
                .Build();

            string connectionString = "Data Source=desktop-k9eou6n;Initial Catalog=Northwind;Integrated Security=True";
            // string connectionString =  ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            // string connectionString = configuration.GetSection("connectionString").Value;
            
            string task1 = @"SELECT [EmployeeID],[LastName],[FirstName]
                                FROM [Northwind].[dbo].[Employees]
                                WHERE Employees.City = 'London'";

            string task2 = @"SELECT COUNT(DISTINCT Orders.CustomerID) as Customers
	                            FROM Orders
	                            WHERE Orders.EmployeeID = (
	                            SELECT TOP 1 EmployeeID
	                              FROM Orders
	                              GROUP BY Orders.EmployeeID
	                              ORDER BY COUNT(*) DESC)";

            string task3 = @"SELECT Orders.ShipCountry, Orders.ShipCity
	                            FROM Orders
	                            GROUP BY ShipCountry, ShipCity
	                            HAVING COUNT(OrderID) > 2";

            string task4 = @"SELECT TOP 1 Products.ProductID, Products.ProductName, Products.UnitPrice
	                            FROM Products
	                            WHERE Products.CategoryID = 8
	                            ORDER BY Products.UnitPrice DESC";

            string task6 = @"SELECT c.CustomerID, c.ContactName
	                            FROM Customers c, (
		                            SELECT DISTINCT o1.CustomerID
			                            FROM Orders o1
			                            INNER JOIN Orders o2 ON o1.CustomerID = o2.CustomerID
			                            WHERE o1.CustomerID = o2.CustomerID
			                            AND o1.OrderDate != o2.OrderDate
			                            AND ABS(DATEDIFF(MONTH, o1.OrderDate, o2.OrderDate)) > 6
	                            ) res
	                            WHERE c.CustomerID = res.CustomerID";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Console.WriteLine($"{connection.Database}");
                
                ExecuteCmd(connection, task1);
                ExecuteCmd(connection, task2);
                ExecuteCmd(connection, task3);
                ExecuteCmd(connection, task4);
                ExecuteCmd(connection, task6);
            }
        }

        public static void ExecuteCmd(SqlConnection _connection, string _cmd)
        {
            using (var cmd = new SqlCommand(_cmd, _connection))
            {
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    var res = new DataTable();
                    adapter.Fill(res);
                    PrintTable(res);
                }
            }
        }

        public static void PrintTable(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write($"{item} |");
                }

                Console.WriteLine();
            }
            
            Console.WriteLine($"Rows: {table.Rows.Count}\n");
        }
    }
}
