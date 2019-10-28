CREATE DATABASE Supermarket

/* 01. DDL  */
CREATE TABLE Categories
(
 Id INT PRIMARY KEY IDENTITY,
 [Name] NVARCHAR(30) NOT NULL
)


CREATE TABLE Items
(
 Id INT PRIMARY KEY IDENTITY,
 [Name] NVARCHAR(30) NOT NULL,
 Price DECIMAL(18, 2) NOT NULL,
 CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id)
)


CREATE TABLE Employees
(
 Id INT PRIMARY KEY IDENTITY,
 FirstName NVARCHAR(50) NOT NULL,
 LastName NVARCHAR(50) NOT NULL,
 Phone CHAR(12) NOT NULL,
 Salary DECIMAL(18, 2) NOT NULL
)

CREATE TABLE Orders
(
 Id INT PRIMARY KEY IDENTITY,
 [DateTime] DATETIME2 NOT NULL,
 EmployeeId INT NOT NULL FOREIGN KEY REFERENCES Employees(Id)
)


CREATE TABLE OrderItems
(
 OrderId INT NOT NULL FOREIGN KEY REFERENCES Orders(Id),
 ItemId INT NOT NULL FOREIGN KEY REFERENCES Items(Id),
 Quantity INT NOT NULL CHECK(Quantity >= 1)

 CONSTRAINT PK_OrderItems PRIMARY KEY (OrderId, ItemId)
)


CREATE TABLE Shifts
(
 Id INT IDENTITY,
 EmployeeId INT NOT NULL FOREIGN KEY REFERENCES Employees(Id),
 CheckIn DATETIME2 NOT NULL,
 CheckOut DATETIME2 NOT NULL

 CONSTRAINT PK_Shifts PRIMARY KEY(Id, EmployeeId)
)


/* 02. Insert */
INSERT INTO Employees(FirstName, LastName, Phone, Salary)
VALUES  ('Stoyan', 'Petrov', '888-785-8573', 500.25),
		('Stamat', 'Nikolov', '789-613-1122', 999995.25),
		('Evgeni', 'Petkov', '645-369-9517', 1234.51),
		('Krasimir', 'Vidolov', '321-471-9982', 50.25)

INSERT INTO Items([Name], Price, CategoryId)
VALUES  ('Tesla battery', 154.25, 8),
		('Chess', 30.25, 8),
		('Juice', 5.32, 1),
		('Glasses', 10, 8),
		('Bottle of water',	1, 1)


/* 03. Update  */
UPDATE Items
SET Price *= 1.27
WHERE CategoryId IN (1, 2, 3)


/* 04. Delete  */
DELETE FROM OrderItems
WHERE OrderId = 48

DELETE FROM Orders
WHERE Id = 48


/* 05. Richest People  */
SELECT Id,
	   FirstName
FROM Employees
WHERE Salary > 6500
ORDER BY FirstName, Id


/* 06. Cool Phone Numbers  */
SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name],
	   Phone AS [Phone Number]
FROM Employees
WHERE Phone LIKE '3%'
ORDER BY FirstName, Phone


/* 07. Employee Statistics  */
SELECT e.FirstName,
	   e.LastName,
	   COUNT(o.Id) AS [Count]
FROM Employees AS e
LEFT JOIN Orders AS o ON o.EmployeeId = e.Id
GROUP BY e.FirstName, e.LastName
HAVING COUNT(o.Id) > 0
ORDER BY COUNT(o.Id) DESC, e.FirstName 



/* 08. Hard Workers Club  */
SELECT k.FirstName,
	   k.LastName,
	   k.[Work hours]
FROM (SELECT e.Id,
	 	     e.FirstName,
	 	     e.LastName,
	 	     AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) AS [Work hours]
	 FROM Employees AS e
	 JOIN Shifts AS s ON s.EmployeeId = e.Id
	 GROUP BY e.Id, e.FirstName, e.LastName) AS k
WHERE k.[Work hours] > 7
ORDER BY k.[Work hours] DESC, k.Id


/* 09. The Most Expensive Order  */
SELECT TOP(1)
	   o.Id,
	   SUM(oi.Quantity * i.Price) AS TotalPrice
