--01.Create BD
CREATE DATABASE Minions

--02.Create tables
CREATE TABLE Minions
(
 Id INT PRIMARY KEY,
 [Name] VARCHAR(50),
 Age INT
)

CREATE TABLE Towns
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(50)
)

--03.Alter Minions table
ALTER TABLE Minions
ADD TownId INT

ALTER TABLE Minions
ADD FOREIGN KEY (TownId) REFERENCES Towns(Id)

--04.Insert records
INSERT INTO Towns (Id,[Name])
VALUES(1,'Sofia'),
	(2,'Plovdiv'),
	(3,'Varna')
INSERT INTO Minions
VALUES (1,'Kevin',22,1),
	(2,'Bob', 15,3),
	(3,'Steward',NULL,2)

--05.Truncate table Minions
TRUNCATE TABLE Minions
SELECT * FROM Minions

--06.Drop all tables
DROP TABLE Minions
DROP TABLE Towns

--07.Create table People

CREATE TABLE People
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(200) NOT NULL,
Picture VARBINARY(MAX),
Height DECIMAL(3,2),
[WEIGHT] DECIMAL(5,2),
Gender CHAR(1) NOT NULL,
	CHECK(Gender in ('m','f')),
Birthdate DATETIME2 NOT NULL,
Biography VARCHAR(MAX)
)

INSERT INTO People ([Name],Gender,Birthdate)
VALUES('Dimitrichko','m','1998-05-05'),
('Maria','f','1998-05-05'),
('Ivana','f','1998-05-05'),
('Petarcho','m','1998-05-05'),
('Lupcho','m','1998-05-05')
SELECT * FROM People

--08.Create table Users
DROP TABLE Users
CREATE TABLE Users
(
Id BIGINT PRIMARY KEY IDENTITY,
Username NVARCHAR(30) NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX),
LastLoginTime DATETIME2,
IsDeleted BIT
)

INSERT INTO Users ([Username],[Password])
Values('Gosho','12345'),
	('Ivan','segsees'),
	('Dragan','45645'),
	('Pesho','segsrr'),
	('Mitko','789432')

--09.Change Primary key
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC0727C0E123

ALTER TABLE Users
ADD CONSTRAINT PK_UsersTable PRIMARY KEY(Id,Username)

--10.Add Check Constraint
ALTER TABLE Users
ADD CONSTRAINT CHK_PassIsAtLeastFiveSymbols
	CHECK(LEN([Password]) >= 5)

--11. Default value
ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime

INSERT INTO Users(Username,[Password])
VALUES ('Gosho_hehe','12345')
Select * FROM Users

--12. Set unique field
ALTER TABLE Users
DROP CONSTRAINT PK_UsersTable

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id)

Alter Table Users
ADD CONSTRAINT CHK_UsernameLengthAtLeastThree
	CHECK(LEN(Username)>=3)

--16 Softuni DB
CREATE DATABASE SoftUni

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(60) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	AddressText VARCHAR(MAX),
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(60)
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(60) NOT NULL,
	MiddleName VARCHAR(60),
	LastName VARCHAR(60) NOT NULL,
	JobTitle VARCHAR(60) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL,
	HireDate DATETIME2 NOT NULL,
	Salary DECIMAL(10,2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

--13.Movies DB
CREATE DATABASE Movies

CREATE TABLE Directors
(
 Id INT PRIMARY KEY IDENTITY,
 DirectorName VARCHAR(60) NOT NULL,
 Notes VARCHAR(MAX)
)
CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
 GenreName VARCHAR(60) NOT NULL,
 Notes VARCHAR(MAX)
)
CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(60) NOT NULL,
	Notes VARCHAR(MAX)
)
CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(60) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
	CopyrightYear INT CHECK (CopyrightYear >= 1888),
	[Length] INT NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Rating VARCHAR(10),
	Notes VARCHAR(MAX)
)
-- Inserting records into the Directors table
INSERT INTO Directors (DirectorName, Notes) VALUES
('Steven Spielberg', 'Famous for directing blockbuster films'),
('Christopher Nolan', 'Known for his complex storytelling and visual style'),
('Quentin Tarantino', 'Renowned for his unique narrative techniques and dialogue'),
('Martin Scorsese', 'Legendary filmmaker with a career spanning over 50 years'),
('James Cameron', 'Director of some of the highest-grossing films of all time');

