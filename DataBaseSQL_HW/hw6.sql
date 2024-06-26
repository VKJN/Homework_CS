--CREATE DATABASE SportsStore
USE SportsStore

CREATE TABLE Products ( 
	Id int primary key identity,
	Name nvarchar(100) check(Name > '') not null, 
	Type nvarchar(100) check(Type > '') not null,
	Count int not null, 
	Cost int check(Cost > 0) not null,
	Manufacturer nvarchar(100) not null, 
	RetailPrice int not null
)

CREATE TABLE Sales ( 
	Id int primary key identity,
	Name nvarchar(100) check(Name > '') not null, 
	Cost int check(Cost > 0) not null,
	Amount int check(Amount > 0) not null,
	SellerInfo nvarchar(100) not null, 
	BuyerInfo nvarchar(100) not null,
)

CREATE TABLE Outbox (  
	Id bigint primary key identity,
	EventType varchar(500) not null, 
	Message nvarchar(max) not null,
)

--Проверка
INSERT INTO SALES(Name, Cost, Amount, SellerInfo, BuyerInfo)
VALUES('o', 1, 2, 'a', 'b')

INSERT INTO SALES(Name, Cost, Amount, SellerInfo, BuyerInfo)
VALUES('o', 1, 2, 'qweq', 'asasd')

GO

CREATE OR ALTER TRIGGER SalesMade 
ON Sales
AFTER INSERT
AS
	INSERT INTO Outbox(EventType, Message) 
		SELECT 'Sale', (SELECT i.*  
						FOR JSON PATH, WITHOUT_ARRAY_WRAPPER) 
		FROM inserted i

GO

SELECT * FROM Outbox