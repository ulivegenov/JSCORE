/* 01.Find Names of All Employees by First Name */
SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'SA%'


/* 02. Find Names of All Employees by Last Name */
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%EI%'


/* 03. Find First Names of All Employess */
SELECT FirstName 
FROM Employees
WHERE DepartmentID IN (3, 10) AND 
	  DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005


/* 04.Find All Employees Except Engineers */
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'


/* 05.Find Towns with Name Length */
SELECT [Name] 
FROM Towns
WHERE LEN([Name]) BETWEEN 5 AND 6
ORDER BY [Name]


/* 06.Find Towns Starting With */
SELECT TownID, [Name] 
FROM Towns
WHERE SUBSTRING([Name], 1, 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name]


/* 07.Find Towns Not Starting With */
SELECT TownID, [Name] 
FROM Towns
WHERE SUBSTRING([Name], 1, 1) NOT IN ('R', 'B', 'D')
ORDER BY [Name]

GO

/* 08.Create View Employees Hired After */
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
FROM Employees
WHERE YEAR(HireDate) > 2000

GO

/* 09.Length of Last Name */
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5


/* 10.Rank Employees by Salary */
SELECT EmployeeID, FirstName, LastName, Salary,
	DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS Rank
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000 
ORDER BY Salary DESC


/* 11.Find All Employees with Rank 2*/
SELECT * 
FROM
	(SELECT EmployeeID, FirstName, LastName, Salary,
	DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS Rank
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000 
	) AS MySubQuery
WHERE MySubQuery.Rank = 2
ORDER BY Salary DESC
	

/*  12.Countries Holding 'A' */
SELECT CountryName, IsoCode AS [ISO Code] 
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode


/* 13.Mix of Peak and River Names */
SELECT PeakName, RiverName
	   ,LOWER((CONCAT(LEFT(PeakName, LEN(PeakName)-1), RiverName))) AS Mix
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix



/* 14.Games From 2011 and 2012 Year */
SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd', 'en-US') AS [Start]
FROM Games
WHERE YEAR([Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]


/* 15.User Email Providers */
SELECT Username, SUBSTRING(Email , CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider]
FROM Users
ORDER BY [Email Provider], Username


/* 16.Get Users with IPAddress Like Pattern */
SELECT Username, IpAddress FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username


/* 17.Show All Games with Duration */
SELECT [Name], 
	CASE
		WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
		WHEN DATEPART(HOUR, [Start]) >= 18 AND DATEPART(HOUR, [Start]) < 24 THEN 'Evening'
	END AS [Part of the Day],
	CASE
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		WHEN Duration IS NULL THEN 'Extra Long'
	END AS Duration
FROM Games
ORDER BY [Name], Duration, [Part of the Day]


/* 18.Orders Table */
SELECT ProductName, 
	   OrderDate,
	   DATEADD(DAY, 3, OrderDate) AS [Pay Due],
	   DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders