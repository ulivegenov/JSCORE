/* 01. DDL  */
CREATE TABLE Users
(
 Id INT PRIMARY KEY IDENTITY,
 Username VARCHAR(30) NOT NULL,
 [Password] VARCHAR(30) NOT NULL,
 Email VARCHAR(50) NOT NULL
)


CREATE TABLE Repositories
(
 Id INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR(50) NOT NULL
)


CREATE TABLE RepositoriesContributors
(
 RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
 ContributorId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)

 CONSTRAINT PK_CompositeRepositoriesContributors PRIMARY KEY (RepositoryId, ContributorId)
)


CREATE TABLE Issues
(
 Id INT PRIMARY KEY IDENTITY,
 Title VARCHAR(255) NOT NULL,
 IssueStatus CHAR(6) NOT NULL,
 RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
 AssigneeId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
)


CREATE TABLE Commits
(
 Id INT PRIMARY KEY IDENTITY,
 [Message] VARCHAR(255) NOT NULL,
 IssueId INT FOREIGN KEY REFERENCES Issues(Id),
 RepositoryId INT NOT NULL FOREIGN KEY REFERENCES Repositories(Id),
 ContributorId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
)


CREATE TABLE Files
(
 Id INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR(100) NOT NULL,
 Size DECIMAL(10, 2) NOT NULL,
 ParentId INT FOREIGN KEY REFERENCES Files(Id),
 CommitId INT NOT NULL FOREIGN KEY REFERENCES Commits(Id)
)


/* 02. Insert  */
INSERT INTO Files([Name], Size,	ParentId, CommitId)
VALUES ('Trade.idk', 2598.0, 1,	1),
	   ('menu.net',	9238.31, 2,	2),
	   ('Administrate.soshy', 1246.93, 3, 3),
	   ('Controller.php', 7353.15, 4, 4),
	   ('Find.java', 9957.86, 5, 5),
	   ('Controller.json', 14034.87, 3,	6),
	   ('Operate.xix', 7662.92,	7, 7)


INSERT INTO Issues(Title, IssueStatus, RepositoryId, AssigneeId)
VALUES ('Critical Problem with HomeController.cs file',	'open',	1, 4),
	   ('Typo fix in Judge.html', 'open', 4, 3),
	   ('Implement documentation for UsersService.cs', 'closed', 8,	2),
	   ('Unreachable code in Index.cs',	'open',	9, 8)


/* 03. Update  */
UPDATE Issues
SET IssueStatus = 'closed' 
WHERE AssigneeId =6


/* 04. Delete  */
DELETE FROM RepositoriesContributors
WHERE RepositoryId = (SELECT Id
					  FROM Repositories
					  WHERE [Name] = 'Softuni-Teamwork')

DELETE FROM Files
WHERE CommitId = (SELECT Id
				  FROM Commits
				  WHERE RepositoryId = (SELECT Id
										FROM Repositories
										WHERE [Name] = 'Softuni-Teamwork'))

DELETE FROM Commits
WHERE RepositoryId = (SELECT Id
					  FROM Repositories
					  WHERE [Name] = 'Softuni-Teamwork')

DELETE FROM Issues
WHERE RepositoryId = (SELECT Id
					  FROM Repositories
					  WHERE [Name] = 'Softuni-Teamwork')


DELETE FROM Repositories
WHERE [Name] = 'Softuni-Teamwork'


/* 05. Commits  */
SELECT Id,
	   [Message],
	   RepositoryId,
	   ContributorId
FROM Commits
ORDER BY Id, [Message], RepositoryId, ContributorId


/* 06. Heavy HTML */
SELECT Id,
	   [Name],
	   Size
FROM Files
WHERE Size > 1000 AND [Name] LIKE '%html%'
ORDER BY Size DESC, Id, [Name]


/* 07. Issues and Users  */
SELECT i.Id,
	   u.Username + ' : ' + i.Title AS IssueAssignee
FROM Users AS u
JOIN Issues AS i ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, IssueAssignee


/* 08. Non-Directory Files  */
SELECT p.Id,
	   p.[Name],
	   CAST(p.Size AS VARCHAR) + 'KB' AS Size
FROM Files AS p
LEFT JOIN Files AS f ON f.ParentId = p.Id
WHERE f.Id IS NULL
ORDER BY p.Id, p.[Name], P.Size DESC


/* 09. Most Contributed Repositories  */
SELECT TOP(5)
	   r.Id,
	   r.[Name],
	   COUNT(rp.ContributorId) AS Comits
FROM Repositories AS r
JOIN Commits AS c ON c.RepositoryId = r.Id
JOIN RepositoriesContributors AS rp ON rp.RepositoryId = r.Id
GROUP BY r.Id, r.[Name]
ORDER BY COUNT(rp.ContributorId) DESC, r.Id, R.[Name]


/* 10. User and Files  */
SELECT u.Username,
	   AVG(f.Size) AS Size
FROM Users AS u
JOIN Commits AS c ON c.ContributorId = u.Id
JOIN Files AS f ON f.CommitId = c.Id
GROUP BY u.Username
ORDER BY AVG(f.Size) DESC, u.Username

GO
/* 11. User Total Commits  */
CREATE FUNCTION udf_UserTotalCommits(@username VARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @commits INT = (SELECT COUNT(c.Id) AS Commits
						FROM Users AS u
						JOIN Commits AS c ON c.ContributorId = u.Id
						WHERE u.Username = @username);

	RETURN @commits;
END

GO
/* 12. Find by Extensions  */
CREATE PROC usp_FindByExtension(@extension VARCHAR(5))
AS
  SELECT Id,
		 [Name],
		 CAST(Size AS VARCHAR) + 'KB' AS Size
  FROM Files
  WHERE [Name] LIKE '%' + @extension
  ORDER BY Id, [Name], Size DESC