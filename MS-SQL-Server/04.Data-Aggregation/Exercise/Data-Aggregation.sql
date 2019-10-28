/* 01.Records’ Count */
SELECT COUNT(*) AS [Count]
FROM WizzardDeposits


/* 02.Longest Magic Wand */
SELECT MAX(MagicWandSize) AS LongestMagicWand 
FROM WizzardDeposits


/* 03.Longest Magic Wand per Deposit Groups */
SELECT 
	DepositGroup, 
	MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup


/* 04.Smallest Deposit Group per Magic Wand Size*/
SELECT TOP(2) DepositGroup 
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)


/* 05.Deposits Sum */
SELECT 
	DepositGroup,
	SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup


/* 06.Deposits Sum for Ollivander Family */
SELECT 
	DepositGroup,
	SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY 
	DepositGroup, 
	MagicWandCreator
HAVING MagicWandCreator = 'Ollivander family'


/* 07.Deposits Filter */
SELECT 
	DepositGroup,
	SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY 
	DepositGroup,
	MagicWandCreator
HAVING 
	MagicWandCreator = 'Ollivander family'
	AND SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC


/* 08. Deposit Charge*/
SELECT
	DepositGroup,
	MagicWandCreator,
	MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY
	MagicWandCreator,
	DepositGroup


/* 09.Age Groups */
--SELECT  
--	CASE
--		WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
--		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
--		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
--		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
--		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
--		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
--		ELSE '[61+]'
--	END AS AgeGroup,
--	COUNT(*) AS WizardCount
--FROM WizzardDeposits
--GROUP BY CASE
--		WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
--		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
--		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
--		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
--		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
--		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
--		ELSE '[61+]'
--	END 

SELECT AgeGroup ,
	   COUNT(*) AS [Count] 
FROM (SELECT  
		CASE
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		END AS AgeGroup 
		FROM WizzardDeposits) AS AgeGroupTable
GROUP BY AgeGroup


 /* 10.First Letter */
 --First Solve
 SELECT LEFT(FirstName, 1) 
 FROM WizzardDeposits
 WHERE DepositGroup = 'Troll Chest'
 GROUP BY LEFT(FirstName, 1)
 ORDER BY LEFT(FirstName, 1)

 --Second solve
SELECT SUBSTRING(FirstName, 1, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY SUBSTRING(FirstName, 1, 1)
ORDER BY SUBSTRING(FirstName, 1, 1)


 /* 11.Average Interest */
 SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS AverageInterest
 FROM WizzardDeposits
 WHERE DepositStartDate > '01/01/1985'
 GROUP BY IsDepositExpired, DepositGroup
 ORDER BY DepositGroup DESC, IsDepositExpired


 /* 12.Rich Wizard, Poor Wizard*/
 -- FIRST WAY TO SOLVE
 SELECT SUM(DepositAmountsTable.[Difference])
 FROM (SELECT DepositAmount - LEAD(DepositAmount, 1) OVER (ORDER BY id) AS [Difference]
	   FROM WizzardDeposits) AS DepositAmountsTable

-- SECOND WAY TO SOLVE
SELECT SUM(MyTable.DepositAmount - MyTable.NextDepositAmount) AS SumDifference
FROM (SELECT DepositAmount, 
	   (SELECT DepositAmount 
	    FROM WizzardDeposits AS w 
	    WHERE w.Id = wd.Id +1) AS NextDepositAmount
      FROM WizzardDeposits AS wd) AS MyTable


/* 13.Departments Total Salaries */
SELECT DepartmentID, SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentID


/* 14.Employees Minimum Salaries */
SELECT DepartmentID, MIN(Salary) AS MinimumSalary
FROM Employees
WHERE DepartmentID IN (2, 5, 7)
GROUP BY DepartmentID


/* 15.Employees Average Salaries */
SELECT * INTO TopPaidEmployees
FROM Employees
WHERE Salary > 30000

DELETE 
FROM TopPaidEmployees
WHERE ManagerID = 42

UPDATE TopPaidEmployees
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary
FROM TopPaidEmployees
GROUP BY DepartmentID


/* 16.Employees Maximum Salaries*/
SELECT DepartmentID, MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000


/* 17.Employees Count Salaries */
SELECT COUNT(FirstName) AS [Count]
FROM Employees
WHERE ManagerID IS NULL
GROUP BY ManagerID


/* 18.3rd Highest Salary*/
SELECT MyTable.DepartmentID, MyTable.Salary AS ThirdHighestSalary 
FROM (SELECT 
	   DepartmentID, 
	   Salary,
	   DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Rank] 
	  FROM Employees) AS MyTable
WHERE MyTable.[Rank] = 3
GROUP BY MyTable.DepartmentID, MyTable.Salary


/* 19.Salary Challenge*/
SELECT TOP(10)
	   FirstName,
	   LastName,
	   DepartmentID
FROM Employees AS e
WHERE e.Salary > (SELECT	
					AVG(Salary) AS AverageSalary 
					FROM Employees AS em 
					WHERE e.DepartmentID = em.DepartmentID)
ORDER BY e.DepartmentID
 



