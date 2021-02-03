SELECT DISTINCT o.CustomerID, c.ContactName
	FROM Customers AS c,
		(
		SELECT TOP 99.99 PERCENT *, ROW_NUMBER() OVER (ORDER BY Orders.CustomerID, Orders.OrderDate) as RN
		FROM Orders
		) AS o 
		LEFT JOIN 
		(
		SELECT TOP 99.99 PERCENT *, ROW_NUMBER() OVER (ORDER BY Orders.CustomerID, Orders.OrderDate) as RN
		FROM Orders
		) AS o_prev
		ON o.RN = o_prev.RN - 1
	WHERE o.CustomerID = o_prev.CustomerID
	AND ABS(DATEDIFF(DAY, o.OrderDate, o_prev.OrderDate)) > 182
	AND o.CustomerID = c.CustomerID