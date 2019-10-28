/* 01.Employee Address */
SELECT TOP(5)
	   e.EmployeeID, 
	   e.JobTitle,
	   e.AddressID,
	   a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY a.AddressID


/* 02.Addresses with Towns */
SELECT TOP(50)
	   e.FirstName,
	   e.LastName,
	   t.[Name] AS Town,
	   a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON a.AddressID = e.AddressID
JOIN Towns AS t ON t.TownID = a.TownID
ORDER BY e.FirstName, e.LastName


/* 03.Sales Employees */
SELECT e.EmployeeID,
	   e.FirstName,
	   e.LastName,
	   d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID


/* 04.Employee Departments */
SELECT TOP(5)
	   e.EmployeeID,
	   e.FirstName,
	   e.Salary,
	   d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID



/*05.Employees Without Projects */
-- FIRST SOLVE
SELECT TOP(3)
	   e.EmployeeID,
	   e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID


-- SECOND SOLVE
SELECT TOP(3)
	   e.EmployeeID,
	   e.FirstName
FROM Employees AS e
WHERE EmployeeID  NOT IN (SELECT ep.EmployeeID FROM EmployeesProjects AS ep)
ORDER BY e.EmployeeID

/* 06. Employees Hired After */
SELECT e.FirstName,
	   e.LastName,
	   e.HireDate,
	   d.[Name] AS DeptName
FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE e.HireDate > '01-01-1999' AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.HireDate


/* 07.Employees With Project */
SELECT TOP(5)
	   e.EmployeeID,
	   e.FirstName,
	   p.[Name] AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID


/* 08.Employee 24 */
SELECT e.EmployeeID,
	   e.FirstName,
	CASE
		WHEN YEAR(p.StartDate) >= 2005 THEN NULL
		ELSE
	    p.[Name] 
	END AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24


/* 09.Employee Manager */
SELECT e.EmployeeID,
	   e.FirstName,
	   e.ManagerID,
	   (SELECT em.FirstName 
	    FROM Employees AS em
		WHERE em.EmployeeID = e.ManagerID) AS ManagerName
FROM Employees AS e
WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID


/* 10.Employees Summary */
SELECT TOP(50)
	   EmployeeID,
	   e.FirstName +' ' + e.LastName AS EmployeeName,
	   (SELECT em.FirstName + ' ' + em.LastName 
	    FROM Employees AS em
		WHERE em.EmployeeID = e.ManagerID) AS ManagerName,
		d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID


/* 11.Min Average Salary */
-- FIRST SOLVE
SELECT TOP(1) AVG(Salary) AS MinAverageSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY MinAverageSalary

-- SECOND SOLVE
SELECT MIN(AverageSalaries.AverageDeptSalary) AS MinAverageSalary
FROM
	(SELECT AVG(Salary) AS AverageDeptSalary 
	FROM Employees
	GROUP BY DepartmentID ) AS AverageSalaries


/* 12.Highest Peaks in Bulgaria */
SELECT c.CountryCode,
	   m.MountainRange,
	   p.PeakName,
	   p.Elevation
FROM Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE p.MountainId IN 
					(SELECT MountainId FROM MountainsCountries
					WHERE CountryCode = 'BG')
	  AND p.Elevation > 2835
ORDER BY p.Elevation DESC


/* 13.Count Mountain Ranges */
SELECT DISTINCT(CountriesCodesTable.CountryCode),
	   COUNT(CountriesCodesTable.CountryCode)
FROM (SELECT mc.CountryCode
	  FROM MountainsCountries AS mc
      JOIN Mountains AS m ON m.Id = mc.MountainId
      WHERE mc.CountryCode IN ('BG', 'RU', 'US')) AS CountriesCodesTable
GROUP BY CountriesCodesTable.CountryCode


/* 14.Countries With or Without Rivers */
SELECT TOP(5)
	   c.CountryName,
	   r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName


/* 15.Continents and Currencies */
SELECT CurrenciesRankTable.ContinentCode,
	   CurrenciesRankTable.CurrencyCode,
	   CurrenciesRankTable.CurrencyUsage
