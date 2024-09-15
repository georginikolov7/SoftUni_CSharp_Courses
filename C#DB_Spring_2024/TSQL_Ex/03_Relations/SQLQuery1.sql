USE master
CREATE DATABASE Demo
GO
USE Demo
GO
CREATE TABLE Passports
(
PassportID INT PRIMARY KEY IDENTITY(101,1),
PassportNumber VARCHAR(32)
)

CREATE TABLE Persons
(
	PersonId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	Salary DECIMAL(10,2) NOT NULL,
	PassportID INT UNIQUE FOREIGN KEY 
	REFERENCES Passports(PassportID)
)

INSERT INTO Passports
VALUES('N34FG21B')
		,('K65LO4R7')
		,('ZE657QP2')

INSERT INTO Persons
VALUES('Roberto',43300,102)
		,('Tom',56100,103)
		,('Yana',60200,101)

--02. One-to-many
CREATE TABLE Manufacturers
(
ManufacturerID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(32) NOT NULL,
EstablishedOn DATETIME2 NOT NULL
)

CREATE TABLE Models
(
ModelID INT PRIMARY KEY IDENTITY(101,1),
[Name] VARCHAR(32) NOT NULL,
ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers
VALUES('BMW','07/03/1916')
,('Tesla','01/01/2003')
,('Lada','01/05/1966')

INSERT INTO Models
VALUES('X1',1)
,('i6',1)
,('Model S',2)
,('Models X',2)
,('Model 3',2)
,('Nova',3)

SELECT * FROM Models

--03.Many-to-many
CREATE TABLE Students
(
StudentID INT PRIMARY KEY IDENTITY
,[Name] VARCHAR(32) NOT NULL
)
CREATE TABLE Exams
(
ExamID INT PRIMARY KEY IDENTITY(101,1)
,[Name] VARCHAR(32) NOT NULL
)
CREATE TABLE StudentsExams
(
StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL,
ExamID INT FOREIGN KEY REFERENCES Exams(ExamID) NOT NULL
)
ALTER TABLE StudentsExams
ADD CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentID,ExamID)

INSERT INTO Students (Name)
VALUES
    ('Mila'),
    ('Toni'),
    ('Ron');

-- Insert data into the Exams table
INSERT INTO Exams (Name)
VALUES
    ('SpringMVC'),
    ('Neo4j'),
    ('Oracle 11g');

-- Insert data into the StudentsExams table
-- Assuming you know the IDs generated, here are the inserts based on the example given.
INSERT INTO StudentsExams (StudentID, ExamID)
VALUES
    (1, 101),  -- Mila - SpringMVC
    (1, 102),  -- Mila - Neo4j
    (2, 101),  -- Toni - SpringMVC
    (3, 103),  -- Ron - Oracle 11g
    (2, 102),  -- Toni - Neo4j
    (2, 103);  -- Toni - Oracle 11g

	--04.Self-ref
CREATE TABLE Teachers
(
TeacherID INT PRIMARY KEY IDENTITY(101,1),
[Name] VARCHAR(32) NOT NULL,
ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)
INSERT INTO Teachers([Name])
VALUES('John')
,('Maya')
,('Silvia')
,('Ted')
,('Mark')
,('Greta')
SELECT * FROM Teachers
UPDATE Teachers
SET ManagerID =106
WHERE TeacherID IN (102,103)

--05. Online store DB
CREATE DATABASE OnlineStore
USE OnlineStore

CREATE TABLE ItemTypes
(
ItemTypeID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(32)NOT NULL
)
CREATE TABLE Items
(
ItemID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(32) NOT NULL,
ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)
CREATE TABLE Cities
(
CityID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Customers
(
CustomerID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
Birthday DATETIME2,
CityID INT FOREIGN KEY REFERENCES Cities(CityID)
)

CREATE TABLE Orders
(
OrderID INT PRIMARY KEY IDENTITY,
CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE OrderItems
(
OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
ItemID INT FOREIGN KEY REFERENCES Items(ItemID),
CONSTRAINT PK_OrderItems PRIMARY KEY(OrderID,ItemID)
)

--06 UNIDB
CREATE DATABASE University
USE University

CREATE TABLE Majors
(
MajorID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(128) NOT NULL
)
CREATE TABLE Students
(
StudentID INT PRIMARY KEY IDENTITY,
StudentNumber VARCHAR(128) NOT NULL,
StudentName VARCHAR(64) NOT NULL,
MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)
CREATE TABLE Payments
(
PaymentID INT PRIMARY KEY IDENTITY,
PaymentDate DATETIME2 NOT NULL,
PaymentAmount DECIMAL(10,2) NOT NULL,
StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)
CREATE TABLE Subjects
(
SubjectID INT PRIMARY KEY IDENTITY,
SubjectName VARCHAR(128) NOT NULL
)
CREATE TABLE Agenda
(
StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID),
CONSTRAINT PK_Agenda PRIMARY KEY (StudentID, SubjectID)
)

--9.
USE Geography
SELECT m.MountainRange, p.PeakName,p.Elevation 
FROM Peaks AS p
JOIN Mountains AS m ON p.MountainId= m.Id
WHERE m.MountainRange='Rila'
ORDER BY p.Elevation DESC