-- Inserting records into the Genres table
INSERT INTO Genres (GenreName, Notes) VALUES
('Action', 'Fast-paced, high energy'),
('Drama', 'Focuses on emotional narratives'),
('Comedy', 'Aims to make the audience laugh'),
('Horror', 'Designed to scare and unsettle the audience'),
('Sci-Fi', 'Deals with futuristic concepts and technology');

-- Inserting records into the Categories table
INSERT INTO Categories (CategoryName, Notes) VALUES
('Feature Film', 'Full-length films typically over 90 minutes'),
('Short Film', 'Films shorter than 40 minutes'),
('Documentary', 'Non-fiction films intended to document reality'),
('Animation', 'Films made using animation techniques'),
('Independent', 'Films produced outside of major film studio systems');

-- Inserting records into the Movies table
INSERT INTO Movies (Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes) VALUES
('Jurassic Park', 1, 1993, 127, 1, 1, 'PG-13', 'A groundbreaking film with realistic dinosaurs'),
('Inception', 2, 2010, 148, 5, 1, 'PG-13', 'A mind-bending thriller about dream invasion'),
('Pulp Fiction', 3, 1994, 154, 2, 1, 'R', 'A cult classic with intertwining stories'),
('The Wolf of Wall Street', 4, 2013, 180, 2, 1, 'R', 'A biographical film about a stockbroker'),
('Avatar', 5, 2009, 162, 5, 1, 'PG-13', 'A visually stunning film set on an alien world');

--14.Car Rental DB
CREATE DATABASE CarRental
--Drop Table Categories
CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(60) NOT NULL,
	DailyRate DECIMAL(10,2)NOT NULL,
	WeeklyRate DECIMAL(10,2)NOT NULL,
	MonthlyRate DECIMAL(10,2)NOT NULL,
	WeekendRate DECIMAL(10,2)
)

-- Creating the Cars table
--Drop table cars
CREATE TABLE Cars 
(
    Id INT PRIMARY KEY IDENTITY,
    PlateNumber VARCHAR(20) NOT NULL UNIQUE,
    Manufacturer VARCHAR(50) NOT NULL,
    Model VARCHAR(50) NOT NULL,
    CarYear INT NOT NULL,
    CategoryId INT NOT NULL,
    Doors INT NOT NULL CHECK (Doors BETWEEN 2 AND 5),
    Picture VARBINARY(MAX),
    Condition VARCHAR(50) NOT NULL,
    Available BIT NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
)

-- Creating the Employees table
CREATE TABLE Employees 
(
    Id INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Title VARCHAR(50) NOT NULL,
    Notes TEXT
)

-- Creating the Customers table
CREATE TABLE Customers 
(
    Id INT PRIMARY KEY IDENTITY,
    DriverLicenceNumber VARCHAR(20) NOT NULL UNIQUE,
    FullName VARCHAR(100) NOT NULL,
    Address VARCHAR(255) NOT NULL,
    City VARCHAR(100) NOT NULL,
    ZIPCode VARCHAR(10) NOT NULL,
    Notes TEXT
)

-- Creating the RentalOrders table
--Drop TABLE RentalOrders
CREATE TABLE RentalOrders (
    Id INT PRIMARY KEY IDENTITY,
    EmployeeId INT NOT NULL,
    CustomerId INT NOT NULL,
    CarId INT NOT NULL,
    TankLevel DECIMAL(3, 1) CHECK (TankLevel BETWEEN 0.0 AND 1.0) NOT NULL,
    KilometrageStart INT NOT NULL,
    KilometrageEnd INT,
    TotalKilometrage INT,
    StartDate DATE NOT NULL,
    EndDate DATE,
    TotalDays INT,
    RateApplied DECIMAL(10, 2) NOT NULL,
    TaxRate DECIMAL(5, 2) NOT NULL,
    OrderStatus VARCHAR(50) NOT NULL,
    Notes TEXT,
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
    FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
    FOREIGN KEY (CarId) REFERENCES Cars(Id)
)
-- Inserting records into the Categories table
INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('Economy', 29.99, 189.99, 749.99, 59.99),
('SUV', 49.99, 319.99, 1249.99, 99.99),
('Luxury', 89.99, 599.99, 2399.99, 179.99);

-- Inserting records into the Cars table
INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
('ABC123', 'Toyota', 'Corolla', 2020, 1, 4, NULL, 'Good', 1),
('XYZ789', 'Ford', 'Explorer', 2019, 2, 4, NULL, 'Excellent', 1),
('LMN456', 'BMW', '5 Series', 2021, 3, 4, NULL, 'Good', 0);