FROM (SELECT 
			ContinentsCurrencies.ContinentCode,
			ContinentsCurrencies.CurrencyCode,
			COUNT(ContinentsCurrencies.CurrencyCode) AS CurrencyUsage,
			DENSE_RANK() OVER   
			(PARTITION BY ContinentsCurrencies.ContinentCode ORDER BY COUNT(ContinentsCurrencies.CurrencyCode) DESC) AS [Rank]
	  FROM (SELECT ContinentCode,
			CurrencyCode
			FROM Countries) AS ContinentsCurrencies
	  GROUP BY ContinentsCurrencies.CurrencyCode, ContinentsCurrencies.ContinentCode
	  HAVING COUNT(ContinentsCurrencies.CurrencyCode) > 1) AS CurrenciesRankTable
WHERE CurrenciesRankTable.[Rank] = 1


/* 16.Countries Without any Mountains */
SELECT TOP(5)
	   BigestNums.CountryName,
	   BigestNums.Elevation,
	   BigestNums.[Length]
FROM (SELECT CountriesPeaksRivers.CountryName,
			 CountriesPeaksRivers.Elevation,
			 CountriesPeaksRivers.[Length],
			 DENSE_RANK() OVER   
			 (PARTITION BY CountriesPeaksRivers.CountryName ORDER BY CountriesPeaksRivers.Elevation DESC, CountriesPeaksRivers.[Length] DESC) AS [Rank]
	  FROM (SELECT c.CountryName,
				   p.Elevation,
				   r.[Length]
			FROM Countries AS c
			LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
			LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
			LEFT JOIN Peaks AS p ON p.MountainId = m.Id
			LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
			LEFT JOIN Rivers AS r ON r.Id = cr.RiverId) AS CountriesPeaksRivers) AS BigestNums
WHERE BigestNums.[Rank] = 1
ORDER BY BigestNums.Elevation DESC, BigestNums.[Length] DESC, BigestNums.CountryName 


/* 18.Highest Peak Name and Elevation by Country */
SELECT TOP(5)
	   PCT.CountryName,
	   ISNULL(PCT.[Highest Peak Name], '(no highest peak)') AS [Highest Peak Name],
	   ISNULL(PCT.[Highest Peak Elevation], 0) AS [Highest Peak Elevation],
	   ISNULL(PCT.MountainRange, '(no mountain)') AS MountainRange
FROM(SELECT  c.CountryName,
		p.PeakName AS [Highest Peak Name],
	    p.Elevation AS [Highest Peak Elevation],
	    m.MountainRange,
		ROW_NUMBER() OVER   
		(PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS [Rank]
	  FROM Countries AS c
	  LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	  LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
	  LEFT JOIN Peaks AS p ON p.MountainId = m.Id
	  GROUP BY c.CountryName, p.Elevation, p.PeakName, m.MountainRange) AS PCT
WHERE PCT.[Rank] = 1
ORDER BY PCT.CountryName, PCT.[Highest Peak Name]


-- SECOND WAY TO SOLVE
SELECT TOP(5)
	   k.CountryName,
	   k.[Highest Peak Name],
	   k.[Highest Peak Elevation],
	   k.Mountain
  FROM (SELECT c.CountryName,
		   CASE
			   WHEN p.PeakName IS NULL
			   THEN '(no highest peak)'
			   ELSE p.PeakName
		   END AS [Highest Peak Name],
		   CASE
			   WHEN MAX(p.Elevation) IS NULL
			   THEN '0'
			   ELSE MAX(p.Elevation)
		   END AS [Highest Peak Elevation],
		   CASE
			   WHEN m.MountainRange IS NULL
			   THEN '(no mountain)'
			   ELSE m.MountainRange
		   END AS [Mountain],
		   ROW_NUMBER() OVER   
	    (PARTITION BY c.CountryName ORDER BY MAX(p.Elevation) DESC) AS [Rank]
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
	LEFT JOIN Peaks AS p ON p.MountainId = m.Id
	GROUP BY c.CountryName, p.PeakName, m.MountainRange) AS k
WHERE k.[Rank] = 1
ORDER BY k.CountryName, k.[Highest Peak Name]
