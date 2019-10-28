CREATE DATABASE [Service]

/* 01. DDL  */
CREATE TABLE Users
(
 Id INT PRIMARY KEY IDENTITY,
 Username VARCHAR(30) UNIQUE NOT NULL,
 [Password] VARCHAR(50) NOT NULL,
 [Name] VARCHAR(50),
 Birthdate DATETIME2,
 Age INT CHECK(AGE BETWEEN 14 AND 110),
 Email VARCHAR(50) NOT NULL
)
 

CREATE TABLE Departments
(
 Id INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR(50) NOT NULL
)


CREATE TABLE Employees
(
 Id INT PRIMARY KEY IDENTITY,
 FirstName VARCHAR(25),
 LastName VARCHAR(25),
 Birthdate DATETIME2,
 Age INT CHECK(AGE BETWEEN 18 AND 110),
 DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)


CREATE TABLE Categories
(
 Id INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR(50) NOT NULL,
 DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Departments(Id)
)


CREATE TABLE [Status]
(
 Id INT PRIMARY KEY IDENTITY,
 [Label] VARCHAR(30) NOT NULL,
)


CREATE TABLE Reports
(
 Id INT PRIMARY KEY IDENTITY,
 CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
 StatusId INT NOT NULL FOREIGN KEY REFERENCES [Status](Id),
 OpenDate DATETIME2 NOT NULL,
 CloseDate DATETIME2,
 [Description] VARCHAR(200) NOT NULL,
 UserId INT NOT NULL FOREIGN KEY REFERENCES Users(Id),
 EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)


/* 02. Insert  */
INSERT INTO Employees(FirstName, LastName, Birthdate, DepartmentId)
VALUES ('Marlo', 'O''Malley', '1958-9-21', 1),
	   ('Niki',	'Stanaghan', '1969-11-26', 4),
	   ('Ayrton', 'Senna', '1960-03-21', 9),
	   ('Ronnie', 'Peterson', '1944-02-14',	9),
	   ('Giovanna', 'Amati', '1959-07-20', 5)


INSERT INTO Reports(CategoryId,	StatusId, OpenDate,	CloseDate, [Description], UserId, EmployeeId)
VALUES (1, 1, '2017-04-13', NULL ,'Stuck Road on Str.133', 6, 2),
	   (6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
	   (14,	2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
	   (4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)



/* 03. Update  */
UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL


/* 04. Delete  */
DELETE FROM Reports
WHERE StatusId = (SELECT Id
				  FROM [Status]
				  WHERE [Label] = '4')


/* 05. Unassigned Reports  */
SELECT [Description],
	   FORMAT(OpenDate, 'dd-MM-yyyy') AS OpenDate
FROM Reports AS r
WHERE EmployeeId IS NULL
ORDER BY r.OpenDate, [Description]


/* 06. Reports & Categories  */
SELECT r.[Description],
	   c.[Name]
FROM Reports AS r
JOIN Categories AS c ON c.Id = r.CategoryId
ORDER BY r.[Description], c.[Name]


/* 07. Most Reported Category  */
SELECT TOP(5)
	   c.[Name],
	   COUNT(r.Id) AS ReportsNumber
FROM Categories AS c
JOIN Reports AS r ON r.CategoryId = c.Id
GROUP BY c.[Name]
ORDER BY [ReportsNumber] DESC, c.[Name]


/* 08. Birthday Report  */
SELECT u.Username,
	   c.[Name]
FROM Users AS u
JOIN Reports AS r ON r.UserId = u.Id
JOIN Categories AS c ON c.Id = r.CategoryId
WHERE CONCAT(DAY(r.OpenDate), '-', MONTH(r.OpenDate)) = CONCAT(DAY(u.Birthdate), '-', MONTH(u.Birthdate))
ORDER BY u.Username, c.[Name]


/* 09. User per Employee  */
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS FullName,
	   COUNT(u.Id) AS UsersCount
FROM Employees AS e
LEFT JOIN Reports AS r ON r.EmployeeId = e.Id
LEFT JOIN Users AS u ON u.Id = r.UserId
GROUP BY e.FirstName, e.LastName
ORDER BY UsersCount DESC, FullName


/* 10. Full Info  */
SELECT ISNULL(NULLIF(CONCAT(e.FirstName, ' ', e.LastName) , ' '), 'None') AS Employee,
       ISNULL(d.[Name], 'None') AS Department,
	   c.[Name] AS Category,
	   r.[Description],
	   FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate,
	   s.[Label],
	   u.[Name]
FROM Reports AS r
LEFT JOIN Employees AS e ON e.Id = r.EmployeeId
LEFT JOIN Departments AS d ON d.Id = e.DepartmentId
JOIN Categories AS c ON c.Id = r.CategoryId
JOIN [Status] AS s ON s.Id = r.StatusId
JOIN Users AS u ON u.Id = r.UserId
ORDER BY e.FirstName DESC, e.LastName DESC, Department, Category, r.[Description], r.OpenDate, s.[Label], u.[Name]

GO
/* 11. Hours to Complete  */
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	IF(@StartDate IS NULL)
	BEGIN
		RETURN 0;
	END

	IF(@EndDate IS NULL)
	BEGIN
		RETURN 0;
	END

	DECLARE @TotalHours INT = DATEDIFF(HOUR, @StartDate , @EndDate);

	RETURN @TotalHours
END

GO
/* 12. Assign Employee  */
CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
	DECLARE @employeeDepartmentId INT = (SELECT TOP(1) 
											    DepartmentId
									      FROM Employees
										  WHERE Id = @EmployeeId);

	DECLARE @departmentCategoryId INT = (SELECT TOP(1)
												c.DepartmentId
										 FROM Reports AS r
										 JOIN Categories AS c ON c.Id = r.CategoryId
										 WHERE r.Id = @ReportId)

	IF(@employeeDepartmentId = @departmentCategoryId)
	BEGIN
		UPDATE Reports
		SET EmployeeId = @EmployeeId
		WHERE Id = @ReportId
	END
	ELSE
	BEGIN
		RAISERROR('Employee doesn''t belong to the appropriate department!', 11, 1);
	END
