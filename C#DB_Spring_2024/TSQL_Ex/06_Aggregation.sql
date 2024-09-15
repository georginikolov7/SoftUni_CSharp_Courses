--01.COunt records
USE Gringotts
SELECT * FROM WizzardDeposits
SELECT COUNT(*)
FROM 
WizzardDeposits

--02.Longest magic wand
SELECT MAX(MagicWandSize) AS LongestMagicWand
FROM 
WizzardDeposits

--03.Wand per deposit group
SELECT
DepositGroup
,MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY (DepositGroup)

--04.
SELECT TOP 2
DepositGroup,
AVG(MagicWandSize) AS AvgWandSize
FROM WizzardDeposits
GROUP BY (DepositGroup)
ORDER BY AvgWandSize

--05.Deposit sums
SELECT 
DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup

--06. Deposit sums for Olli family
SELECT 
DepositGroup,
SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--07. Deposits filter
SELECT 
DepositGroup,
SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family' 
GROUP BY DepositGroup 
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

--08.Deposit charge
SELECT
DepositGroup,
MagicWandCreator,
MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

--09.Age groups
SELECT g.AgeGroup, COUNT(*) AS WizardCount
	FROM
		(SELECT 
			AgeGroup = 
			CASE  
				WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
				WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
				WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
				WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
				WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
				WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
				WHEN Age >= 61 THEN '[61+]'
			END
		FROM WizzardDeposits) AS g
		GROUP BY g.AgeGroup

--10.First letter
SELECT	FirstLetter
	FROM
	(
		SELECT
		FirstName
		,LEFT(FirstName,1) AS FirstLetter
		FROM WizzardDeposits
		WHERE DepositGroup = 'Troll Chest'
	) AS query
GROUP BY FirstLetter

--11. Average Interest
SELECT
DepositGroup,
IsDepositExpired,
Avg(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

--12.
	SELECT
		(SELECT DepositAmount
			FROM WizzardDeposits
			WHERE Id = 1) 
		- 
		(SELECT DepositAmount
			FROM WizzardDeposits 
			WHERE Id = 
			(
				SELECT TOP 1 Id 
					FROM WizzardDeposits 
					ORDER BY Id DESC
			)
		)

--13. Departments total salary
USE Softuni
SELECT
DepartmentId,
SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

--14.Employees Min Salary
SELECT
DepartmentID,
MIN(Salary) AS MininumSalary
FROM Employees
WHERE DepartmentID IN (2,5,7) AND HireDate > '2000-01-01'
GROUP BY DepartmentID

--15.Average salary
SELECT * INTO SpecialEmployees 
	FROM Employees
	WHERE Salary > 30000

DELETE
FROM SpecialEmployees
WHERE ManagerID = 42

UPDATE SpecialEmployees
SET Salary = Salary + 5000
WHERE DepartmentID = 1
SELECT 
DepartmentID,
AVG(Salary) AS AverageSalary
FROM SpecialEmployees
GROUP BY DepartmentID

--16.Employees max salary
SELECT
DepartmentID,
MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--17.
SELECT
COUNT (Salary) AS [COUNT]
FROM Employees
WHERE ManagerID IS NULL

--18. 
SELECT DISTINCT
	DepartmentID,
	Salary
	FROM
	(
		SELECT 
		DepartmentID,
		DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS Ranklist,
		Salary
		FROM Employees
	) AS Query
	WHERE Ranklist = 3

--19.
SELECT TOP 10
e.FirstName,
e.LastName,
e.DepartmentID
FROM Employees AS e
INNER JOIN
	(
	SELECT
	DepartmentId,
	AVG(Salary) AS AvgSalary
	FROM Employees
	GROUP BY DepartmentID
	) a
ON e.DepartmentID = a.DepartmentID
WHERE e.Salary > a.AvgSalary
ORDER BY DepartmentID
	
