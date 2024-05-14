--1
DROP TABLE GroupsAcademy
CREATE TABLE GroupsAcademy (
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Name NVARCHAR(10)  NOT NULL,
	Rating INT CHECK(Rating >= 0 AND Rating <= 5) NOT NULL,
	Year INT CHECK(Year >= 1 AND Year <= 5)  NOT NULL
);

INSERT INTO GroupsAcademy (Name, Rating, Year) 
VALUES ('SP-001', 3, 5), ('SP-002', 5, 5)
 
SELECT * FROM GroupsAcademy

--2
DROP TABLE Departaments
CREATE TABLE Departaments (
  Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
  Financing  MONEY CHECK(Financing >= 0) NOT NULL DEFAULT 0,
  Name NVARCHAR(100) NOT NULL
);
 
INSERT INTO Departaments (Name, Financing) 
VALUES ('philosophy', 2000), ('psychology', 4000);
 
SELECT * FROM Departaments;

--3
DROP TABLE Faculties
CREATE TABLE Faculties (
	Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	Name NVARCHAR(100) NOT NULL
);

INSERT INTO Faculties (Name) 
VALUES ('physics'), ('mathematics');
 
SELECT * FROM Faculties;

--4
DROP TABLE Teachers
CREATE TABLE Teachers (
  Id INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
  EmploymentDate DATE CHECK(EmploymentDate >= '1990-01-01') NOT NULL,
  Name NVARCHAR(max) NOT NULL,
  Premium MONEY CHECK(Premium >= 0) NOT NULL DEFAULT 0,
  Salary MONEY CHECK(Salary > 0) NOT NULL,
  Surname NVARCHAR(100) NOT NULL,
);
 
INSERT INTO Teachers (EmploymentDate, Name, Salary, Surname) 
VALUES ('1998-10-10', 'Vika', 20000, 'Polie');
 
SELECT * FROM Teachers;