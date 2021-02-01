/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [EmployeeID]
      ,[LastName]
      ,[FirstName]
  FROM [Northwind].[dbo].[Employees]
  WHERE Employees.City = 'London'