-- Inserting records into the Employees table
INSERT INTO Employees (FirstName, LastName, Title, Notes) VALUES
('John', 'Doe', 'Manager', 'Experienced in customer service'),
('Jane', 'Smith', 'Assistant Manager', 'Great with handling rental processes'),
('Emily', 'Johnson', 'Sales Associate', 'Knowledgeable about cars');

-- Inserting records into the Customers table
INSERT INTO Customers (DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes) VALUES
('D1234567', 'Alice Brown', '123 Main St', 'Springfield', '12345', 'Preferred customer'),
('D2345678', 'Bob Green', '456 Elm St', 'Rivertown', '67890', 'VIP member'),
('D3456789', 'Charlie White', '789 Oak St', 'Maplewood', '54321', 'First-time renter');

-- Inserting records into the RentalOrders table
INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes) VALUES
(1, 1, 1, 0.8, 15000, 15200, 200, '2023-05-01', '2023-05-03', 2, 59.98, 7.00, 'Completed', 'Smooth transaction'),
(2, 2, 2, 0.6, 25000, 25350, 350, '2023-05-10', '2023-05-15', 5, 249.95, 7.00, 'Completed', 'Customer extended rental'),
(3, 3, 3, 0.9, 3000, NULL, NULL, '2023-05-20', NULL, NULL, 179.99, 7.00, 'Ongoing', 'Customer has not returned the car yet');

--15.Hotels DB
CREATE DATABASE Hotels
-- Creating the Employees table
CREATE TABLE Employees (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Title VARCHAR(50) NOT NULL,
    Notes TEXT
);

-- Creating the Customers table
CREATE TABLE Customers (
    AccountNumber INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    PhoneNumber VARCHAR(15) NOT NULL,
    EmergencyName VARCHAR(100),
    EmergencyNumber VARCHAR(15),
    Notes TEXT
);

-- Creating the RoomStatus table
CREATE TABLE RoomStatus (
    RoomStatus VARCHAR(50) PRIMARY KEY,
    Notes TEXT
);

-- Creating the RoomTypes table
CREATE TABLE RoomTypes (
    RoomType VARCHAR(50) PRIMARY KEY,
    Notes TEXT
);

-- Creating the BedTypes table
CREATE TABLE BedTypes (
    BedType VARCHAR(50) PRIMARY KEY,
    Notes TEXT
);

-- Creating the Rooms table
CREATE TABLE Rooms (
    RoomNumber INT PRIMARY KEY,
    RoomType VARCHAR(50) NOT NULL,
    BedType VARCHAR(50) NOT NULL,
    Rate DECIMAL(10, 2) NOT NULL,
    RoomStatus VARCHAR(50) NOT NULL,
    Notes TEXT,
    FOREIGN KEY (RoomType) REFERENCES RoomTypes(RoomType),
    FOREIGN KEY (BedType) REFERENCES BedTypes(BedType),
    FOREIGN KEY (RoomStatus) REFERENCES RoomStatus(RoomStatus)
);

-- Creating the Payments table
CREATE TABLE Payments (
    Id INT PRIMARY KEY IDENTITY(1,1),
    EmployeeId INT NOT NULL,
    PaymentDate DATE NOT NULL,
    AccountNumber INT NOT NULL,
    FirstDateOccupied DATE NOT NULL,
    LastDateOccupied DATE NOT NULL,
    TotalDays INT NOT NULL,
    AmountCharged DECIMAL(10, 2) NOT NULL,
    TaxRate DECIMAL(5, 2) NOT NULL,
    TaxAmount DECIMAL(10, 2) NOT NULL,
    PaymentTotal DECIMAL(10, 2) NOT NULL,
    Notes TEXT,
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
    FOREIGN KEY (AccountNumber) REFERENCES Customers(AccountNumber)
);

-- Creating the Occupancies table
CREATE TABLE Occupancies (
    Id INT PRIMARY KEY IDENTITY(1,1),
    EmployeeId INT NOT NULL,
    DateOccupied DATE NOT NULL,
    AccountNumber INT NOT NULL,
    RoomNumber INT NOT NULL,
    RateApplied DECIMAL(10, 2) NOT NULL,
    PhoneCharge DECIMAL(10, 2),
    Notes TEXT,
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
    FOREIGN KEY (AccountNumber) REFERENCES Customers(AccountNumber),
    FOREIGN KEY (RoomNumber) REFERENCES Rooms(RoomNumber)
);
-- Inserting records into the Employees table
INSERT INTO Employees (FirstName, LastName, Title, Notes) VALUES
('John', 'Doe', 'Manager', 'Oversees hotel operations'),
('Jane', 'Smith', 'Receptionist', 'Handles guest check-ins'),
('Emily', 'Johnson', 'Housekeeping', 'Maintains room cleanliness');

