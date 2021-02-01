SELECT Orders.ShipCountry, Orders.ShipCity
	FROM Orders
	GROUP BY ShipCountry, ShipCity
	HAVING COUNT(OrderID) > 2