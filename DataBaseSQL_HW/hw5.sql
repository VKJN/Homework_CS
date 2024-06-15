CREATE TABLE Curators (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(MAX) CHECK(Name > '') NOT NULL, 
	Surname NVARCHAR(MAX) CHECK(Surname > '') NOT NULL
)

CREATE TABLE Faculties (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(100) UNIQUE CHECK(Name > '') NOT NULL
)

CREATE TABLE Departments (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Building INT CHECK(1 <= Building AND Building <= 5) NOT NULL,
	Financing MONEY CHECK(Financing >= 0) NOT NULL DEFAULT 0,
	Name NVARCHAR(100) UNIQUE CHECK(Name > '') NOT NULL,
	FacultyId INT NOT NULL,
	FOREIGN KEY(FacultyId) REFERENCES Faculties(Id)
)

CREATE TABLE Groups (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(10) UNIQUE CHECK(Name > '') NOT NULL,
	Year INT CHECK(Year >= 1 AND Year <= 5) NOT NULL,
	DepartmentId INT NOT NULL,
	FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
)

CREATE TABLE GroupsCurators (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CuratorId INT NOT NULL,
	FOREIGN KEY (CuratorId) REFERENCES Curators(Id),
	GroupId INT NOT NULL,
	FOREIGN KEY (GroupId) REFERENCES Groups(Id)
)

CREATE TABLE Subjects (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(100) UNIQUE CHECK(Name > '') NOT NULL
)

CREATE TABLE Teachers (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(max) CHECK(Name > '') NOT NULL,
	Surname NVARCHAR(max) CHECK(Surname > '') NOT NULL,
	Salary MONEY CHECK(Salary > 0) NOT NULL,
	IsProfessor BIT NOT NULL DEFAULT 0
)

CREATE TABLE Students (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(MAX) CHECK(Name > '') NOT NULL,
	Rating INT CHECK(0 <= Rating AND Rating <= 5) NOT NULL,
	Surname NVARCHAR(MAX) CHECK(Surname > '') NOT NULL
)

CREATE TABLE Lectures (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Date DATE CHECK(Date <= '2024-06-15') NOT NULL,
	SubjectId INT NOT NULL,
	FOREIGN KEY (SubjectId) REFERENCES Subjects(Id),
	TeacherId INT NOT NULL,
	FOREIGN KEY (TeacherId) REFERENCES Teachers(Id)
)

CREATE TABLE GroupsLectures (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	GroupId INT NOT NULL,
	FOREIGN KEY (GroupId) REFERENCES Groups(Id),
	LectureId INT NOT NULL,
	FOREIGN KEY (LectureId) REFERENCES Lectures(Id)
)

CREATE TABLE GroupsStudents (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	GroupId INT NOT NULL,
	FOREIGN KEY (GroupId) REFERENCES Groups(Id),
	StudentId INT NOT NULL,
	FOREIGN KEY (StudentId) REFERENCES Students(Id)
)

INSERT INTO Curators (Name, Surname) 
VALUES ('John', 'Doe'), ('Jane', 'Smith'), ('Albert', 'Johnson');

INSERT INTO Faculties (Name) 
VALUES ('Computer Science'), ('Information Technology');

INSERT INTO Departments (Building, Financing, Name, FacultyId) 
VALUES (1, 120000, 'Software Development', 1), (2, 80000, 'Network Engineering', 2), (3, 130000, 'Data Science', 1)

INSERT INTO Groups (Name, Year, DepartmentId) 
VALUES ('D221', 5, 1), ('D222', 5, 1), ('N101', 3, 2)

INSERT INTO GroupsCurators (CuratorId, GroupId) 
VALUES (1, 1), (2, 1), (3, 2)

INSERT INTO Subjects (Name) 
VALUES ('Algorithms'), ('Data Structures'), ('Network Security')

INSERT INTO Teachers (Name, Surname, Salary, IsProfessor) 
VALUES ('Alice', 'Brown', 75000, 1), ('Bob', 'White', 60000, 0), ('Charlie', 'Green', 80000, 1)

