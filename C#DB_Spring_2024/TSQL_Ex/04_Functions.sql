
USE SoftUni
GO
--01.
SELECT FirstName,LastName
FROM Employees
WHERE FirstName LIKE 'SA%'

--02.
SELECT FirstName,LastName
FROM Employees
WHERE LastName LIKE '%ei%'

--03.
SELECT * FROM Employees
SELECT FirstName
FROM Employees
WHERE DepartmentID IN (3,10) 
AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005

--04.
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--05.
SELECT [Name]
FROM Towns
WHERE LEN([Name])  IN (5,6)
ORDER BY [Name]

--06.
SELECT *
FROM Towns
WHERE LEFT([Name],1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name]

--07.
SELECT *
FROM Towns
WHERE LEFT([Name],1) NOT IN ('R', 'B', 'D')
ORDER BY [Name]

--08.
CREATE VIEW [V_EmployeesHiredAfter2000] AS
SELECT FirstName, LastName
FROM Employees
WHERE DATEPART(YEAR,HireDate) > 2000

--09.
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5

--10.Rank by salary
SELECT EmployeeID, FirstName, LastName, Salary,
	DENSE_RANK() OVER
	(PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000 
ORDER BY Salary DESC

--11.Rank by salary
WITH CTE_RankedEmployees AS
(
	SELECT EmployeeID, FirstName, LastName, Salary,
		DENSE_RANK() OVER
		(PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000 
)
SELECT * 
FROM CTE_RankedEmployees
WHERE [Rank] = 2
ORDER BY SALARY DESC

USE Geography
GO
--12.
SELECT CountryName, IsoCode
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

--13.

SELECT PeakName, RiverName,
CONCAT(LOWER(PeakName), LOWER(SUBSTRING(RiverName,2,LEN(RiverName)-1))) AS Mix
FROM Peaks, Rivers
WHERE RIGHT (PeakName, 1) = LEFT(RiverName,1)
ORDER BY Mix

USE Diablo
GO
--14.
SELECT TOP(50) [Name], FORMAT([Start],'yyyy-MM-dd') AS [Start]
FROM Games
WHERE DATEPART(YEAR,[Start]) IN (2011,2012)
ORDER BY [Start], [Name]

--15.
SELECT Username, SUBSTRING(Email,CHARINDEX('@',Email)+1,LEN(Email)) AS [Email Provider]
FROM Users
ORDER BY [Email Provider], Username

--16.
SELECT Username,IpAddress
FROM Users
WHERE IpAddress LIKE '[0-9][0-9][0-9].1%.%.[0-9][0-9][0-9]'
ORDER BY Username

--17.
SELECT [Name] AS Game,
[Part of the Day]=
	CASE 
		WHEN DATEPART(HOUR,[Start]) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR,[Start]) < 18 THEN 'Afternoon'
		ELSE 'Evening' 
	END,
Duration = 
	CASE 
		WHEN Duration <=3 THEN 'Extra Short'
		WHEN Duration <= 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		ELSE 'Extra Long'
	END
FROM Games
ORDER BY Game, Duration

--18.
USE DemoDb
GO
CREATE TABLE Orders
(
Id INT PRIMARY KEY IDENTITY,
ProductName VARCHAR(64),
OrderDate DATETIME2
)
INSERT INTO Orders
	VALUES('Butter',GETDATE()),
	('Milk',GETDATE()),
	('Bread',GETDATE())


SELECT ProductName, OrderDate,
[Pay Due] = DATEADD(DAY,3,OrderDate),
[Delivery Due] = DATEADD(MONTH,1,OrderDate)
FROM Orders