-- Inserting records into the Customers table
INSERT INTO Customers (FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
('Alice', 'Brown', '123-456-7890', 'Bob Brown', '098-765-4321', 'Preferred customer'),
('Bob', 'Green', '234-567-8901', 'Alice Green', '123-456-7890', 'VIP member'),
('Charlie', 'White', '345-678-9012', 'David White', '234-567-8901', 'First-time guest');

-- Inserting records into the RoomStatus table
INSERT INTO RoomStatus (RoomStatus, Notes) VALUES
('Available', 'Room is ready for new guests'),
('Occupied', 'Room is currently occupied by a guest'),
('Maintenance', 'Room is under maintenance');

-- Inserting records into the RoomTypes table
INSERT INTO RoomTypes (RoomType, Notes) VALUES
('Single', 'Single room with one bed'),
('Double', 'Double room with two beds'),
('Suite', 'Luxury suite with multiple rooms');

-- Inserting records into the BedTypes table
INSERT INTO BedTypes (BedType, Notes) VALUES
('Single', 'Single bed'),
('Double', 'Double bed'),
('Queen', 'Queen-sized bed');

-- Inserting records into the Rooms table
INSERT INTO Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes) VALUES
(101, 'Single', 'Single', 99.99, 'Available', 'First floor room'),
(102, 'Double', 'Double', 149.99, 'Occupied', 'Second floor room'),
(201, 'Suite', 'Queen', 299.99, 'Maintenance', 'Third floor luxury suite');

-- Inserting records into the Payments table
INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes) VALUES
(1, '2023-05-01', 1, '2023-04-20', '2023-04-25', 5, 499.95, 7.00, 34.99, 534.94, 'Paid in full'),
(2, '2023-05-05', 2, '2023-04-22', '2023-04-27', 5, 749.95, 7.00, 52.50, 802.45, 'Paid with credit card'),
(3, '2023-05-10', 3, '2023-04-25', '2023-04-30', 5, 1499.95, 7.00, 104.99, 1604.94, 'Paid in cash');

-- Inserting records into the Occupancies table
INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes) VALUES
(1, '2023-04-20', 1, 101, 99.99, 5.00, 'No issues during stay'),
(2, '2023-04-22', 2, 102, 149.99, 10.00, 'Extended stay by one night'),
(3, '2023-04-25', 3, 201, 299.99, 15.00, 'Requested additional amenities');

--18. Basic insert
INSERT INTO Towns
VALUES('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Burgas')
INSERT INTO Departments
VALUES('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

SELECT * FROM Employees
INSERT INTO Employees (FirstName,MiddleName,LastName,JobTitle,DepartmentId,HireDate,Salary)
VALUES('Ivan','Ivanov','Ivanov','.NET Developer',4,'2013-02-01',3500),
	('Petar','Petrov','Petrov','Senior Engineer',1,'2004-02-01',4000),
	('Maria','Petrova','Ivanova','Intern',5,'2016-08-28',525.25),
	('Georgi','Terziev','Ivanov','CEO',2,'2007-12-09',3000),
	('Peter','Pan','Pan','Intern',3,'2016-08-28',599.88)

	--19.Basic select
SELECT * FROM Towns
SELECT * FROM Departments
SELECT *  FROM Employees

--20.Sorted select
Select * FROM Towns
ORDER BY [Name] ASC

SELECT * FROM Departments
ORDER BY [Name] ASC

SELECT * FROM Employees
ORDER BY Salary DESC

--21.Select some fields
Select [Name] FROM Towns
ORDER BY [Name] ASC

SELECT [Name] FROM Departments
ORDER BY [Name] ASC

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

--22.Increase salary
UPDATE Employees
SET Salary = Salary * 1.1
SELECT Salary FROM Employees
--23.Decrease Tax rate
UPDATE Payments
SET TaxRate = TaxRate - 0.03 * TaxRate
SELECT TaxRate FROM Payments

--24.Delete records 
TRUNCATE TABLE Occupancies