INSERT INTO Students (Name, Rating, Surname) 
VALUES ('David', 4, 'Wilson'), ('Eva', 3, 'Martinez'), ('Frank', 5, 'Lopez'), ('Grace', 2, 'Harris'), ('Henry', 1, 'Clark')

INSERT INTO Lectures (Date, SubjectId, TeacherId) 
VALUES ('2024-06-01', 1, 1), ('2024-06-11', 1, 1), ('2024-06-12', 2, 2), ('2024-06-03', 2, 2), ('2024-06-14', 3, 3), ('2024-06-05', 1, 1)

INSERT INTO GroupsLectures (GroupId, LectureId) 
VALUES (1, 1), (1, 2), (1, 3), (2, 4), (2, 5), (3, 6)

INSERT INTO GroupsStudents (GroupId, StudentId) 
VALUES (1, 1), (1, 2), (2, 3), (3, 4), (3, 5)

SELECT d.Building AS Number
FROM Departments d
WHERE d.Financing > 100000

GO
-- I don't know how to complete the second and third tasks
--GO

SELECT t.Name, t.Surname
FROM Teachers t
WHERE Salary > (SELECT AVG(Salary) FROM Teachers t WHERE t.IsProfessor = 1)

GO

SELECT g.Name AS GroupName
FROM Groups g
JOIN GroupsCurators gc ON gc.GroupId = g.Id
GROUP BY g.Name
HAVING COUNT(gc.CuratorId) > 1

GO

; WITH GroupRatings AS (
	SELECT g.Id, g.Name, g.Year, AVG(s.Rating) AS AvgRating
	FROM Groups g
	JOIN GroupsStudents gs ON g.Id = gs.GroupId
    JOIN Students s ON gs.StudentId = s.Id
	GROUP BY g.Id, g.Name, g.Year
)

SELECT gr.Name
FROM GroupRatings gr
WHERE gr.AvgRating < (SELECT MIN(gr.AvgRating) FROM GroupRatings gr WHERE gr.Year = 5)

GO

; WITH FacultyFunding AS (
	SELECT f.Name, SUM(d.Financing) AS SumFinancing
	FROM Faculties f
	JOIN Departments d ON d.FacultyId = f.Id
	GROUP BY f.Name
)

SELECT ff.Name
FROM FacultyFunding ff
WHERE ff.SumFinancing > (SELECT ff.SumFinancing FROM FacultyFunding ff WHERE ff.Name = 'Computer Science')

GO

; WITH LectureCounts AS (
    SELECT l.SubjectId, l.TeacherId, COUNT(*) AS LectureCount
    FROM Lectures l
    GROUP BY l.SubjectId, l.TeacherId
)

SELECT s.Name AS SubjectName, CONCAT(t.Name, ' ', t.Surname) AS TeacherName
FROM LectureCounts lc
JOIN Subjects s ON s.Id = lc.SubjectId
JOIN Teachers t ON t.Id = lc.TeacherId
WHERE lc.LectureCount = (SELECT MAX(lc.LectureCount) FROM LectureCounts lc)


GO

SELECT TOP 1 s.Name
FROM Subjects s
JOIN Lectures l ON s.Id = l.SubjectId
GROUP BY s.Name
ORDER BY COUNT(l.Id) ASC

GO

; WITH StudentCounts AS (
    SELECT g.DepartmentId, COUNT(gs.StudentId) AS StudentCount
    FROM Groups g
    JOIN GroupsStudents gs ON gs.GroupId = g.Id
    GROUP BY g.DepartmentId
),
SubjectCounts AS (
    SELECT g.DepartmentId, COUNT(l.SubjectId) AS SubjectCount
    FROM Groups g
    JOIN GroupsLectures gl ON gl.GroupId = g.Id
    JOIN Lectures l ON l.Id = gl.LectureId
    GROUP BY g.DepartmentId
)

SELECT sc.StudentCount, ssc.SubjectCount
FROM Departments d
JOIN StudentCounts sc ON sc.DepartmentId = d.Id
JOIN SubjectCounts ssc ON ssc.DepartmentId = d.Id
WHERE d.Name = 'Software Development'
