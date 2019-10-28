/* 01.Employees with Salary Above 35000 */
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS 
	SELECT FirstName,
		   LastName
	FROM Employees
	WHERE Salary > 35000
GO

--EXEC usp_GetEmployeesSalaryAbove35000 --> TO TEST YOUR CODE


/* 02.Employees with Salary Above Number */
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber (@Number DECIMAL(18, 4))
AS
	SELECT FirstName,
		   LastName
	FROM Employees
	WHERE Salary >= @Number

GO

--EXEC usp_GetEmployeesSalaryAboveNumber 48100 --> TO TEST YOUR CODE


/* 03.Town Names Starting With*/
CREATE PROC usp_GetTownsStartingWith(@StartingString VARCHAR(MAX))
AS
	SELECT [Name] 
	FROM Towns
	WHERE [Name] LIKE @StartingString + '%'

GO

--EXEC usp_GetTownsStartingWith 'b' --> TO TEST YOUR CODE


/* 04.Employees from Town */
CREATE PROC usp_GetEmployeesFromTown(@TownName VARCHAR(20))
AS 
	SELECT e.FirstName,
		   e.LastName
	FROM Employees AS e
	JOIN Addresses AS a ON a.AddressID = e.AddressID
	JOIN Towns AS t ON t.TownID = a.TownID
	WHERE t.[Name] = @TownName

GO

--EXEC usp_GetEmployeesFromTown 'Sofia' --> TO TEST YOUR CODE


/* 05.Salary Level Function */
CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4))
RETURNS VARCHAR(10)
BEGIN
	IF @Salary < 30000
		RETURN  'Low'
	ELSE IF @Salary <= 50000
		RETURN 'Average'
	
	RETURN 'High'
END

GO

--SELECT Salary,                                        
--	   dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level] --> TO TEST YOUR CODE
--FROM Employees


/* 06.Employees by Salary Level */
CREATE PROC usp_EmployeesBySalaryLevel(@SalaryLevel CHAR(10))
AS
	SELECT FirstName,
		   LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel

GO

--EXEC usp_EmployeesBySalaryLevel 'High' --> TO TEST YOUR CODE


/* 07.Define Function*/
CREATE FUNCTION ufn_IsWordComprised(@SetOfLetters VARCHAR(MAX) , @Word VARCHAR(MAX))
RETURNS BIT
BEGIN
	DECLARE @index INT = 1;
	DECLARE @result BIT = 1;
	WHILE(@index <= LEN(@Word))
	BEGIN
		IF(CHARINDEX(SUBSTRING(@WORD, @index, 1), @SetOfLetters, 1) = 0)
		BEGIN
			SET @result = 0;
			RETURN @result;
		END
		SET @index += 1;
	END 

	RETURN @result;
END

GO 

--SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves') --> TO TEST YOUR CODE


/* 08.Delete Employees and Departments */
CREATE PROC usp_DeleteEmployeesFromDepartment (@DepartmentId INT)
AS
BEGIN
    DECLARE @EmployeesIdToDelete TABLE (Id INT)

    INSERT INTO @EmployeesIdToDelete
         SELECT e.EmployeeID
           FROM Employees e
          WHERE e.DepartmentID = @DepartmentId

     ALTER TABLE Departments
    ALTER COLUMN ManagerID INT NULL
    
    DELETE FROM EmployeesProjects
          WHERE EmployeeID IN (SELECT Id FROM @EmployeesIdToDelete)

    UPDATE Employees
       SET ManagerID = NULL
     WHERE ManagerID IN (SELECT Id FROM @EmployeesIdToDelete)

    UPDATE Departments
       SET ManagerId = NULL
     WHERE ManagerID IN (SELECT Id FROM @EmployeesIdToDelete)

    DELETE FROM Employees
          WHERE EmployeeID IN (SELECT Id FROM @EmployeesIdToDelete)

    DELETE FROM Departments
          WHERE DepartmentID = @DepartmentId

        SELECT COUNT(*) AS [Employees Count] FROM Employees AS e
    INNER JOIN Departments AS d
            ON d.DepartmentID = e.DepartmentID
         WHERE e.DepartmentID = @DepartmentId
END

GO



/* 09.Find Full Name */
CREATE PROC usp_GetHoldersFullName
AS
	SELECT FirstName + ' ' + LastName AS [Full Name]
	FROM AccountHolders

GO

--EXEC usp_GetHoldersFullName --> TO TEST YOUR CODE


/* 10.People with Balance Higher Than */
CREATE PROC usp_GetHoldersWithBalanceHigherThan(@Balance DECIMAL(18, 2))
AS
	SELECT HighBalances.FirstName,
		   HighBalances.LastName
	FROM (SELECT ah.Id,
				 ah.FirstName,
				 ah.LastName
		  FROM AccountHolders AS ah
		  JOIN Accounts AS a ON a.AccountHolderId = ah.Id
		  GROUP BY ah.Id, ah.FirstName, ah.LastName
		  HAVING SUM(a.Balance) > @Balance) AS HighBalances
	ORDER BY HighBalances.FirstName, HighBalances.LastName

GO

--EXEC usp_GetHoldersWithBalanceHigherThan 200000 --> TO TEST YOUR CODE


/* 11.Future Value Function */
CREATE FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(18, 4), @YearlyInterestRate FLOAT, @YearsCount int)
RETURNS DECIMAL (18, 4)
BEGIN
	RETURN @Sum * POWER((1 + @YearlyInterestRate), @YearsCount)
END

GO

--SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5) --> TO TEST YOUR CODE


/* 12.Calculating Interest */
CREATE PROC usp_CalculateFutureValueForAccount(@AccountId INT, @InterestRate FLOAT)
AS
	SELECT a.Id AS [Account Id],
		   ah.FirstName,
		   ah.LastName,
		   a.Balance,
		   dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, 5) AS [Balance in 5 years]
	FROM Accounts AS a
	JOIN AccountHolders AS ah ON ah.Id = a.AccountHolderId
	WHERE a.Id = @AccountId

GO

--EXEC usp_CalculateFutureValueForAccount 1, 0.1 --> TO TEST YOUR CODE


/* 13.*Cash in User Games Odd Rows */
CREATE FUNCTION ufn_CashInUsersGames(@GameName VARCHAR(MAX))
RETURNS TABLE
	 RETURN (SELECT SUM(CashGameRows.Cash) AS SumCash
			FROM (SELECT g.[Name],
						 ug.Cash,
						 DENSE_RANK() OVER   
						 (PARTITION BY g.[Name] ORDER BY ug.Cash DESC) AS CashGameRow
				  FROM Games AS g
				  JOIN UsersGames AS ug ON ug.GameId = g.Id
				  GROUP BY g.[Name], ug.Cash) AS CashGameRows
			WHERE CashGameRows.CashGameRow % 2 = 1
			GROUP BY CashGameRows.[Name]
			HAVING CashGameRows.[Name] = @GameName)

GO

--SELECT * FROM dbo.ufn_CashInUsersGames ('Lily Stargazer') --> TO TEST YOUR CODE