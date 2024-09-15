USE SoftUni
--02.Departments query
SELECT * FROM Departments

--03. Departments names query
SELECT [Name] FROM Departments

--04.Salary of employee query
SELECT * FROM Employees
SELECT FirstName, LastName, Salary FROM Employees

--05.Full name of employee query
SELECT FirstName,MiddleName,LastName FROM Employees

--06.Email of each Employee query
SELECT FirstName + '.' + LastName + '@softuni.bg' 
		AS [Full Email Address] 
		FROM Employees

--07.Different salaries query
SELECT DISTINCT Salary FROM Employees

--08.All Info for Employees query
SELECT * FROM Employees
WHERE [JobTitle] ='Sales Representative'

--09.Sort info by salary in range query
SELECT FirstName, LastName, JobTitle FROM Employees
WHERE Salary  BETWEEN 20000 AND 30000

--10. Names of all employees query
SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name] FROM Employees
WHERE Salary IN (25000,14000,12500,23600)

--11. No manager query
SELECT FirstName, LastName FROM Employees
WHERE ManagerID IS NULL

--12.Salary more than 50_000
SELECT FirstName,LastName,Salary FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

--13.TOP 5 employees
SELECT TOP(5) FirstName, LastName FROM Employees
ORDER BY Salary DESC

--14. Employees except marketing
SELECT FirstName, LastName FROM Employees
WHERE DepartmentID <> 4

--15. Sort Employees
SELECT * FROM Employees
ORDER BY Salary DESC, FirstName,LastName DESC, MiddleName

--16.View
GO
CREATE VIEW v_EmployeesSalaries AS
(
SELECT FirstName, LastName, Salary 
FROM Employees
)
GO

--17.View 2
GO
CREATE VIEW v_EmployeeNameJobTitle AS
(
SELECT CONCAT_WS(' ',FirstName, MiddleName, LastName) AS [Full Name], 
	   [JobTitle] AS [Job Title]
FROM Employees
)
GO

SELECT * FROM v_EmployeeNameJobTitle

--18.Distinct job title
SELECT DISTINCT JobTitle FROM Employees

--19.First 10 projects
SELECT TOP(10) * FROM Projects
ORDER BY StartDate, [Name]

--20.Last 7 hired
SELECT TOP(7) FirstName, LastName, HireDate FROM Employees
ORDER BY HireDate DESC

--21.Increse salaries
SELECT * FROM Departments

BEGIN TRANSACTION
UPDATE Employees
SET Salary = 1.12 * Salary
WHERE DepartmentID IN (1, 2, 4, 11)
SELECT Salary FROM Employees
ROLLBACK TRANSACTION

--22.All mountain peaks
USE Geography
SELECT PeakName FROM PEAKS
ORDER BY PeakName

--23.
SELECT * FROM Countries
SELECT TOP(30) CountryName,[Population] FROM Countries
WHERE ContinentCode ='EU'
ORDER BY [Population] DESC, CountryName

--24.
SELECT CountryName, CountryCode,
CASE
	WHEN CurrencyCode = 'EUR' THEN 'Euro'
	ELSE 'Not Euro'
	END AS Currency
FROM Countries
ORDER BY CountryName

--25.
USE Diablo
SELECT [Name] FROM Characters
ORDER BY [Name]