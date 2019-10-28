/* 01. DDL  */
CREATE TABLE Planes
(
 Id INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR(30) NOT NULL,
 Seats INT NOT NULL,
 [Range] INT NOT NULL
)


CREATE TABLE Flights
(
 Id INT PRIMARY KEY IDENTITY,
 DepartureTime DATETIME,
 ArrivalTime DATETIME,
 Origin VARCHAR(50) NOT NULL,
 Destination VARCHAR(50) NOT NULL,
 PlaneId INT NOT NULL FOREIGN KEY REFERENCES Planes(Id)
)

CREATE TABLE Passengers
(
 Id INT PRIMARY KEY IDENTITY,
 FirstName VARCHAR(30) NOT NULL,
 LastName VARCHAR(30) NOT NULL,
 Age INT NOT NULL,
 [Address] VARCHAR(30) NOT NULL,
 PassportId CHAR(11) NOT NULL
)


CREATE TABLE LuggageTypes
(
 Id INT PRIMARY KEY IDENTITY,
 [Type] VARCHAR(30) NOT NULL
)


CREATE TABLE Luggages
(
 Id INT PRIMARY KEY IDENTITY,
 LuggageTypeId INT NOT NULL FOREIGN KEY REFERENCES LuggageTypes(Id),
 PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id),
)


CREATE TABLE Tickets
(
 Id INT PRIMARY KEY IDENTITY,
 PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id),
 FlightId INT NOT NULL FOREIGN KEY REFERENCES Flights(Id),
 LuggageId INT NOT NULL FOREIGN KEY REFERENCES Luggages(Id),
 Price DECIMAL(15, 2) NOT NULL
)

/* 02. Insert  */
INSERT INTO Planes([Name], Seats, [Range]) 
VALUES  ('Airbus 336', 112, 5132),
		('Airbus 330',	432, 5325),
		('Boeing 369',	231, 2355),
		('Stelt 297',	254, 2143),
		('Boeing 338',	165, 5111),
		('Airbus 558',	387, 1342),
		('Boeing 128',	345, 5541)


INSERT INTO LuggageTypes([Type])
VALUES ('Crossbody Bag'),
	   ('School Backpack'),
	   ('Shoulder Bag')


/* 03. Update  */
UPDATE Tickets
SET Price *= 1.13
WHERE FlightId = (SELECT TOP(1) Id 
				  FROM Flights 
				  WHERE Destination = 'Carlsbad')

/* 04. Delete  */

-- Exec this query to see flights to Carlsbad Id's

 --SELECT *
 --FROM Flights
 --WHERE Destination = 'Ayn Halagim'

 DELETE Tickets
 WHERE FlightId = (SELECT TOP(1) Id 
				   FROM Flights 
				   WHERE Destination = 'Ayn Halagim')

 DELETE Flights
 WHERE Destination = 'Ayn Halagim'


 /* 05. Trips  */
 SELECT Origin,
	    Destination
 FROM Flights
 ORDER BY Origin, Destination


 /* 06. The "Tr" Planes  */
 SELECT Id,
		[Name],
		Seats,
		[Range]
 FROM Planes
 WHERE [Name] LIKE '%tr%'
 ORDER BY Id, [Name], Seats, [Range]


 /* 07. Flight Profits  */
 SELECT FlightId,
	    SUM(Price) AS Price
 FROM Tickets
 GROUP BY FlightId
 ORDER BY SUM(Price) DESC, FlightId


 /* 08. Passanger and Prices  */
 SELECT TOP(10)
		p.FirstName,
		p.LastName,
		t.Price
 FROM Passengers AS p
 JOIN Tickets AS t ON t.PassengerId = p.Id
 ORDER BY t.Price DESC, p.FirstName, p.LastName


 /* 09. Top Luggages  */
 SELECT lT.[Type],
		COUNT(l.PassengerId) AS MostUsedLuggage
 FROM Luggages AS l
 JOIN LuggageTypes AS lt ON lt.Id = l.LuggageTypeId
 GROUP BY lt.[Type]
 ORDER BY COUNT(l.PassengerId) DESC, lT.[Type]


 /* 10. Passanger Trips */
 SELECT p.FirstName + ' ' + p.LastName AS [Full Name],
		f.Origin,
		f.Destination
 FROM Passengers AS p
 JOIN Tickets AS t ON t.PassengerId = p.Id
 JOIN Flights AS f ON f.Id = t.FlightId
 ORDER BY [Full Name], f.Origin, f.Destination


 /* 11. Non Adventures People  */
 SELECT p.FirstName,
		p.LastName,
		p.Age
 FROM Passengers AS p
 LEFT JOIN Tickets AS t ON t.PassengerId = p.Id
 WHERE t.Id IS NULL
 ORDER BY p.Age DESC, p.FirstName, p.LastName


 /* 12. Lost Luggages  */
 SELECT p.PassportId AS [Passport Id],
		p.[Address]
 FROM Passengers AS p
 LEFT JOIN Luggages AS l ON l.PassengerId = p.Id
 WHERE l.PassengerId IS NULL
 ORDER BY p.PassportId, p.[Address]


 /* 13. Count of Trips  */
 SELECT p.FirstName,
		p.LastName,
		COUNT(t.Id) AS [Total Trips]
 FROM Passengers AS p
 LEFT JOIN Tickets AS t ON t.PassengerId = p.Id
 GROUP BY p.FirstName, p.LastName
 ORDER BY COUNT(t.Id) DESC, p.FirstName, p.LastName


 /* 14. Full Info  */
 SELECT p.FirstName + ' ' + p.LastName AS [Full Name],
		pl.[Name] AS [Plane Name],
		f.Origin + ' - ' + f.Destination AS Trip,
		lt.[Type] AS [Luggage Type]
 FROM Passengers AS p
 JOIN Tickets AS t ON t.PassengerId = p.Id
 JOIN Flights AS f ON f.Id = t.FlightId
 JOIN Planes AS pl ON pl.Id = f.PlaneId
 JOIN Luggages AS l ON l.Id = t.LuggageId
 JOIN LuggageTypes AS lt ON lt.Id = l.LuggageTypeId
 ORDER BY [Full Name], [Plane Name], f.Origin, f.Destination, [Luggage Type]


 /* 15. Most Expesnive Trips  */
 SELECT k.FirstName,
		k.LastName,
		k.Destination,
		K.Price
 FROM
	  (SELECT p.FirstName,
	  		  p.LastName,
	  		  f.Destination,
	  		  t.Price,
	  		  ROW_NUMBER() OVER(PARTITION BY p.FirstName, p.LastName ORDER BY t.Price DESC) AS [Rank]
	  FROM Passengers AS p
	  JOIN Tickets AS t ON t.PassengerId = p.Id
	  JOIN Flights AS f ON f.Id = t.FlightId) AS k
