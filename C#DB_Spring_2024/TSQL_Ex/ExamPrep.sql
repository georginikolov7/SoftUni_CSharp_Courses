--EXAMMMMMMM

CREATE DATABASE RailwaysDb
GO
USE RailwaysDb
GO

DROP DATABASE RailwaysDb
--01.
CREATE TABLE Passengers
(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(80) NOT NULL
)

CREATE TABLE Towns
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE RailwayStations
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL,
TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Trains
(
Id INT PRIMARY KEY IDENTITY,
HourOfDeparture VARCHAR(5) NOT NULL,
HourOfArrival VARCHAR(5) NOT NULL,
DepartureTownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL,
ArrivalTownId	INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)


CREATE TABLE TrainsRailwayStations
(
TrainId INT NOT NULL,
RailwayStationId INT NOT NULL,
PRIMARY KEY (TrainId, RailwayStationId),
FOREIGN KEY (TrainId) REFERENCES Trains(Id),
FOREIGN KEY (RailwayStationId) REFERENCES RailwayStations(Id)
)

CREATE TABLE MaintenanceRecords
(
Id INT PRIMARY KEY IDENTITY,
DateOfMaintenance DATE NOT NULL,
Details NVARCHAR(2000) NOT NULL,
TrainId INT FOREIGN KEY REFERENCES Trains(Id) NOT NULL
)

CREATE TABLE Tickets
(
Id INT PRIMARY KEY IDENTITY,
Price DECIMAL(12,2) NOT NULL,
DateOfDeparture DATE NOT NULL,
DateOfArrival DATE NOT NULL,
TrainId INT FOREIGN KEY REFERENCES Trains(Id) NOT NULL,
PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
)


--02. HUI
INSERT INTO Trains (HourOfDeparture, HourOfArrival, DepartureTownId, ArrivalTownId)
VALUES 
('07:00', '19:00', 1, 3),
('08:30', '20:30', 5, 6),
('09:00', '21:00', 4, 8),
('06:45', '03:55', 27, 7),
('10:15', '12:15', 15, 5);

INSERT INTO TrainsRailwayStations (TrainId, RailwayStationId)
VALUES 
(36, 1), (36, 4), (36, 31), (36, 57), (36, 7), 
(37, 13), (37, 54), (37, 60), (37, 16), 
(38, 10), (38, 50), (38, 52), (38, 22),
(39, 3), (39, 31), (39, 19), (39, 68), 
(40, 41), (40, 7), (40, 52), (40, 13);

INSERT INTO Tickets (Price, DateOfDeparture, DateOfArrival, TrainId, PassengerId)
VALUES 
(90.00, '2023-12-01', '2023-12-01', 36, 1),
(115.00, '2023-08-02', '2023-08-02', 37, 2),
(160.00, '2023-08-03', '2023-08-03', 38, 3),
(255.00, '2023-09-01', '2023-09-02', 39, 21),
(95.00, '2023-09-02', '2023-09-03', 40, 22);

--03. Update
SELECT * FROM TICKETS
UPDATE Tickets
SET DateOfDeparture = DATEADD(DAY, 7, DateOfDeparture),
	DateOfArrival = DATEADD(DAY, 7, DateOfArrival)
WHERE DateOfDeparture > '2023-10-31'

--04. DELETE
DELETE
FROM TrainsRailwayStations
WHERE TrainId = 7

DELETE 
FROM MaintenanceRecords
WHERE TrainId = 7

DELETE 
FROM Tickets 
WHERE TrainId = 7

DELETE 
FROM TRAINS
WHERE DepartureTownId IN (SELECT Id FROM Towns WHERE [Name] = 'Berlin')


--QUERIES:

--05.
SELECT 
DateOfDeparture,Price AS TicketPrice
FROM Tickets
ORDER BY Price, DateOfDeparture DESC

--06.
SELECT p.[Name],
	   t.Price AS TicketPrice,
	   t.DateOfDeparture,
	   t.TrainId
FROM Tickets AS t
JOIN Passengers AS p ON t.PassengerId = p.Id
ORDER BY t.Price DESC, p.[Name]

--07.
SELECT
t.[Name] AS Town, st.[Name] AS RailwayStation
FROM RailwayStations AS st
JOIN Towns AS t ON t.Id = st.TownId
LEFT JOIN TrainsRailwayStations AS tst ON st.Id = tst.RailwayStationId
LEFT JOIN Trains AS tr ON tst.TrainId = tr.Id
WHERE tr.Id IS NULL
ORDER BY t.[Name], st.[Name]

--08.
SELECT  * FROM Trains
SELECT TOP (3)
tr.Id, tr.HourOfDeparture, t.Price AS TicketPrice, tw.[Name] AS Destination
FROM Tickets AS t
JOIN Trains AS tr ON t.TrainId = tr.Id
JOIN Towns AS tw ON tr.ArrivalTownId = tw.Id
WHERE t.Price > 50 AND LEFT(tr.HourOfDeparture, 2) = '08'
ORDER BY TicketPrice 

--09.
SELECT
	t.[Name] AS TownName, COUNT(t.[Name]) AS PassengersCount
FROM Tickets AS ti
JOIN Trains AS tr ON ti.TrainId = tr.Id
JOIN Towns AS t ON tr.ArrivalTownId = t.Id
WHERE Price > 76.99
GROUP BY t.[Name]
ORDER BY TownName

--10.
SELECT
	TrainId, tn.[Name] AS DepartureTown, Details
FROM MaintenanceRecords AS mr
JOIN Trains AS t ON mr.TrainId = t.Id
JOIN Towns AS tn ON t.DepartureTownId = tn.Id
WHERE Details LIKE '%inspection%'
ORDER BY t.Id

--11.
GO

CREATE FUNCTION udf_TownsWithTrains (@name NVARCHAR(50))
RETURNS INT
AS
BEGIN
DECLARE @TrainsCount INT;

 SELECT @TrainsCount =COUNT(tr.Id)
 FROM Trains AS tr
   JOIN Towns AS ta ON tr.ArrivalTownId = ta.Id
   JOIN Towns AS td ON tr.DepartureTownId = td.Id
   WHERE ta.[Name] = @name OR td.[Name] = @name

RETURN @TrainsCount;
END

GO

--12.
CREATE PROC usp_SearchByTown(@townName NVARCHAR(50))
AS
BEGIN
SELECT p.[Name], ti.DateOfDeparture AS DateOfDeparture, tr.HourOfDeparture AS HourOfDeparture
FROM Tickets AS ti
JOIN Trains AS tr ON ti.TrainId = tr.Id
JOIN Towns AS ta ON tr.ArrivalTownId = ta.Id
JOIN Passengers AS p ON p.Id = ti.PassengerId
WHERE ta.[Name]=@townName
ORDER BY ti.DateOfDeparture DESC, p.[Name]
END

GO