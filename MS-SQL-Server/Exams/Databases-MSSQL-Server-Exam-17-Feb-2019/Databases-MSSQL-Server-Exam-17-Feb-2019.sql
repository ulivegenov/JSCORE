-- 01. DDL 
CREATE TABLE Students
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(30),
	LastName NVARCHAR(30) NOT NULL,
	Age INT,
	Address NVARCHAR(50),
	Phone NVARCHAR(10)
)

ALTER TABLE Students
ADD CONSTRAINT CH_Age  CHECK (Age BETWEEN 5 AND 100)

CREATE TABLE Subjects
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(20) NOT NULL,
	Lessons INT NOT NULL
)

ALTER TABLE Subjects
ADD CONSTRAINT CH_Lessons CHECK (Lessons > 0)

CREATE TABLE StudentsSubjects
(
	Id INT PRIMARY KEY IDENTITY,
	StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(Id),
	SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(Id),
	Grade DECIMAL (3, 2)
)

ALTER TABLE StudentsSubjects
ADD CONSTRAINT CH_Grade CHECK(Grade BETWEEN 2 AND 6)

CREATE TABLE Exams
(
	Id INT PRIMARY KEY IDENTITY,
	Date DATETIME,
	SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(Id)
)

CREATE TABLE StudentsExams
(
	StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(Id),
	ExamId INT NOT NULL FOREIGN KEY REFERENCES Exams(Id),
	Grade DECIMAL (3, 2)

	CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentId, ExamId)
)

ALTER TABLE StudentsExams
ADD CONSTRAINT CH_Grades CHECK(Grade BETWEEN 2 AND 6)

CREATE TABLE Teachers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Address NVARCHAR(20) NOT NULL,
	Phone NVARCHAR(10),
	SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(Id)
)

CREATE TABLE StudentsTeachers
(
	StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(Id),
	TeacherId INT NOT NULL FOREIGN KEY REFERENCES Teachers(Id)

	CONSTRAINT PK_StudentsTeachers PRIMARY KEY (StudentId, TeacherId)
)


-- 02. Insert 
INSERT INTO Teachers (FirstName, LastName, Address, Phone, SubjectId)
VALUES  ('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146', 6),
		('Gerrard', 'Lowin', '370 Talisman Plaza', '3324874824', 2),
		('Merrile', 'Lambdin', '81 Dahle Plaza', '4373065154', 5),
		('Bert', 'Ivie', '2 Gateway Circle', '4409584510', 4)

INSERT INTO Subjects (Name, Lessons)
VALUES  ('Geometry', 12),
		('Health', 10),
		('Drama', 7),
		('Sports', 9)


-- 03. Update 
UPDATE StudentsSubjects
SET Grade = 6.00
WHERE SubjectId IN (1 , 2) AND Grade >= 5.50

-- 04. Delete 
DELETE FROM StudentsTeachers
WHERE TeacherId IN (SELECT Id 
					FROM Teachers
					WHERE Phone LIKE '%72%')

DELETE FROM Teachers
WHERE Phone LIKE '%72%'

-- 05. Teen Students 
SELECT FirstName,
	   LastName,
	   Age
FROM Students
WHERE Age >= 12
ORDER BY FirstName, LastName

-- 06. Cool Addresses 
SELECT FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName AS [Full Name],
	   [Address]
FROM Students
WHERE Address LIKE '%ROAD%'
ORDER BY FirstName, LastName, [Address]

--07. 42 Phones 
SELECT FirstName,
	   [Address],
	   Phone
FROM Students
WHERE MiddleName IS NOT NULL 
AND Phone LIKE '42%'
ORDER BY FirstName

-- 08. Students Teachers 
SELECT s.FirstName,
	   s.LastName,
	   COUNT(st.TeacherId) AS TeachersCount
FROM Students AS s
JOIN StudentsTeachers AS st ON st.StudentId = s.Id
GROUP BY s.FirstName, s.LastName

--09. Subjects with Students 
SELECT t.FirstName + ' ' + t.LastName AS FullName,
	   sb.Name + '-' + CONVERT(NVARCHAR, sb.Lessons) AS Subjects,
	   COUNT(st.StudentId) AS Students
FROM Teachers AS t
JOIN Subjects AS sb ON sb.Id = t.SubjectId
JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
GROUP BY t.FirstName, t.LastName, sb.Name, sb.Lessons
ORDER BY COUNT(st.StudentId) DESC, FullName, Subjects

-- 10. Students to Go 
SELECT s.FirstName + ' ' + s.LastName AS [Full Name]
FROM Students AS s
LEFT JOIN StudentsExams AS se ON se.StudentId = s.Id
WHERE se.Grade IS NULL
ORDER BY [Full Name]

-- 11. Busiest Teachers
SELECT TOP(10)
	   t.FirstName,
	   t.LastName,
	   COUNT(st.StudentId) AS StudentsCount
FROM Teachers AS t
JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
GROUP BY t.FirstName, t.LastName
ORDER BY StudentsCount DESC, t.FirstName, t.LastName

-- 12. Top Students 
SELECT TOP(10)
	   s.FirstName,
	   s.LastName,
	   FORMAT(AVG(se.Grade), 'N2') AS Grade
FROM Students AS s
JOIN StudentsExams AS se ON se.StudentId = s.Id
GROUP BY s.FirstName, s.LastName
ORDER BY Grade DESC, s.FirstName, s.LastName

-- 13. Second Highest Grade 
SELECT k.FirstName,
	   k.LastName,
	   k.Grade
