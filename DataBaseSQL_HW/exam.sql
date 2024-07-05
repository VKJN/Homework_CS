CREATE TABLE Cars (
    Id INT PRIMARY KEY IDENTITY,
    Color NVARCHAR(50) CHECK(Color > '') NOT NULL,
    FuelAmount FLOAT CHECK(FuelAmount >= 0) NOT NULL,
    LoadCapacity FLOAT CHECK(LoadCapacity >= 0) NOT NULL,
    ConsumptionType NVARCHAR(50) CHECK(ConsumptionType > '') NOT NULL
)

CREATE TABLE CargoParties (
    Id INT PRIMARY KEY IDENTITY,
    Distance FLOAT NOT NULL,
    AverageSpeed FLOAT NOT NULL,
    ColorRestriction NVARCHAR(50) NULL,
    ConsumptionTypeRestriction NVARCHAR(50) NULL
)

CREATE TABLE Cargos (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100) CHECK(Name > '') NOT NULL,
    Weight FLOAT CHECK(Weight >= 0) NOT NULL,
	ProductLotNumber INT CHECK(ProductLotNumber >= 0) NOT NULL,
	CargoPartiesId INT NOT NULL,
	FOREIGN KEY (CargoPartiesId) REFERENCES CargoParties(Id)
)

--“аблица расхода дл€ машины
CREATE TABLE FuelConsumption (
    Id INT PRIMARY KEY IDENTITY,
    Speed INT CHECK(SPEED >= 0) NOT NULL,
    FuelConsumption INT CHECK(FuelConsumption >= 0) NOT NULL,
	CarId INT NOT NULL,
	FOREIGN KEY (CarID) REFERENCES Cars(Id)
)

GO --CREATE TRIGGER

CREATE TRIGGER CheckDeliveryParams
ON CargoParties
FOR INSERT, UPDATE
AS
BEGIN

    IF EXISTS (SELECT *	
			   FROM inserted 
			   WHERE Distance < 0 OR AverageSpeed < 0)
		THROW 50000, '–ассто€ние и средн€€ скорость должны быть неотрицательными', 1

    IF EXISTS (SELECT * FROM deleted)
		THROW 50000, '»зменение параметров доставки не допускаетс€', 1
END

--Ќе знаю, как сделать это задание:
--ѕри установке параметров доставки должен выполн€тьс€ подбор машин, подход€щих под параметры. ѕри выборе машины, ей присваиваетс€ номер обслуживаемой партии. 
--ћашина игнорируетс€, если ей уже был присвоен номер партии.
--≈сли дл€ перевозки всей партии недостаточно машин - все изменени€ должны быть отменены. » сгенерировано исключение.

GO --CREATE FUNCTION

CREATE OR ALTER FUNCTION CalculateFuelRequiredForParty (@Id INT)
RETURNS FLOAT
AS
BEGIN
	DECLARE @FuelNeeded FLOAT = 0

    IF EXISTS (SELECT 1 
			   FROM CargoParties 
			   WHERE Id = @Id)
        SELECT @FuelNeeded = SUM(fc.FuelConsumption / cp.Distance * 100)
        FROM Cars c
        JOIN FuelConsumption fc ON fc.CarId = c.Id
        JOIN CargoParties cp ON cp.Id = c.Id
        WHERE cp.Id = @Id AND fc.Speed = cp.AverageSpeed

    RETURN @FuelNeeded
END

GO 