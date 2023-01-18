USE Candies

SELECT * FROM Products;
SELECT * FROM Wraps;
SELECT * FROM ProductsDeliveryConditions;


SELECT Wraps.[name], AVG([weight]) AS 'AVG weight'
FROM Products
JOIN Wraps ON wrapId=wraps.id
GROUP BY Wraps.[name]

SELECT Wraps.[name], AVG(value) AS 'AVG humidity'
FROM Products 
JOIN ProductsDeliveryConditions ON Products.id=productId
JOIN Wraps ON wrapId=wraps.id 
GROUP BY Wraps.[name]