FROM
	(SELECT s.FirstName,
		    s.LastName,
		    sb.Grade,
		    ROW_NUMBER() OVER(PARTITION BY s.FirstName, s.LastName ORDER BY sb.Grade DESC) AS GradeRank
	FROM Students AS s
	JOIN StudentsSubjects AS sb ON sb.StudentId = s.Id) AS k
WHERE k.GradeRank = 2
ORDER BY k.FirstName, k.LastName

-- 14. Not So In The Studying 
SELECT s.FirstName + ' ' + ISNULL(s.MiddleName + ' ', '') + s.LastName AS [Full Name]
FROM Students AS s
LEFT JOIN StudentsSubjects AS sb ON sb.StudentId = s.Id
WHERE sb.SubjectId IS NULL
ORDER BY [Full Name]

-- 15. Top Student per Teacher 
SELECT j.[Teacher Full Name],
	   j.[Subject Name],
	   j.[Student Full Name],
	   FORMAT(j.AverageGrade, 'N2') AS Grade
FROM
	(SELECT k.[Teacher Full Name],
		    k.[Subject Name],
		    k.[Student Full Name],
		    k.AverageGrade,
		    ROW_NUMBER() OVER(PARTITION BY k.[Teacher Full Name] ORDER BY k.AverageGrade DESC) AS RowRank
	FROM
		(SELECT t.FirstName + ' ' + t.LastName AS [Teacher Full Name],
			   sbj.[Name] AS [Subject Name],
			   s.FirstName + ' ' + s.LastName AS [Student Full Name],
			   AVG(ssb.Grade) AS AverageGrade   
		FROM Teachers AS t
		JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
		JOIN Students AS s ON s.Id = st.StudentId
		JOIN StudentsSubjects AS ssb ON ssb.StudentId = s.Id
		JOIN Subjects AS sbj ON sbj.Id = ssb.SubjectId AND sbj.Id = t.SubjectId
		GROUP BY t.FirstName, t.LastName, s.FirstName, s.LastName, sbj.[Name]) AS k) AS j
WHERE j.RowRank = 1
ORDER BY j.[Subject Name], j.[Teacher Full Name], j.AverageGrade DESC


-- 16. Average Grade per Subject 
SELECT s.[Name],
	   AVG(ssb.Grade) AS AverageGrade
FROM Subjects AS s
JOIN StudentsSubjects AS ssb ON ssb.SubjectId = s.Id
GROUP BY s.[Name], s.Id
ORDER BY s.Id

-- 17. Exams Information 
SELECT k.[Quarter],
	   k.SubjectName,
	   COUNT(K.StudentId) AS StudentsCount
FROM
	 (SELECT CASE	
	 		   WHEN DATEPART(MONTH, e.[Date]) BETWEEN 1 AND 3 THEN 'Q1'
	 		   WHEN DATEPART(MONTH, e.[Date]) BETWEEN 4 AND 6 THEN 'Q2'
	 		   WHEN DATEPART(MONTH, e.[Date]) BETWEEN 7 AND 9 THEN 'Q3'
	 		   WHEN DATEPART(MONTH, e.[Date]) BETWEEN 10 AND 12 THEN 'Q4'
	 		   WHEN e.[Date] IS NULL THEN 'TBA'
	 	    END AS [Quarter],
	 		s.[Name] AS SubjectName,
	 		se.StudentId
	 FROM Exams AS e
	 JOIN Subjects AS s ON s.Id = e.SubjectId
	 JOIN StudentsExams AS se ON se.ExamId = e.Id
	 WHERE se.Grade >= 4) AS k
GROUP BY k.[Quarter], k.SubjectName
ORDER BY k.[Quarter]


-- 18. Exam Grades 
CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(15, 2))
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @studentExist INT = (SELECT TOP(1) 
										StudentId 
										FROM StudentsExams 
										WHERE StudentId = @studentId);

	IF @studentExist IS NULL
	BEGIN
		RETURN ('The student with provided id does not exist in the school!');
	END

	IF @grade > 6.00
	BEGIN
		RETURN ('Grade cannot be above 6.00!');
	END

	DECLARE @studentFirstName NVARCHAR(20) = (SELECT FirstName
											  FROM Students
											  WHERE Id = @studentId);

	DECLARE @biggestGrade DECIMAL(15, 2) = @grade + 0.50;
	DECLARE @count INT = (SELECT COUNT(Grade)
						  FROM StudentsExams
						  WHERE StudentId = @studentId AND Grade BETWEEN @grade AND @biggestGrade);

	RETURN ('You have to update ' + CAST(@count AS nvarchar(10)) + ' grades for the student ' + @studentFirstName);
END

GO
-- 19. Exclude From School 
CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
  BEGIN TRANSACTION
  DECLARE @StudentToDeleteId INT = (SELECT Id FROM Students WHERE Id = @StudentId)

  IF(@StudentToDeleteId IS NULL)
  BEGIN
	ROLLBACK
	RAISERROR('This school has no student with the provided id!', 11, 1);
	RETURN
  END

  DELETE StudentsExams
  WHERE StudentId = @StudentToDeleteId

  DELETE StudentsSubjects
  WHERE StudentId = @StudentToDeleteId

  DELETE StudentsTeachers
  WHERE StudentId = @StudentToDeleteId

  DELETE Students
  WHERE Id = @StudentToDeleteId

COMMIT

-- 20. Deleted Students 
CREATE TABLE ExcludedStudents
(StudentId INT PRIMARY KEY,
StudentName NVARCHAR(200) NOT NULL)

GO

CREATE TRIGGER tr_DeleteStudents ON Students FOR DELETE
AS
	INSERT INTO ExcludedStudents (StudentId, StudentName) 
	SELECT Id,
		   FirstName + ' ' + LastName AS [Full Name]
	FROM deleted



