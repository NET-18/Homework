--USE MASTER
--DROP DATABASE Homework_09_01_2022
--GO
USE Homework_09_01_2022;

--DROP TABLE CustomerDemographics;
--DROP TABLE Customers;
--DROP TABLE Employees;
--DROP TABLE EmployeeTeritories;
--DROP TABLE Region;
--DROP TABLE Shippers;
--DROP TABLE Territories;

CREATE TABLE Region(
[RegionId] INTEGER PRIMARY KEY IDENTITY(1,1),
[RegionDescription] NVARCHAR
);

CREATE TABLE Territories(
[TerritoryId] INTEGER PRIMARY KEY IDENTITY(1,1),
[TerritoryDescription] NVARCHAR,
[RegionId] INTEGER,
FOREIGN KEY (RegionId) REFERENCES Region(RegionId) ON DELETE CASCADE, 
);

CREATE TABLE Employees(
[EmployeeId] INTEGER PRIMARY KEY IDENTITY(1,1) ,
[FirstName] NVARCHAR,
[LastName] NVARCHAR,
[Title] NVARCHAR,
[TitleOfCourtensy] NVARCHAR,
[BirthDate] DATETIME2,
[HireDate] DATETIME2,
[Adress] NVARCHAR ,
[City] NVARCHAR ,
[Region] NVARCHAR ,
[Counrty] NVARCHAR ,
[PostalCode] NVARCHAR ,
[HomePhone] INTEGER,
[Extension] INTEGER,
[Notes] NVARCHAR,
[ResportsTo] INTEGER,
[PhotoPath] NVARCHAR,
FOREIGN KEY (ResportsTo) REFERENCES Employees(EmployeeId) ON DELETE NO ACTION
);

CREATE TABLE EmployeeTeritories(
[EmployeeId] INTEGER NOT NULL,
[TerritoryId] INTEGER NOT NULL,
FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId) ON DELETE CASCADE, 
FOREIGN KEY (TerritoryId) REFERENCES Territories(TerritoryId) ON DELETE CASCADE
 );

CREATE TABLE Shippers(
[ShipperId] INTEGER PRIMARY KEY IDENTITY(1,1) NOT NULL,
[CompanyName] NVARCHAR,
 );

CREATE TABLE Customers(
[CustomerId] INTEGER PRIMARY KEY IDENTITY(1,1) NOT NULL,
[CompanyName] NVARCHAR,
[ContactName] NVARCHAR,
[ContactTitle] NVARCHAR,
[Adress] NVARCHAR,
[City] NVARCHAR,
[Region] NVARCHAR,
[PostalCode] NVARCHAR,
[Country] NVARCHAR,
[Phone] INTEGER,
[Fax] INTEGER
 );

 CREATE TABLE Orders(
[OrderId] INTEGER PRIMARY KEY IDENTITY(1,1) NOT NULL,
[CustomerId] INTEGER NOT NULL,
[EmployeeId] INTEGER NOT NULL,
[OrderDate] DATETIME2,
[RequerDate] DATETIME2,
[ShipperDate] DATETIME2,
[ShipVia] INTEGER,
[Freght] INTEGER,
[ShipName] NVARCHAR,
[ShipAdress] NVARCHAR,
[ShipCity] NVARCHAR,
[ShipRergion] NVARCHAR,
[ShipPostalCode] INTEGER,
[ShipCountry] NVARCHAR,
FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId) ON DELETE CASCADE, 
FOREIGN KEY (ShipVia) REFERENCES Shippers(ShipperId) ON DELETE CASCADE,
FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId) ON DELETE CASCADE, 
 );

CREATE TABLE CustomerDemographics(
[CustomerDescr] NVARCHAR,
[CustomerTypeId] INTEGER PRIMARY KEY IDENTITY(1,1) NOT NULL,
 );

CREATE TABLE CustomerCustomerDemographics(
[CustomerId] INTEGER,
[CustomerTypeId] INTEGER NOT NULL,
FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId) ON DELETE CASCADE, 
FOREIGN KEY (CustomerTypeId) REFERENCES CustomerDemographics(CustomerTypeId) ON DELETE CASCADE,
 );

CREATE TABLE Categories(
[CategoryId] INTEGER PRIMARY KEY IDENTITY(1,1),
[CategoryName] NVARCHAR,
[Description] NVARCHAR,
[Picture] NVARCHAR
 );

 CREATE TABLE Suppliers(
[SupplierId] INTEGER PRIMARY KEY IDENTITY(1,1),
[CompanyName] NVARCHAR,
[ContactName] NVARCHAR,
[Adress] NVARCHAR,
[City] NVARCHAR,
[Region] NVARCHAR,
[PostalCode] INTEGER,
[Country] NVARCHAR,
[Phone] INTEGER,
[Fax] INTEGER,
[HomePage] NVARCHAR,
 );

 CREATE TABLE Products(
[ProductId] INTEGER PRIMARY KEY IDENTITY(1,1),
[ProductName] NVARCHAR,
[SupplierId] INTEGER,
[CategoryId] INTEGER,
[QuantityPerUnit] BIT,
[UnitPrice] INTEGER,
[UnitStock] INTEGER,
[UnitInOrder] INTEGER,
[RecordLevel] INTEGER,
[Discontiued] INTEGER,
FOREIGN KEY (SupplierId) REFERENCES Suppliers(SupplierId) ON DELETE CASCADE, 
FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId) ON DELETE CASCADE,
 );

 CREATE TABLE OrderDetails(
[OrderId] INTEGER,
[ProductId] INTEGER,
[UnitPrice] NVARCHAR,
[Quantity] NVARCHAR,
[Discount] NVARCHAR,
FOREIGN KEY (OrderId) REFERENCES Orders(OrderId) ON DELETE CASCADE, 
FOREIGN KEY (ProductId) REFERENCES Products(ProductId) ON DELETE CASCADE,
 );