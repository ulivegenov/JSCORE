/**** DON'T FORGET TO EXECUTE EVERY CALL TO TAKE AFFECT!!! ****/

/* Problem 1.Create Database */
CREATE DATABASE Minions


/* Problem 2.Create Tables */
USE Minions

CREATE TABLE Minions(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	Age INT 
)

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)


/* Problem 3.Alter Minions Table */
ALTER TABLE Minions
ADD	TownId INT FOREIGN KEY REFERENCES Towns(Id)


/* Problem 4.Insert Records in Both Tables */ -- !!!Paste this in judge, without SET IDENTITY CODE!!!
SET IDENTITY_INSERT Towns ON -- without this row
INSERT INTO Towns(Id,[Name])
VALUES	(1, 'Sofia'),
		(2, 'Plovdiv'),
		(3, 'Varna')

SET IDENTITY_INSERT Towns OFF -- without this row

SET IDENTITY_INSERT Minions ON -- without this row
INSERT INTO Minions(Id, [Name], Age, TownId)
VALUES	(1,'Kevin', 22, 1),
		(2,'Bob', 15, 3),
		(3, 'Steward',NULL,2)


/* Problem 5.Truncate Table Minions */
TRUNCATE TABLE Minions
--or DELETE FROM Minions


/* Problem 6.Drop All Tables */
DROP TABLE Minions
DROP TABLE Towns


/* Problem 7.Create Table People */ -- !!!Paste this in judge!!!
CREATE DATABASE EXERCISE_ONE -- without this row
USE EXERCISE_ONE -- without this row

CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX) CHECK(DATALENGTH(Picture) > 1024 * 1024 * 2),
	Height DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	Gender VARCHAR(1) NOT NULL CONSTRAINT chk_Gender CHECK(Gender = 'm' OR Gender = 'f'),
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People([Name], Picture, Height, [Weight], Gender, Birthdate, Biography)
VALUES	('Gosho Petrov', NULL, 1.85, 86.33, 'm', CAST('1990-03-06' AS date) , 'Office manager'),
		('Strahil Sheviyakov', NULL, 1.93, 245.23, 'm', CAST('2000-09-11' AS date), 'Sumo player'),
		('Ginka Ivanova', NULL, 1.64, 65.00, 'f', CAST('1980-07-26' AS date), 'Lawyer'),
		('Gatso Batsov', NULL, 1.85, 70.12, 'm', CAST('1990-12-25' AS date), 'Football player'),
		('Mitka Draganova', NULL, 1.69, 75.34, 'f', CAST('1980-02-23' AS date), 'Female wrestler')


/* Problem 8.Create Table Users */ -- !!!Paste this in judge!!!
CREATE TABLE Users(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024),
	LastLoginTime DATETIME,
	IsDeleted BIT
)

INSERT INTO Users(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
VALUES	('Pesho', 'Fsafjgl435', NULL, NULL, 1),
		('Minka', '1245SFG', NULL, NULL, 0),
		('Stamat', '436523gas', NULL, NULL, 0),
		('Gavril', '124135', NULL, NULL, 0),
		('Dimitrichka', '253463fsdgs', NULL, NULL, 0)


/* Problem 9.Change Primary Key */
ALTER TABLE Users
DROP PK__Users__3214EC07A5C443E0

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id, Username)


/* Problem 10.Add Check Constraint*/
ALTER TABLE Users
ADD CONSTRAINT PasswordLength CHECK(LEN(Password) >= 5)


/* Problem 11.Set Default Value of a Field */
ALTER TABLE Users
ADD DEFAULT GETDATE() FOR LastLoginTime


/* Problem 12.Set Unique Field */
ALTER TABLE Users
DROP PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Id PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT UQ_Username UNIQUE(Username)

ALTER TABLE Users
DROP CONSTRAINT UQ__Users__536C85E434CE0162  

ALTER TABLE Users
ADD CONSTRAINT UsernameLength CHECK(LEN(Username) >= 3)


/* Problem 13.Movies Database */ -- !!!Paste this in judge!!!
-- CREATE DATABASE
CREATE DATABASE Movies -- without this row

-- CREATE TABLES
CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL UNIQUE,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(100) NOT NULL UNIQUE,
	Notes NVARCHAR(MAX)
) 

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(150) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear INT NOT NULL,
	[Length] TIME,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Rating DECIMAL(2, 1),
	Notes NVARCHAR(MAX)
)

-- INSERT DATA
INSERT INTO Directors(DirectorName, Notes) VALUES
('Steven Spielberg', 'One of the most influential personalities in the history of cinema.'),
('Martin Scorsese', 'Martin Charles Scorsese was born on November 17, 1942 in Queens, New York City.'),
('Alfred Hitchcock', 'Alfred Joseph Hitchcock was born in Leytonstone, Essex, England.'),
('Stanley Kubrick', 'Stanley Kubrick was born in Manhattan, New York City.'),
(' Quentin Tarantino', 'Quentin Jerome Tarantino was born in Knoxville, Tennessee.')