FROM Orders AS o
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY o.Id
ORDER BY SUM(oi.Quantity * i.Price) DESC


/* 10. Rich Item, Poor Item  */
SELECT TOP(10)
	   o.Id,
	   MAX(i.Price) AS ExpensivePrice,
       MIN(i.Price) AS CheapPrice
FROM Orders AS o
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY o.Id
ORDER BY ExpensivePrice DESC, o.Id


/* 11. Cashiers  */
SELECT e.Id,
       e.FirstName,
	   e.LastName
FROM Employees AS e
JOIN Orders AS o ON o.EmployeeId = e.Id
GROUP BY e.Id, e.FirstName, e.LastName
ORDER BY e.Id

/* 12. Lazy Employees  */
SELECT k.Id,
       k.[Full Name]
FROM (SELECT e.Id,
	 	   CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name],
	 	   DATEDIFF(HOUR, s.CheckIn, s.CheckOut) AS ShiftDuration
	 FROM Employees AS e
	 JOIN Shifts AS s ON s.EmployeeId = e.Id) AS k
WHERE k.ShiftDuration < 4
GROUP BY k.Id, k.[Full Name]
ORDER BY k.Id


/* 13. Sellers  */
SELECT TOP(10)
	   CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name],
	   SUM(oi.Quantity * i.Price) AS [Total Price],
	   SUM(oi.Quantity) AS Items
FROM Employees AS e
JOIN Orders AS o ON o.EmployeeId = e.Id
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i.Id = oi.ItemId
WHERE o.[DateTime] < '2018-06-15'
GROUP BY e.FirstName, e.LastName
ORDER BY [Total Price] DESC, Items


/* 14. Tough Days  */
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name],
	   CASE
			WHEN DATEPART(WEEKDAY, s.CheckIn) = 2
			  THEN 'Monday'
			WHEN DATEPART(WEEKDAY, s.CheckIn) = 3
			  THEN 'Tuesday'
			WHEN DATEPART(WEEKDAY, s.CheckIn) = 4
			  THEN 'Wednesday'
			WHEN DATEPART(WEEKDAY, s.CheckIn) = 5
			  THEN 'Thursday'
			WHEN DATEPART(WEEKDAY, s.CheckIn) = 6
			  THEN 'Friday'
			WHEN DATEPART(WEEKDAY, s.CheckIn) = 7
			  THEN 'Saturday'
			WHEN DATEPART(WEEKDAY, s.CheckIn) = 1
			  THEN 'Sunday'
			END  AS [Day of week]
FROM Employees AS e
LEFT JOIN Orders AS o ON o.EmployeeId = e.Id
JOIN Shifts AS s ON s.EmployeeId = e.Id
WHERE o.Id IS NULL AND DATEDIFF(HOUR, s.CheckIn, s.CheckOut) > 12
ORDER BY e.Id


/* 15. Top Order per Employee  */
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name],
	   DATEDIFF(HOUR, s.CheckIn, s.CheckOut) AS WorkHours,
	   k.TotalPrice
FROM
	 (SELECT o.[DateTime],
	 	     o.EmployeeId,
	 	   SUM(oi.Quantity * i.Price) AS TotalPrice,
		   ROW_NUMBER() OVER(PARTITION BY o.EmployeeId ORDER BY o.EmployeeId , SUM(oi.Quantity * i.Price) DESC) AS [Rank]
	 FROM Orders AS o
	 JOIN OrderItems AS oi ON oi.OrderId = o.Id
	 JOIN Items AS i ON i.Id = oi.ItemId
	 GROUP BY o.[DateTime], o.EmployeeId, o.Id) AS k
JOIN Employees AS e ON e.Id = k.EmployeeId
JOIN Shifts AS s ON s.EmployeeId = k.EmployeeId
WHERE k.[Rank] = 1 AND k.[DateTime] BETWEEN s.CheckIn AND s.CheckOut
ORDER BY [Full Name], WorkHours, k.TotalPrice


/* 16. Average Profit per Day  */
SELECT DATEPART(DAY, o.[DateTime]) AS [Day],
	   FORMAT(AVG(oi.Quantity * i.Price), 'N2') AS [Total profit]
