/* 14.Create Table Logs */
CREATE TRIGGER tr_WriteLogs ON Accounts FOR UPDATE
AS
	DECLARE @newSum  DECIMAL(15, 2) = (SELECT Balance FROM inserted)
	DECLARE @oldSum DECIMAL(15, 2) = (SELECT Balance FROM deleted)
	DECLARE @accountId INT = (SELECT Id FROM inserted)
	
	INSERT INTO Logs (AccountId, OldSum, NewSum) 
	VALUES			 (@accountId, @oldSum, @newSum)
GO

/* 15.Create Table Emails */
CREATE TABLE NotificationEmails(Id INT PRIMARY KEY IDENTITY, Recipient INT FOREIGN KEY REFERENCES Accounts(Id), [Subject] VARCHAR(50), Body VARCHAR(MAX))
GO
CREATE TRIGGER tr_EmailSender ON Logs FOR INSERT
AS
	DECLARE @accountId INT = (SELECT AccountId FROM inserted)
	DECLARE @subject VARCHAR(50) = 'Balance change for account: ' + CAST(@accountId AS VARCHAR(20))
	DECLARE @oldSum VARCHAR(20) = CAST((SELECT TOP(1) OldSum FROM inserted) AS VARCHAR(20))
	DECLARE @newSum VARCHAR(20) = CAST((SELECT TOP(1) NewSum FROM inserted) AS VARCHAR(20))
	DECLARE @body VARCHAR(MAX) = 'On ' + CONVERT(VARCHAR, GETDATE(), 103) + ' your balance was changed from ' + @newSum + ' to ' + @oldSum + ' .'

	INSERT INTO NotificationEmails(Recipient, [Subject], Body)
	VALUES (@accountId, @subject, @body)
GO