WHERE k.[Rank] = 1
ORDER BY k.Price DESC, k.FirstName, k.LastName, k.Destination


/* 16. Destinations Info  */
SELECT f.Destination,
	   COUNT(t.Id) AS FliesCount
FROM Tickets AS t
RIGHT JOIN Flights AS f ON f.Id = t.FlightId
GROUP BY f.Destination
ORDER BY COUNT(t.Id) DESC, f.Destination


/* 17. PSP  */
SELECT pl.[Name],
	   pl.Seats,
	   COUNT(t.Id) AS [Passengers Count]
FROM Tickets AS t 
JOIN Flights AS f ON f.Id = t.FlightId
RIGHT JOIN Planes AS pl ON pl.Id = f.PlaneId
GROUP BY pl.[Name], pl.Seats
ORDER BY [Passengers Count] DESC, pl.[Name], pl.Seats

GO
/* 18. Vacation  */
CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @totalPrice DECIMAL(15, 2) = 0;
	DECLARE @flightid INT = (SELECT Id
						     FROM Flights
						     WHERE Origin = @origin AND Destination = @destination)
			

	IF(@peopleCount < = 0)
	BEGIN
		RETURN 'Invalid people count!';
	END

	IF(@flightid IS NULL)
	BEGIN
		RETURN 'Invalid flight!';
	END

	DECLARE @ticketPrice DECIMAL(15, 2) = (SELECT SUM(t.Price) AS TotalPrice
										   FROM Tickets AS t
										   JOIN Flights AS f ON f.Id = t.FlightId
										   WHERE f.Id = @flightid
										   GROUP BY f.Id, f.Origin, f.Destination)

	DECLARE @result VARCHAR(MAX) = @ticketPrice*@peopleCount;

	RETURN 'Total price ' + @result;
END

GO

/* 19. Wrong Data  */
CREATE PROC usp_CancelFlights
AS
	UPDATE Flights
	SET ArrivalTime = NULL, 
	DepartureTime = NULL
	WHERE ArrivalTime > DepartureTime
GO

/* 20. Deleted Planes  */
CREATE TABLE DeletedPlanes
(
 Id INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR(30) NOT NULL,
 Seats INT NOT NULL,
 [Range] INT NOT NULL
)
GO

CREATE TRIGGER tr_DeletePlanes ON Planes FOR DELETE
AS
	INSERT INTO DeletedPlanes (Id, [Name], Seats, [Range])
	SELECT Id,
		   [Name],
		   Seats,
		   [Range]
    FROM deleted