FROM Orders AS o
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY DATEPART(DAY, o.[DateTime])
ORDER BY [Day]


/* 17. Top Products  */
SELECT i.[Name],
	   c.[Name],
	   SUM(oi.Quantity) AS [Count],
	   SUM(oi.Quantity * i.Price) AS TotalPrice
FROM Items AS i
LEFT JOIN OrderItems AS oi ON oi.ItemId = i.Id
JOIN Categories AS c ON c.Id = i.CategoryId
GROUP BY i.[Name], c.[Name]
ORDER BY TotalPrice DESC, [Count] DESC


/* 18. Promotion Days  */
CREATE FUNCTION udf_GetPromotedProducts(@CurrentDate DATETIME, @StartDate DATETIME, @EndDate DATETIME, @Discount INT, @FirstItemId INT, @SecondItemId INT, @ThirdItemId INT)
RETURNS VARCHAR(80)
AS
BEGIN
	DECLARE @FirstItemPrice DECIMAL(15,2) = (SELECT Price 
											 FROM Items 
											 WHERE Id = @FirstItemId)

	DECLARE @SecondItemPrice DECIMAL(15,2) = (SELECT Price 
											  FROM Items 
											  WHERE Id = @SecondItemId)

	DECLARE @ThirdItemPrice DECIMAL(15,2) = (SELECT Price 
											 FROM Items 
											 WHERE Id = @ThirdItemId)

	IF (@FirstItemPrice IS NULL OR @SecondItemPrice IS NULL OR @ThirdItemPrice IS NULL)
	BEGIN
	 RETURN 'One of the items does not exists!'
	END

	IF (@CurrentDate <= @StartDate OR @CurrentDate >= @EndDate)
	BEGIN
	 RETURN 'The current date is not within the promotion dates!'
	END

	DECLARE @NewFirstItemPrice DECIMAL(15,2) = @FirstItemPrice - (@FirstItemPrice * @Discount / 100)
	DECLARE @NewSecondItemPrice DECIMAL(15,2) = @SecondItemPrice - (@SecondItemPrice * @Discount / 100)
	DECLARE @NewThirdItemPrice DECIMAL(15,2) = @ThirdItemPrice - (@ThirdItemPrice * @Discount / 100)

	DECLARE @FirstItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @FirstItemId)
	DECLARE @SecondItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @SecondItemId)
	DECLARE @ThirdItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @ThirdItemId)

	RETURN @FirstItemName + ' price: ' + CAST(ROUND(@NewFirstItemPrice,2) as varchar) + ' <-> ' +
		   @SecondItemName + ' price: ' + CAST(ROUND(@NewSecondItemPrice,2) as varchar)+ ' <-> ' +
		   @ThirdItemName + ' price: ' + CAST(ROUND(@NewThirdItemPrice,2) as varchar)
END


/* 19. Cancel Order  */
CREATE PROCEDURE usp_CancelOrder(@OrderId INT, @CancelDate DATETIME)
AS
BEGIN
	DECLARE @order INT = (SELECT Id 
						  FROM Orders 
						  WHERE Id = @OrderId)

	IF (@order IS NULL)
	BEGIN
		;THROW 51000, 'The order does not exist!', 1
	END

	DECLARE @OrderDate DATETIME = (SELECT [DateTime] 
								   FROM Orders 
								   WHERE Id = @OrderId)

	DECLARE @DateDiff INT = (SELECT DATEDIFF(DAY, @OrderDate, @CancelDate))

	IF (@DateDiff > 3)
	BEGIN
		;THROW 51000, 'You cannot cancel the order!', 2
	END

	DELETE FROM OrderItems
	WHERE OrderId = @OrderId

	DELETE FROM Orders
	WHERE Id = @OrderId
END


/* 20. Deleted Orders  */
CREATE TABLE DeletedOrders
(
	OrderId INT,
	ItemId INT,
	ItemQuantity INT
)

CREATE TRIGGER t_DeleteOrders
    ON OrderItems AFTER DELETE
    AS
    BEGIN
	  INSERT INTO DeletedOrders (OrderId, ItemId, ItemQuantity)
	  SELECT d.OrderId, d.ItemId, d.Quantity
	  FROM deleted AS d
    END