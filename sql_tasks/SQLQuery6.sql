SELECT c.CustomerID, c.ContactName
	FROM Customers c, (
		SELECT DISTINCT o1.CustomerID
			FROM Orders o1
			INNER JOIN Orders o2 ON o1.CustomerID = o2.CustomerID
			WHERE o1.CustomerID = o2.CustomerID
			AND o1.OrderDate != o2.OrderDate
			AND ABS(DATEDIFF(MONTH, o1.OrderDate, o2.OrderDate)) > 6
	) res
	WHERE c.CustomerID = res.CustomerID