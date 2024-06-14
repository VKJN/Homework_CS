CREATE TABLE Faculties (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(100) UNIQUE CHECK(Name > '') NOT NULL
)

CREATE TABLE Departments (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Financing MONEY CHECK(Financing >= 0) NOT NULL DEFAULT 0,
	Name NVARCHAR(100) UNIQUE CHECK(Name > '') NOT NULL,
	FacultyId INT NOT NULL,
	FOREIGN KEY (FacultyId) REFERENCES Faculties(Id) 
)

CREATE TABLE Groups (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(10) UNIQUE CHECK(Name > '') NOT NULL,
	Year INT CHECK(Year >= 1 AND Year <= 5) NOT NULL,
	DepartmentId INT NOT NULL,
	FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
)

CREATE TABLE Subjects (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(100) UNIQUE CHECK(Name > '') NOT NULL
)

CREATE TABLE Teachers (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Name NVARCHAR(max) CHECK(Name > '') NOT NULL,
	Surname NVARCHAR(max) CHECK(Surname > '') NOT NULL,
	Salary MONEY CHECK(Salary > 0) NOT NULL
)

CREATE TABLE Lectures (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DayOfWeek INT CHECK(DayOfWeek >= 1 AND DayOfWeek <= 7) NOT NULL,
	LectureRoom NVARCHAR(max) CHECK(LectureRoom > '') NOT NULL,
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

INSERT INTO Faculties (Name) 
VALUES ('Computer Science'), ('Information Technology')

INSERT INTO Departments (Name, Financing, FacultyId) 
VALUES ('Software Development', 100000, 1), ('Data Science', 150000, 1), ('Network Security', 120000, 2)

INSERT INTO Groups (Name, Year, DepartmentId) 
VALUES ('CS101', 1, 1), ('DS201', 2, 2), ('NS301', 3, 3)

INSERT INTO Subjects (Name) 
VALUES ('Algorithms'), ('Data Structures'), ('Cyber Security'), ('Database Systems')

INSERT INTO Teachers (Name, Surname, Salary) 
VALUES ('Dave', 'McQueen', 5000), ('Jack', 'Underhill', 6000), ('Anna', 'Smith', 5500)

INSERT INTO Lectures (DayOfWeek, LectureRoom, SubjectId, TeacherId) 
VALUES (1, 'D201', 1, 1), (2, 'D202', 2, 2), (3, 'D201', 3, 3), (4, 'D201', 4, 2), (5, 'D202', 1, 1)

INSERT INTO GroupsLectures (GroupId, LectureId) 
VALUES (1, 1), (2, 2), (3, 3), (1, 4), (2, 5)

SELECT COUNT(*) AS TeacherCount
FROM Teachers t
JOIN Lectures l ON l.TeacherId = t.Id
JOIN Subjects s ON s.Id = l.SubjectId
JOIN GroupsLectures gl ON gl.LectureId = l.Id 
JOIN Groups g ON g.Id = gl.GroupId
JOIN Departments d ON d.Id = g.DepartmentId
WHERE d.Name = 'Software Development'

GO

SELECT COUNT(*) AS LectureCount
FROM Lectures l
JOIN Teachers t ON t.Id = l.TeacherId
WHERE t.Name = 'Dave' AND t.Surname = 'McQueen'

GO

SELECT COUNT(*) AS LectureCount
FROM Lectures
WHERE LectureRoom = 'D201'

GO

SELECT l.LectureRoom AS NameRoom, COUNT(*) AS LectureCount
FROM Lectures l
GROUP BY LectureRoom

GO

SELECT COUNT(g.Id) AS StudentCount
FROM Groups g
JOIN GroupsLectures gl ON gl.GroupId = g.Id
JOIN Lectures l ON l.Id = gl.LectureId
JOIN Teachers t ON t.Id = l.TeacherId
WHERE t.Name = 'Jack' AND t.Surname = 'Underhill'

GO

SELECT AVG(Salary) AS AverageSalary
FROM Teachers t
JOIN Lectures l ON l.TeacherId = t.Id
JOIN Subjects s ON s.Id = l.SubjectId
JOIN GroupsLectures gl ON gl.LectureId = l.Id
JOIN Groups g ON g.Id = gl.GroupId 
JOIN Departments d ON d.Id = g.DepartmentId
JOIN Faculties f ON f.Id = d.FacultyId
WHERE f.Name = 'Computer Science'

GO

SELECT MIN(StudentCount) AS MinStudents, MAX(StudentCount) AS MaxStudents
FROM (
    SELECT COUNT(gl.GroupId) AS StudentCount
    FROM GroupsLectures gl
    GROUP BY gl.GroupId
) AS StudentCounts

GO

SELECT AVG(Financing) AS AverageFinancing
FROM Departments

GO

SELECT CONCAT(t.Name, ' ', t.Surname) AS FullTeacherName, COUNT(l.SubjectId) AS SubjectCount
FROM Teachers t
JOIN Lectures l ON l.TeacherId = t.Id
GROUP BY t.Name, t.Surname

GO

SELECT DayOfWeek, COUNT(*) AS LectureCount
FROM Lectures
GROUP BY DayOfWeek

GO

SELECT LectureRoom, COUNT(d.Id) AS DepartmentCount
FROM Lectures l
JOIN Subjects s ON s.Id = l.SubjectId
JOIN GroupsLectures gl ON gl.LectureId = l.Id
JOIN Groups g ON g.Id = gl.GroupId
JOIN Departments d ON d.Id = g.DepartmentId
GROUP BY LectureRoom

GO

SELECT f.Name AS FacultyName, COUNT(s.Id) AS SubjectCount
FROM Faculties f
JOIN Departments d ON d.FacultyId = f.Id 
JOIN Groups g ON g.DepartmentId = d.Id
JOIN GroupsLectures gl ON gl.GroupId = g.Id
JOIN Lectures l ON l.Id = gl.LectureId
JOIN Subjects s ON s.Id = l.SubjectId
GROUP BY f.Name;

GO

SELECT CONCAT(t.Name, ' ', t.Surname) AS TeacherName, LectureRoom, COUNT(*) AS LectureCount
FROM Lectures l
JOIN Teachers t ON t.Id = l.TeacherId
GROUP BY t.Name, t.Surname, LectureRoom