--EXAM

--01.
CREATE DATABASE LibraryDb
USE LibraryDb
GO

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Contacts
(
	Id INT PRIMARY KEY IDENTITY,
	Email NVARCHAR(100)  NULL,
	PhoneNumber NVARCHAR(20)  NULL,
	PostAddress NVARCHAR(200)  NULL,
	Website NVARCHAR(50)  NULL,
)

CREATE TABLE Authors
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] 	NVARCHAR(100) NOT NULL,
	ContactId INT NOT NULL,
	FOREIGN KEY (ContactId) REFERENCES Contacts(Id)
)
CREATE TABLE Books
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(100) NOT NULL,
	YearPublished INT NOT NULL,
	ISBN NVARCHAR(13) UNIQUE NOT NULL,
	AuthorId INT NOT NULL, 
	GenreId INT NOT NULL,
	FOREIGN KEY (GenreId) REFERENCES Genres(Id),
	FOREIGN KEY (AuthorId) REFERENCES Authors(Id)
)

CREATE TABLE Libraries
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] 	NVARCHAR(50) NOT NULL,
	ContactId INT NOT NULL,
	FOREIGN KEY (ContactId) REFERENCES Contacts(Id) 
)

CREATE TABLE LibrariesBooks
(
	LibraryId INT NOT NULL,
	BookId INT NOT NULL,
	PRIMARY KEY (LibraryId, BookId),
	FOREIGN KEY (LibraryId) REFERENCES Books(Id),
	FOREIGN KEY (BookId) REFERENCES Libraries(Id)
)

--03.
UPDATE Contacts 
SET Website = ('www.' + LOWER(REPLACE(a.[Name],' ','')) + '.com')
FROM Contacts c
JOIN Authors AS a ON c.Id = a.ContactId
WHERE c.Website IS NULL

--04. DELETE
SELECT Id
FROM Authors
WHERE [Name] ='Alex Michaelides'

DELETE 
FROM LibrariesBooks
WHERE BookId IN (SELECT  ID FROM Books WHERE AuthorId = 1)
DELETE
FROM Books
WHERE AuthorId = 1

DELETE 
FROM Authors
WHERE Name ='Alex Michaelides'

--05. 
SELECT Title AS [Book Title], ISBN, YearPublished AS YearReleased
FROM Books
ORDER BY YearPublished DESC, Title 

--06.
SELECT
b.Id AS Id,
b.Title AS Title,
b.ISBN AS ISBN,
g.Name AS Genre
FROM Books b
JOIN Genres g ON b.GenreId = g.Id
WHERE g.[Name] IN ('Biography', 'Historical Fiction')
ORDER BY g.[Name], b.Title

--07.
SELECT
	l.[Name] AS [Library],
	c.Email AS Email
FROM Libraries l
JOIN Contacts c ON l.ContactId = c.Id
WHERE NOT EXISTS (
	SELECT 1
	FROM LibrariesBooks lb
	JOIN Books b ON lb.BookId = b.Id
	JOIN Genres g ON b.GenreId = g.Id
	WHERE lb.LibraryId = l.Id AND g.[Name] = 'Mystery'
)
ORDER BY l.[Name]

---08.
SELECT TOP 3
b.Title AS Title, b.YearPublished AS [Year], g.[Name] AS Genre
FROM Books b
JOIN Genres g ON b.GenreId = g.Id
WHERE 
	(b.YearPublished > 2000 AND b.Title LIKE '%a%') 
	OR 
	(b.YearPublished < 1950 AND g.[Name] LIKE '%Fantasy%')
ORDER BY b.Title, b.YearPublished DESC

--09.
SELECT 
a.[Name] AS Author, c.Email AS Email, c.PostAddress AS [Address]
FROM Authors a
JOIN Contacts c ON a.ContactId = c.Id
WHERE c.PostAddress LIKE '%UK%'
ORDER BY a.[Name]

--10. 
SELECT 
a.[Name] AS Author,
b.Title AS Title,
l.[Name] AS [Library],
c.PostAddress AS [Address]
FROM Books b
JOIN Authors a ON b.AuthorId = a.Id
JOIN Genres g ON b.GenreId = g.Id
JOIN LibrariesBooks lb ON b.Id = lb.BookId
JOIN Libraries l ON lb.LibraryId = l.Id
JOIN Contacts c ON l.ContactId = c.Id
WHERE g.[Name] = 'Fiction' AND c.PostAddress LIKE '%Denver%'
ORDER BY b.Title

--11.
GO

CREATE FUNCTION udf_AuthorsWithBooks (@name NVARCHAR(50))
RETURNS INT
AS
BEGIN
DECLARE @result INT
 
 SELECT @result = COUNT(*)
 FROM Books b
 JOIN Authors a ON b.AuthorId = a.Id
 WHERE a.[Name] = @name

RETURN @result
END

GO

--12.
CREATE PROC usp_SearchByGenre (@genreName NVARCHAR(50))
AS
BEGIN
SELECT b.Title AS Title,
	b.YearPublished AS [Year], 
	b.ISBN AS ISBN,
	a.[Name] AS Author,
	g.[Name] AS Genre
FROM Books b
JOIN Genres g ON b.GenreId = g.Id
JOIN Authors a ON b.AuthorId = a.Id
WHERE g.[Name] = @genreName
ORDER BY b.Title
END