SELECT TOP 1 Products.ProductID, Products.ProductName, Products.UnitPrice
	FROM Products
	WHERE Products.CategoryID = 8
	ORDER BY Products.UnitPrice DESC