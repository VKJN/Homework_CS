USE SportShop

CREATE TABLE Products (
    ProductID INT IDENTITY PRIMARY KEY NOT NULL,
    ProductName NVARCHAR(100) CHECK(ProductName > '') NOT NULL,
    ProductType NVARCHAR(100) CHECK(ProductType > '') NOT NULL,
    QuantityInStock INT NOT NULL,
    CostPrice MONEY NOT NULL,
    Manufacturer NVARCHAR(100) NOT NULL,
    SalePrice MONEY NOT NULL
)

CREATE TABLE Employees (
    EmployeeID INT IDENTITY PRIMARY KEY NOT NULL,
    FullName NVARCHAR(MAX) CHECK(FullName > '') NOT NULL,
    Position NVARCHAR(MAX) NOT NULL,
    HireDate DATE NOT NULL,
    Gender NVARCHAR(MAX) NOT NULL,
    Salary MONEY NOT NULL
)

CREATE TABLE Customers (
    CustomerID INT IDENTITY PRIMARY KEY NOT NULL,
    FullName NVARCHAR(MAX) CHECK(FullName > '') NOT NULL,
    Email NVARCHAR(MAX) NOT NULL,
    ContactPhone NVARCHAR(MAX) NOT NULL,
    Gender NVARCHAR(MAX) NOT NULL,
    OrderHistory NVARCHAR(MAX) NOT NULL,
    DiscountRate MONEY NOT NULL,
    SubscribedToNewsletter BIT NOT NULL,
	RegistrationDate DATE NOT NULL
)

CREATE TABLE Sales (
    SaleID INT IDENTITY PRIMARY KEY NOT NULL,
    ProductID INT NOT NULL,
    SalePrice MONEY NOT NULL,
    Quantity INT NOT NULL,
    SaleDate DATE NOT NULL,
    EmployeeID INT NOT NULL,
    CustomerID INT NOT NULL,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)

INSERT INTO Products (ProductName, ProductType, QuantityInStock, CostPrice, Manufacturer, SalePrice)
VALUES
('Кроссовки', 'Обувь', 50, 2000.00, 'Nike', 3500.00),
('Футболка', 'Одежда', 100, 500.00, 'Adidas', 900.00),
('Теннисная ракетка', 'Спортивный инвентарь', 30, 3000.00, 'Wilson', 4500.00)

INSERT INTO Employees (FullName, Position, HireDate, Gender, Salary)
VALUES
('Иванов Иван Иванович', 'Продавец', '2020-01-15', 'Мужчина', 40000.00),
('Петрова Анна Сергеевна', 'Менеджер', '2019-03-22', 'Женщина', 60000.00)

INSERT INTO Customers (FullName, Email, ContactPhone, Gender, OrderHistory, DiscountRate, SubscribedToNewsletter, RegistrationDate)
VALUES
('Сидоров Николай Александрович', 'sidorov@mail.com', '89101112233', 'Мужчина', 'Теннисная ракетка', 5.00, 1, '2020-01-01'),
('Иванова Мария Петровна', 'ivanova@mail.com', '89223334455', 'Женщина', 'Кроссовки', 10.00, 0, '2019-02-01'),
('Кузнецова Елена Викторовна', 'kuznetsova@mail.com', '89334445566', 'Женщина', 'Футболка', 7.00, 1, '2021-03-15');

INSERT INTO Sales (ProductID, SalePrice, Quantity, SaleDate, EmployeeID, CustomerID)
VALUES
(1, 3500.00, 1, '2023-06-15', 1, 1),
(2, 900.00, 2, '2023-06-16', 2, 2)

GO

CREATE OR ALTER PROCEDURE ShowAllProducts
AS BEGIN
	SELECT * FROM Products
END

GO

CREATE OR ALTER PROCEDURE ShowProductsByType
    @ProductType NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Products
    WHERE ProductType = @ProductType
END

GO

CREATE OR ALTER PROCEDURE ShowTop3OldestCustomers
AS
BEGIN
	SELECT TOP 3 * 
	FROM Customers c
	ORDER BY c.RegistrationDate ASC
END

GO

CREATE OR ALTER PROCEDURE ShowTopSeller
AS
BEGIN
    SELECT TOP 1 *, SUM(s.SalePrice * s.Quantity) AS TotalSales
    FROM Employees e
    JOIN Sales s ON e.EmployeeID = s.EmployeeID
    --GROUP BY e.EmployeeID, e.FullName
    ORDER BY TotalSales DESC
END

GO

CREATE OR ALTER PROCEDURE CheckProductAvailabilityByManufacturer
    @Manufacturer NVARCHAR(100)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Products WHERE Manufacturer = @Manufacturer AND QuantityInStock > 0)
    BEGIN
        SELECT 'yes' AS Result
    END
    ELSE
    BEGIN
        SELECT 'no' AS Result
    END
END

GO

CREATE PROCEDURE ShowTopManufacturer
AS
BEGIN
    SELECT TOP 1 p.Manufacturer, SUM(s.SalePrice * s.Quantity) AS TotalSales
    FROM Products p
    JOIN Sales s ON p.ProductID = s.ProductID
    GROUP BY p.Manufacturer
    ORDER BY TotalSales DESC
END

GO

CREATE PROCEDURE DeleteCustomersAfterDate
    @Date DATE
AS
BEGIN
    DECLARE @DeletedRows INT
    
    DELETE FROM Customers
    WHERE RegistrationDate > @Date
    
    SET @DeletedRows = @@ROWCOUNT
    
    SELECT @DeletedRows AS DeletedRecords
END

GO