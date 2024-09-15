USE SoftUni
GO

--01.
SELECT TOP(5) e.EmployeeID, e.JobTitle, e.AddressID,a.AddressText
FROM
Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY e.AddressID

--02.
SELECT TOP(50) 
e.FirstName, e.LastName, t.[Name] AS Town, a.AddressText
FROM
Employees as e
JOIN Addresses as a ON e.AddressID = a.AddressID
JOIN Towns as t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

--03.
SELECT 
e.EmployeeID, e.FirstName, e.LastName, d.[Name] as DepartmentName
FROM 
Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID

--04.
SELECT TOP(5)
e.EmployeeID, e.FirstName, e.Salary, d.[Name] AS DepartmentName
FROM
Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY d.DepartmentID

---05.
SELECT * FROM Departments
SELECT TOP(3)
e.EmployeeID, e.FirstName
FROM Employees as e
LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.EmployeeID IS NULL
ORDER BY e.EmployeeID

--06.
SELECT 
e.FirstName,
e.LastName,
e.HireDate,
d.[Name] AS DeptName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-01-01' AND (d.[Name] = 'Sales' OR d.[Name] = 'Finance')
ORDER BY e.HireDate

--07.
SELECT TOP(5)
e.EmployeeID,
e.FirstName,
p.[Name] AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

--08.
SELECT 
e.EmployeeID,
e.FirstName,
ProjectName=
	CASE
		WHEN DATEPART(YEAR,p.StartDate) >=2005 THEN NULL
		ELSE p.[Name]
	END
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

--09.
SELECT 
e.EmployeeID,
e.FirstName,
e.ManagerID,
em.FirstName AS ManagerName
FROM Employees AS e
JOIN Employees AS em ON e.ManagerID = em.EmployeeID
WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID

--10.
SELECT TOP(50)
e.EmployeeID,
CONCAT_WS(' ',e.FirstName, e.LastName) AS EmployeeName,
CONCAT_WS(' ',em.FirstName, em.LastName) AS ManagerName,
d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Employees AS em ON e.ManagerID = em.EmployeeID
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY EmployeeID

--11.
SELECT MIN(dt.AvgSalary) AS AverageSalary
FROM
(SELECT 
	AVG(Salary) AS AvgSalary
	FROM Employees
	GROUP BY DepartmentID) AS dt

--12.
USE Geography
GO

SELECT 
c.CountryCode,
m.MountainRange,
p.PeakName,
p.Elevation
FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m ON mc.MountainId = m.Id
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE c.CountryName = 'Bulgaria' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--13.
SELECT c.CountryCode,COUNT(m.MountainRange)
FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m ON mc.MountainId = m.Id
WHERE c.CountryCode IN('BG','RU', 'US')
GROUP BY c.CountryCode

--14.
SELECT TOP 5
c.CountryName,
r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

--15. 
SELECT * FROM Countries
GO
WITH CurrencyUsageCount AS
(
SELECT 
        c.ContinentCode,
        c.CurrencyCode,
        COUNT(*) AS UsageCount
    FROM 
        Countries c
    GROUP BY 
        c.ContinentCode, c.CurrencyCode
	
), 
CurrencyUsageRanked AS
(
	SELECT
			ContinentCode,
			CurrencyCode,
			UsageCount,
			DENSE_RANK() OVER
			(PARTITION BY ContinentCode ORDER BY UsageCount DESC) AS CurrencyRank
			FROM CurrencyUsageCount
)
SELECT
ContinentCode,CurrencyCode,UsageCount AS CurrencyUsage
FROM CurrencyUsageRanked
WHERE CurrencyRank = 1 AND UsageCount <> 1
ORDER BY ContinentCode, CurrencyCode
GO


--16.
SELECT
COUNT(c.CountryName) AS [COUNT]
FROM Countries c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
WHERE mc.CountryCode IS NULL

--17.
SELECT TOP 5
	c.CountryName,
	MAX(p.Elevation)AS HighestPeakElevation,
	MAX(r.[Length]) AS LongestRiverLength
FROM Countries c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p ON m.Id = p.MountainId
GROUP BY (c.CountryName)
ORDER BY HighestPeakElevation DESC,LongestRiverLength DESC,CountryName
--18.
GO
WITH PeaksRankedByElevation AS
(
	SELECT 
		c.CountryName,
		p.PeakName,
		p.Elevation,
		m.MountainRange,
		DENSE_RANK() OVER 
			(PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS PeakRank
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode 
	LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
	LEFT JOIN Peaks AS p ON m.ID = p.MountainId
)
SELECT TOP 5
	CountryName AS Country,
	ISNULL(PeakName, '(no highest peak)') AS [Highest Peak Name],
	ISNULL(Elevation,0) AS [Highest Peak Elevation],
	ISNULL(MountainRange,'(no mountain)') AS Mountain
FROM PeaksRankedByElevation
WHERE PeakRank = 1
ORDER BY CountryName