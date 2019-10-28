USE Bank

CREATE TABLE Clients(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL
	)

CREATE TABLE AccountType(
	id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
	)

CREATE TABLE Accounts(
	Id INT PRIMARY KEY IDENTITY,
	AccountTypeId INT FOREIGN KEY REFERENCES AccountType(Id),
	Balance DECIMAL(15, 2) NOT NULL DEFAULT(0),
	ClientId INT FOREIGN KEY REFERENCES Clients(Id)
	)

INSERT INTO Clients(FirstName, LastName)
VALUES ('Gosho', 'Ivanov'),
	   ('Psesho', 'Petrov'),
	   ('Ivan', 'Iliev'),
	   ('Merry', 'Ivanova')

INSERT INTO AccountType([Name])
VALUES ('Cheking'),
	   ('Savings')

INSERT INTO Accounts(ClientId, AccountTypeId, Balance)
VALUES (1, 1, 175),
	   (2, 1, 275.56),
	   (3, 1, 138.01),
	   (4, 1, 40.30),
	   (4, 2, 375.50)

