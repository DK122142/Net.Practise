SELECT COUNT(DISTINCT Orders.CustomerID) as Customers
	FROM Orders
	WHERE Orders.EmployeeID = (
	SELECT TOP 1 EmployeeID
	  FROM Orders
	  GROUP BY Orders.EmployeeID
	  ORDER BY COUNT(*) DESC)