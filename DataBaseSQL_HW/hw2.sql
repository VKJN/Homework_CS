DROP TABLE Departments
CREATE TABLE Departments (
	Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	Financing MONEY CHECK (Financing >= 0) NOT NULL DEFAULT 0,
	Name NVARCHAR(100) NOT NULL UNIQUE
);

DROP TABLE Faculties
CREATE TABLE Faculties (
    Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    Dean NVARCHAR(max) NOT NULL,
    Name NVARCHAR(100) NOT NULL UNIQUE
);

DROP TABLE Groups
CREATE TABLE Groups (
    Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    Name NVARCHAR(10) NOT NULL UNIQUE,
    Rating INT CHECK (Rating >= 0 AND Rating <= 5) NOT NULL,
    Year INT CHECK (Year >= 1 AND Year <= 5) NOT NULL
);

DROP TABLE Teachers
CREATE TABLE Teachers (
    Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
    EmploymentDate DATE CHECK (EmploymentDate >= '1990-01-01') NOT NULL,
    IsAssistant BIT NOT NULL DEFAULT 0,
    IsProfessor BIT NOT NULL DEFAULT 0,
    Name NVARCHAR(max) NOT NULL,
    Position NVARCHAR(max) NOT NULL,
    Premium MONEY CHECK (Premium >= 0) NOT NULL DEFAULT 0,
    Salary MONEY CHECK (Salary > 0) NOT NULL,
    Surname NVARCHAR(max) NOT NULL
);

--Заполнение таблиц для запросов
INSERT INTO Departments (Financing, Name) 
VALUES (15000, 'Computer Science'), (12000, 'Mathematics'), (10000, 'Physics'), (18000, 'Software Engineering'), (13000, 'Chemistry')

INSERT INTO Faculties (Dean, Name) 
VALUES ('Dr. Smith', 'Science'), ('Dr. Johnson', 'Arts'), ('Dr. Williams', 'Engineering')

-- Добавление записей в таблицу Groups
INSERT INTO Groups (Name, Rating, Year) 
VALUES ('GroupA', 4, 2), ('GroupB', 3, 3), ('GroupC', 5, 1), ('GroupD', 2, 4), ('GroupE', 4, 5)

-- Добавление записей в таблицу Teachers
INSERT INTO Teachers (EmploymentDate, IsAssistant, IsProfessor, Name, Position, Premium, Salary, Surname) 
VALUES ('2005-08-15', 0, 1, 'John', 'Professor', 500, 4000, 'Doe'), ('2010-03-20', 1, 0, 'Jane', 'Assistant Professor', 200, 3000, 'Smith'), 
('2008-11-10', 0, 1, 'Michael', 'Professor', 600, 4500, 'Johnson'), ('2015-07-01', 1, 0, 'Emily', 'Assistant Professor', 250, 500, 'Brown'), 
('2003-09-05', 0, 1, 'Christopher', 'Professor', 550, 4200, 'Williams')


--Сами запросы
--1
SELECT Name, Financing, Id 
FROM Departments

--2
SELECT Name AS "Group Name", Rating AS "Group Rating"
FROM Groups

--3
SELECT Surname,
       (Salary / Premium * 100) AS "Percent Salary to Premium",
       (Salary / (Salary + Premium) * 100) AS "Percent Salary to Total"
FROM Teachers

--4
SELECT CONCAT('The dean of faculty ', Name, ' is ', Dean) AS FacultyInfo
FROM Faculties

--5
SELECT Surname
FROM Teachers
WHERE IsProfessor = 1 AND Salary > 1050;

--6
SELECT Name
FROM Departments
WHERE Financing < 11000 OR Financing > 25000

--7
SELECT Name
FROM Faculties
WHERE Name != 'Computer Science'

--8
SELECT Surname, Position
FROM Teachers
WHERE IsProfessor = 0

--9
SELECT Surname, Position, Salary, Premium 
FROM Teachers
WHERE IsAssistant = 1 AND Premium BETWEEN 160 AND 550 

--10
SELECT Surname, Salary
FROM Teachers
WHERE IsAssistant = 1

--11
SELECT Surname, Position
FROM Teachers
WHERE EmploymentDate < '2000-01-01'

--12
SELECT Name AS "Name of Department"
FROM Departments
WHERE Name < 'Software Development'
ORDER BY Name

--13
SELECT Surname
FROM Teachers
WHERE IsAssistant = 1 AND (Salary + Premium) <= 1200

--14
SELECT Name
FROM Groups
WHERE Year = 5 AND Rating BETWEEN 2 AND 4

--15
SELECT Surname
FROM Teachers
WHERE IsAssistant = 1 AND (Salary < 550 OR Premium < 200)