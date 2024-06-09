CREATE TABLE Curators (
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	Name NVARCHAR(max) CHECK(Name > '') NOT NULL,
	Surname NVARCHAR(max) CHECK(Surname > '') NOT NULL
);

CREATE TABLE Faculties (
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	Financing MONEY CHECK (Financing >= 0) NOT NULL DEFAULT 0,
	Name NVARCHAR(100) CHECK(Name > '') NOT NULL UNIQUE,
);
	
CREATE TABLE Departments (
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	Financing MONEY CHECK (Financing >= 0) NOT NULL DEFAULT 0,
	Name NVARCHAR(100) CHECK(Name > '') NOT NULL UNIQUE,

	FacultyId INT NOT NULL,
	FOREIGN KEY (FacultyId) REFERENCES Faculties(Id) 
);

CREATE TABLE Groups (
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	Name NVARCHAR(10) CHECK(Name > '') NOT NULL UNIQUE,
	Year INT CHECK(1 <= Year AND Year <= 5) NOT NULL,

	DepartmentId INT NOT NULL,
	FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
);

CREATE TABLE GroupsCurators (
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	CuratorId INT NOT NULL,
	GroupId INT NOT NULL,
	FOREIGN KEY (CuratorId) REFERENCES Curators(Id),
    FOREIGN KEY (GroupId) REFERENCES Groups(Id)
);

CREATE TABLE Subjects (
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	Name NVARCHAR(100) CHECK(Name > '') NOT NULL UNIQUE,
);

CREATE TABLE Teachers (
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	Name NVARCHAR(max) CHECK(Name > '') NOT NULL,
	Salary MONEY CHECK(Salary > 0) NOT NULL,
	Surname NVARCHAR(max) CHECK(Surname > '') NOT NULL
);

CREATE TABLE Lectures (
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	LectureRoom NVARCHAR(max) CHECK(LectureRoom > '') NOT NULL,
	SubjectId INT NOT NULL,
	TeacherId INT NOT NULL,
	FOREIGN KEY (SubjectId) REFERENCES Subjects(Id),
    FOREIGN KEY (TeacherId) REFERENCES Teachers(Id)
);

CREATE TABLE GroupsLectures (
	Id INT IDENTITY PRIMARY KEY NOT NULL,
	GroupId INT NOT NULL,
	LectureId INT NOT NULL,
	FOREIGN KEY (GroupId) REFERENCES Groups(Id),
    FOREIGN KEY (LectureId) REFERENCES Lectures(Id)
);

INSERT INTO Curators (Name, Surname)
VALUES 
('John', 'Doe'),
('Jane', 'Smith');

INSERT INTO Faculties (Financing, Name)
VALUES 
(40000, 'Engineering'),
(60000, 'Computer Science');

INSERT INTO Departments (Financing, Name, FacultyId)
VALUES 
(20000, 'Mechanical Engineering', 1),
(30000, 'Computer Engineering', 1),
(40000, 'Database Systems', 2),
(25000, 'Networks', 2);

INSERT INTO Groups (Name, Year, DepartmentId)
VALUES 
('P101', 1, 1),
('P102', 1, 1),
('P103', 2, 2),
('P104', 2, 2),
('P105', 3, 3),
('P106', 3, 3),
('P107', 4, 3),
('P108', 4, 4),
('P109', 5, 4),
('P110', 5, 4);

INSERT INTO GroupsCurators (CuratorId, GroupId)
VALUES 
(1, 1),
(2, 2),
(1, 3),
(2, 4),
(1, 5),
(2, 6),
(1, 7),
(2, 8),
(1, 9),
(2, 10);

INSERT INTO Subjects (Name)
VALUES 
('Mathematics'),
('Physics'),
('Computer Science'),
('Database Theory'),
('Networking');

INSERT INTO Teachers (Name, Salary, Surname)
VALUES 
('John', 3000, 'Doe'),
('Jane', 3500, 'Smith'),
('Samantha', 4000, 'Adams'),
('Michael', 3800, 'Brown');

INSERT INTO Lectures (LectureRoom, SubjectId, TeacherId)		
VALUES 
('A101', 1, 1),
('A102', 2, 2),
('A103', 3, 3),
('B101', 4, 4),
('B102', 5, 3),
('B103', 4, 1);

INSERT INTO GroupsLectures (GroupId, LectureId)
VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 4),
(8, 5),
(9, 6),
(10, 6);

SELECT t.Name AS TeacherName, t.Surname AS TeacherSurname, g.Name AS GroupName
FROM Teachers t, Groups g

GO

SELECT f.Name AS FacultieName
FROM Faculties f
JOIN Departments d ON d.FacultyId = f.Id
GROUP BY f.Name, f.Financing
HAVING SUM(d.Financing) > f.Financing

GO

SELECT c.Surname AS CuratorSurname, g.Name AS GroupName
FROM GroupsCurators gc
JOIN Curators c ON gc.CuratorId = c.Id
JOIN Groups g ON gc.GroupId = g.Id;

GO

SELECT t.Name AS TeacherName, t.Surname AS TeacherSurname
FROM Groups g
JOIN GroupsLectures gl ON gl.GroupId = g.Id
JOIN Lectures l ON l.Id = gl.LectureId
JOIN Teachers t ON l.TeacherId = t.Id
WHERE g.Name = 'P107'

GO

SELECT t.Surname AS TeacherName, f.Name AS FacultyName 
FROM Teachers t
JOIN Lectures l ON t.Id = l.TeacherId
JOIN GroupsLectures gl ON l.Id = gl.LectureId
JOIN Groups g ON gl.GroupId = g.Id
JOIN Departments d ON g.DepartmentId = d.Id
JOIN Faculties f ON d.FacultyId = f.Id

GO

SELECT d.Name As DepartmentName, g.Name AS GroupName
FROM Departments d
JOIN Groups g ON g.DepartmentId = d.Id

GO

SELECT s.Name AS SubjectName
FROM Subjects s
JOIN Lectures l ON l.SubjectId = s.Id
JOIN Teachers t ON l.TeacherId = t.id
WHERE t.Name = 'Samantha' AND t.Surname = 'Adams'

GO

SELECT d.Name As DepartmentName
FROM Departments d
JOIN Groups g ON g.DepartmentId = d.Id
JOIN GroupsLectures gl ON gl.GroupId = g.Id
JOIN Lectures l ON gl.LectureId = l.Id
JOIN Subjects s ON s.Id = l.SubjectId
WHERE s.Name = 'Database Theory'

GO 

SELECT g.Name AS GroupName
FROM Groups g
JOIN GroupsLectures gl ON gl.GroupId = g.Id
JOIN Lectures l ON gl.LectureId = l.Id
JOIN Subjects s ON s.Id = l.SubjectId
WHERE s.Name = 'Computer Science'

GO 

SELECT g.Name AS GroupName, f.Name AS FacultyName
FROM Groups g
JOIN Departments d ON g.DepartmentId = d.Id
JOIN Faculties f ON f.Id = d.FacultyId
WHERE g.Year = 5

GO

SELECT CONCAT(t.Name, ' ', t.Surname) AS TeacherFullName, s.Name AS SubjectName, g.Name AS GroupName
FROM Teachers t
JOIN Lectures l ON t.Id = l.TeacherId
JOIN Subjects s ON l.SubjectId = s.Id
JOIN GroupsLectures gl ON l.Id = gl.LectureId
JOIN Groups g ON gl.GroupId = g.Id
WHERE l.LectureRoom = 'B103';