INSERT INTO Genres(GenreName, Notes) VALUES
('Action', 'An action story is similar to adventure, and the protagonist usually takes a risky turn, which leads to desperate situations.'),
('Adventure', 'An adventure story is about a protagonist who journeys to epic or distant places to accomplish something.'),
('Comedy', 'Comedy is a story that tells about a series of funny, or comical events, intended to make the audience laugh.'),
('Crime', 'A crime story is about a crime that is being committed or was committed.'),
('Horror', 'A horror story is told to deliberately scare or frighten the audience, through suspense, violence or shock.')

INSERT INTO Categories(CategoryName, Notes) VALUES
('Western films', NULL),
('Adventure films', NULL),
('Comedy films', NULL),
('Detective and mystery films', NULL),
('Zombie films', NULL)

INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes) VALUES
('Catch Me If You Can', 1, 2002, '2:21:00', 4, 4, 8.1, 'Stars: Leonardo DiCaprio, Tom Hanks, Christopher Walken'),
('Taxi Driver', 2, 1976, '1:54:00', 4, 4, 8.3, 'Stars: Robert De Niro, Jodie Foster, Cybill Shepherd'),
('Psycho', 3, 1960, '1:49:00', 5, 2, 8.5, 'Stars: Anthony Perkins, Janet Leigh, Vera Miles'),
('2001: A Space Odyssey', 4, 1968, '2:29:00', 2, 2, 8.3, 'Stars: Keir Dullea, Gary Lockwood, William Sylvester'),
('The Hateful Eight', 5, 2015, '2:48:00', 4, 4, 7.8, 'Stars: Samuel L. Jackson, Kurt Russell, Jennifer Jason Leigh')


/* Problem 14.Car Rental Database */ -- !!!Paste this in judge!!!
-- CREATE DATABASE
CREATE DATABASE CarRental -- without this row

-- CREATE TABLES
CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(100) NOT NULL,
	DailyRate INT NOT NULL,
	WeeklyRate INT NOT NULL,
	MonthlyRate INT NOT NULL,
	WeekendRate INT NOT NULL
)

CREATE TABLE Cars(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber NVARCHAR(20) NOT NULL UNIQUE,
	Manufacturer NVARCHAR(30) NOT NULL,
	Model NVARCHAR(30) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors INT NOT NULL,
	Picture VARBINARY(MAX),
	Condition NVARCHAR(MAX),
	Available BIT NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Customers(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber NVARCHAR(20) NOT NULL UNIQUE,
	FullName NVARCHAR(150) NOT NULL,
	[Address] NVARCHAR(250) NOT NULL,
	City NVARCHAR(50) NOT NULL,
	ZIPCode NVARCHAR(50),
	Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
	CarId INT FOREIGN KEY REFERENCES Cars(Id),
	TankLevel INT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage AS KilometrageEnd - KilometrageStart,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays AS DATEDIFF(DAY, StartDate, EndDate),
	RateApplied INT NOT NULL,
	TaxRate AS RateApplied * 0.2,
	OrderStatus BIT NOT NULL,
	Notes NVARCHAR(MAX)
)

-- INSERT DATA
INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('Limousine', 65, 350, 1350, 120),
('SUV', 85, 500, 1800, 160),
('Mini VAN', 40, 230, 850, 70)


INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear,
CategoryId, Doors, Picture, Condition, Available) VALUES
('B8877PP', 'Audi', 'A6', 2001, 1, 4, NULL, 'Good', 1),
('GH17GH78', 'Opel', 'Corsa', 2014, 3, 5, NULL, 'Very good', 0),
('CT17754GT', 'VW', 'Touareg', 2008, 2, 5, NULL, 'Zufrieden', 1)


INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
('Strahil', 'Peshev', 'QA', 'Alcoholic'),
('Dako', 'Petkov', 'HR', 'The most loyalty employee'),
('Stamat', 'Jonkov', 'DevOps', 'Employee of the year')


INSERT INTO Customers(DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes) VALUES
('GHS8344JFO', 'Dick Drinkwater', 'Winter str. 25', 'Chikago', NULL, NULL),
('KJGL4W554478', 'Sergey Ivankov', 'Shtaigich 37', 'Perm', NULL, NULL),
('LK23KG32KWG', 'Ibrahima Bakayoko', 'Dorcel str. 56', 'Paris', NULL, NULL)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, 
StartDate, EndDate, RateApplied, OrderStatus, Notes) VALUES
(2, 1, 3, 26, 48125, 49885, CAST('2019-07-08' AS date), CAST('2019-07-10' AS date), 300, 1, 'Excellent condition'),
(1, 2, 1, 40, 5524, 5984, CAST('2019-09-06' AS date), CAST('2019-09-20' AS date), 1800, 1, 'Broken front left window'),
(3, 3, 1, 58, 33455, 34554, CAST('2019-08-01' AS date), CAST('2019-08-09' AS date), 1050, 1, 'Excellent condition')


/* Problem 15.Hotel Database */ -- !!!Paste this in judge!!!
-- CREATE DATABASE
CREATE DATABASE Hotel -- without this row