/* 16.Deposit Money */
CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL (15, 4))
AS
	BEGIN TRANSACTION
	DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @AccountId)

	IF (@account IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid account id!', 16, 1)
		RETURN
	END

	IF (@MoneyAmount < 0)
	BEGIN
		ROLLBACK
		RAISERROR('Negative amount!', 16, 2)
		RETURN
	END

	UPDATE Accounts
	SET Balance += @MoneyAmount
	WHERE Id = @AccountId
COMMIT
GO

/* 17.Withdraw Money Procedure*/
CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL (15, 4))
AS
	BEGIN TRANSACTION
	DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @AccountId)

	IF (@account IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR ('Invalid account!', 16, 1)
		RETURN
	END

	IF (@MoneyAmount < 0)
	BEGIN
		ROLLBACK
		RAISERROR ('Negative amount', 16, 2)
		RETURN
	END

	UPDATE Accounts
	SET Balance -= @MoneyAmount
	WHERE Id = @AccountId
COMMIT

GO


/* 18.Money Transfer */
CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL (15, 4))
AS
	BEGIN TRANSACTION
	DECLARE @senderAccount INT = (SELECT Id FROM Accounts WHERE Id = @SenderId)
	DECLARE @receiverAccount INT = (SELECT Id FROM Accounts WHERE Id = @ReceiverId)

	IF (@senderAccount IS NULL OR @receiverAccount IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR('Invalid account!', 16, 1)
		RETURN
	END

	IF (@Amount < 0)
	BEGIN
		ROLLBACK
		RAISERROR('Negative amount!', 16, 2)
		RETURN
	END

	UPDATE Accounts
	SET Balance -= @Amount
	WHERE Id = @SenderId

	UPDATE Accounts
	SET Balance += @Amount
	WHERE Id = @ReceiverId
COMMIT
GO

/* Problem 19. Trigger */

CREATE TRIGGER tr_UserGameItems 
ON UserGameItems 
INSTEAD OF INSERT 
AS
BEGIN 
    INSERT INTO UserGameItems
         SELECT i.Id, 
                ug.Id 
           FROM inserted
      INNER JOIN UsersGames AS ug
             ON UserGameId = ug.Id
     inner JOIN Items AS i
             ON ItemId = i.Id
          WHERE ug.Level >= i.MinLevel
END
GO

    UPDATE UsersGames
       SET Cash += 50000
      FROM UsersGames AS ug
INNER JOIN Users AS u
        ON ug.UserId = u.Id
INNER JOIN Games AS g
        ON ug.GameId = g.Id
     WHERE g.Name = 'Bali' 
       AND u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
GO

CREATE PROC usp_BuyItems(@Username VARCHAR(100)) 
AS
BEGIN
    DECLARE @UserId INT = (SELECT Id FROM Users WHERE Username = @Username)
    DECLARE @GameId INT = (SELECT Id FROM Games WHERE Name = 'Bali')
    DECLARE @UserGameId INT = (SELECT Id FROM UsersGames WHERE UserId = @UserId AND GameId = @GameId)
    DECLARE @UserGameLevel INT = (SELECT Level FROM UsersGames WHERE Id = @UserGameId)

    DECLARE @counter INT = 251

    WHILE(@counter <= 539)
    BEGIN
        DECLARE @ItemId INT = @counter
        DECLARE @ItemPrice MONEY = (SELECT Price FROM Items WHERE Id = @ItemId)
        DECLARE @ItemLevel INT = (SELECT MinLevel FROM Items WHERE Id = @ItemId)
        DECLARE @UserGameCash MONEY = (SELECT Cash FROM UsersGames WHERE Id = @UserGameId)

        IF(@UserGameCash >= @ItemPrice AND @UserGameLevel >= @ItemLevel)
        BEGIN
            UPDATE UsersGames
            SET Cash -= @ItemPrice
            WHERE Id = @UserGameId

            INSERT INTO UserGameItems VALUES
            (@ItemId, @UserGameId)
        END

        SET @counter += 1
        
        IF(@counter = 300)
        BEGIN
            SET @counter = 501
        END
    END
END


/* 20.*Massive Shopping */

DECLARE @userName NVARCHAR(max) = 'Stamat'
DECLARE @gameName NVARCHAR(max) = 'Safflower'
DECLARE @userID INT = (
                        SELECT Id 
                          FROM Users 
                         WHERE Username = @userName
                      )
DECLARE @gameID INT = (
                        SELECT Id 
                          FROM Games 
                         WHERE Name = @gameName
                      )
DECLARE @userMoney MONEY = (
                        SELECT Cash 
                          FROM UsersGames
                         WHERE UserId = @userID AND GameId = @gameID
                      )
DECLARE @itemsTotalPrice MONEY
DECLARE @userGameID int = (
                        SELECT Id 
                          FROM UsersGames 
                         WHERE UserId = @userID AND GameId = @gameID
                      )

BEGIN TRANSACTION
      SET @itemsTotalPrice = (SELECT SUM(Price) 
     FROM Items 
    WHERE MinLevel BETWEEN 11 AND 12)

    IF(@userMoney - @itemsTotalPrice >= 0)
    BEGIN
        INSERT INTO UserGameItems
        SELECT i.Id, @userGameID FROM Items AS i
        WHERE i.Id IN (
                        SELECT Id 
                          FROM Items 
                         WHERE MinLevel BETWEEN 11 AND 12
                      )

        UPDATE UsersGames
        SET Cash -= @itemsTotalPrice
        WHERE GameId = @gameID AND UserId = @userID
        COMMIT
    END
    ELSE
    BEGIN
        ROLLBACK
    END

SET @userMoney = (
                    SELECT Cash 
                      FROM UsersGames 
                     WHERE UserId = @userID AND GameId = @gameID
                 )
BEGIN TRANSACTION
    SET @itemsTotalPrice = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21)

    IF(@userMoney - @itemsTotalPrice >= 0)
    BEGIN
        INSERT INTO UserGameItems
        SELECT i.Id, @userGameID FROM Items AS i
        WHERE i.Id IN (
                        SELECT Id 
                          FROM Items 
                         WHERE MinLevel BETWEEN 19 AND 21
                      )

        UPDATE UsersGames
        SET Cash -= @itemsTotalPrice
        WHERE GameId = @gameID AND UserId = @userID
        COMMIT
    END
    ELSE
    BEGIN
        ROLLBACK
    END

  SELECT Name AS [Item Name]
    FROM Items
   WHERE Id IN (
                SELECT ItemId 
                  FROM UserGameItems 
                 WHERE UserGameId = @userGameID
               )
ORDER BY [Item Name]


/* 21.Employees with Three Projects */

CREATE PROC usp_AssignProject(@EmployeeId INT, @ProjectID INT) 
AS
	BEGIN TRANSACTION
	DECLARE @employee INT = (SELECT EmployeeID FROM Employees WHERE EmployeeID = @EmPloyeeId)
	DECLARE @project INT = (SELECT ProjectID FROM Projects WHERE ProjectID = @ProjectID)
	DECLARE @currentEmployeeProjectsCount INT = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID = @EmployeeId)

	IF(@employee IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR ('Invalid employee id!', 16, 2)
		RETURN
	END

	IF(@project IS NULL)
	BEGIN
		ROLLBACK
		RAISERROR ('Invalid project id!', 16, 2)
		RETURN
	END

	IF(@currentEmployeeProjectsCount >= 3)
	BEGIN
		ROLLBACK
		RAISERROR('The employee has too many projects!', 16, 1)
		RETURN
	END

	
	INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
	VALUES (@EmployeeId, @ProjectID)

COMMIT

GO


/* 22.Delete Employees */
CREATE TABLE Deleted_Employees
(EmployeeId INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(50),
LastName VARCHAR(50),
MiddleName VARCHAR(50),
JobTitle VARCHAR(50),
DepartmentId INT,
Salary DECIMAL(15, 4))

GO

CREATE TRIGGER tr_DeletedEmployees ON Employees FOR DELETE
AS
	INSERT INTO Deleted_Employees(FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
	SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentID, Salary FROM deleted