-- CREATE TABLES
CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Customers(
	AccountNumber INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber NVARCHAR(30),
	EmergencyName NVARCHAR(100),
	EmergencyNumber NVARCHAR(30),
	Notes NVARCHAR(MAX)
)

CREATE TABLE RoomStatus(
	RoomStatus NVARCHAR(50) PRIMARY KEY,
	Notes NVARCHAR(MAX)
)

CREATE TABLE RoomTypes(
	RoomType NVARCHAR(50) PRIMARY KEY,
	Notes NVARCHAR(MAX)
)

CREATE TABLE BedTypes(
	BedType NVARCHAR(50) PRIMARY KEY,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Rooms(
	RoomNumber INT PRIMARY KEY,
	RoomType NVARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
	BedType NVARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
	Rate DECIMAL(6, 2) NOT NULL,
	RoomStatus BIT NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Payments(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATE NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	FirstDateOccupied DATE NOT NULL,
	LastDateOccupied DATE NOT NULL,
	TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied),
	AmountCharged DECIMAL (10, 2) NOT NULL,
	TaxRate DECIMAL (8, 2) NOT NULL,
	TaxAmount AS AmountCharged * TaxRate,
	PaymentTotal AS AmountCharged + AmountCharged * TaxRate,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Occupancies(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	DateOccupied DATE NOT NULL,
	AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
	RateApplied DECIMAL(6, 2),
	PhoneCharge DECIMAL(8, 2),
	Notes NVARCHAR(MAX)
)

-- INSERT DATA
INSERT INTO Employees(FirstName, LastName, Title) VALUES
('Pepo', 'Takov', 'Cleaner'),
('Gocho', 'Ivanov', 'Reception'),
('Pijo', 'Pendov', 'Technical department')

INSERT INTO Customers(FirstName, LastName, PhoneNumber) VALUES
('Petraki', 'Ushev', '+359888666555'),
('Gancho', 'Stoykov', '+359866444222'),
('Strahi', 'Dimchov', '+35977555333')

INSERT INTO RoomStatus(RoomStatus) VALUES
('occupied'),
('non occupied'),
('repairs')

INSERT INTO RoomTypes(RoomType) VALUES
('single'),
('double'),
('appartment')

INSERT INTO BedTypes(BedType) VALUES
('single'),
('double'),
('couch')

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus) VALUES
(201, 'single', 'single', 40.0, 1),
(205, 'double', 'double', 70.0, 0),
(208, 'appartment', 'double', 110.0, 1)

-- CAST('2012-06-08' AS date)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, AmountCharged, TaxRate) VALUES
(1, CAST('2019-11-25' AS date), 2, CAST('2019-11-30' AS date), CAST('2019-12-04' AS date), 250.0, 0.2),
(3, CAST('2019-06-03' AS date), 3, CAST('2019-06-06' AS date), CAST('2019-06-09' AS date), 340.0, 0.2),
(3, CAST('2019-02-25' AS date), 2, CAST('2019-02-27' AS date), CAST('2019-03-04' AS date), 500.0, 0.2)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge) VALUES
(2, CAST('2019-02-04' AS date), 3, 205, 70.0, 12.54),
(2, CAST('2019-04-09' AS date), 1, 201, 40.0, 11.22),
(3, CAST('2019-06-08' AS date), 2, 208, 110.0, 10.05)


/* Problem 16.Create SoftUni Database */
CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)


CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY,
	AddressText NVARCHAR(300) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	JobTitle NVARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATE NOT NULL,
	Salary DECIMAL(10, 2),
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)


/* Problem 17.Backup Database */
BACKUP DATABASE SoftUni TO DISK = 'E:\SoftUni\C#-DB\MS-SQL-Server\BACKUPS\test.bak'


RESTORE DATABASE SoftUni FROM DISK = 'E:\SoftUni\C#-DB\MS-SQL-Server\BACKUPS\test.bak'

USE SoftUni

/* Problem 18.Basic Insert */
INSERT INTO Towns([Name]) VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments([Name]) VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary ) VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88)



/* Problem 19.Basic Select All Fields */
SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees


/* Problem 20.Basic Select All Fields and Order Them */
SELECT * FROM Towns ORDER BY [Name]

SELECT * FROM Departments ORDER BY [Name]

SELECT * FROM Employees ORDER BY Salary DESC


/* Problem 21.Basic Select Some Fields */
SELECT [Name] FROM Towns ORDER BY [Name]

SELECT [Name] FROM Departments ORDER BY [Name]

SELECT FirstName, LastName, JobTitle, Salary FROM Employees ORDER BY Salary DESC


/* Problem 22.Increase Employees Salary */
UPDATE Employees
SET Salary = Salary * 1.1
SELECT Salary FROM Employees


/* Problem 23.Decrease Tax Rate */
USE Hotel -- without this row
UPDATE Payments
SET TaxRate = TaxRate * 0.97
SELECT TaxRate FROM Payments


/* Problem 24.Delete All Records */
TRUNCATE TABLE Occupancies