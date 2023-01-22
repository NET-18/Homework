--CREATE DATABASE Homework_16_01_2022
--GO

--USE Homework_16_01_2022
--DROP DATABASE Homework_16_01_2022
--GO
USE Homework_16_01_2022;

DROP TABLE ProductsDeliveryConditions;
DROP TABLE DeliveryConditions;
DROP TABLE Pakages;
DROP TABLE Wraps;
DROP TABLE Composition;
DROP TABLE Materials;
DROP TABLE Products;
DROP TABLE Shapes;
DROP TABLE Manufacturers;
DROP TABLE Country;

CREATE TABLE Country(
[id] INTEGER PRIMARY KEY IDENTITY(1,1),
[name] NVARCHAR(50) UNIQUE NOT NULL
);

CREATE TABLE Manufacturers(
[id] INTEGER PRIMARY KEY IDENTITY(1,1),
[name] NVARCHAR(50) UNIQUE NOT NULL, 
[countryId] INTEGER,
FOREIGN KEY (countryId) REFERENCES Country(id) ON DELETE CASCADE,
);

CREATE TABLE Shapes(
[id] INTEGER PRIMARY KEY IDENTITY(1,1),
[name] NVARCHAR(50) UNIQUE NOT NULL
);

CREATE TABLE Wraps(
[id] INTEGER PRIMARY KEY IDENTITY(1,1),
[name] NVARCHAR(50) UNIQUE NOT NULL
);

CREATE TABLE DeliveryConditions(
[id] INTEGER PRIMARY KEY IDENTITY(1,1),
[description] NVARCHAR(200) NOT NULL
);

CREATE TABLE ProductsDeliveryConditions(
[deliveryConditionId] INTEGER,
[productId] INTEGER,
[value] INTEGER 
);

CREATE TABLE Products(
[id] INTEGER PRIMARY KEY IDENTITY(1,1),
[name] NVARCHAR(50) UNIQUE NOT NULL,
[weight] INTEGER,
[wrapWeight] INTEGER,
[shapeId] INTEGER REFERENCES Shapes([id]) ON DELETE CASCADE,
[manufactureId] INTEGER,
FOREIGN KEY (manufactureId) REFERENCES Manufacturers(id) ON DELETE CASCADE,
);

CREATE TABLE Pakages(
[id] INTEGER PRIMARY KEY IDENTITY(1,1),
[wrapId] INTEGER,
[weight] INTEGER NOT NULL,
[productId] INTEGER,
[productCount] INTEGER
FOREIGN KEY (productId) REFERENCES Products(id) ON DELETE CASCADE,
);

ALTER TABLE ProductsDeliveryConditions
ADD FOREIGN KEY (productId) REFERENCES Products(id) ON DELETE CASCADE

ALTER TABLE ProductsDeliveryConditions
ADD FOREIGN KEY (deliveryConditionId) REFERENCES DeliveryConditions(id) ON DELETE CASCADE

CREATE TABLE Materials(
[id] INTEGER PRIMARY KEY IDENTITY(1,1),
[name] NVARCHAR(50) UNIQUE NOT NULL,
[proteins] INTEGER,
[carbs] INTEGER,
[fats] INTEGER,
[calories] INTEGER,
[e-number] INTEGER,
);

CREATE TABLE Composition(
[materialId] INTEGER,
[productId] INTEGER,
FOREIGN KEY (materialId) REFERENCES Materials(id) ON DELETE CASCADE,
FOREIGN KEY (productId) REFERENCES Products(id) ON DELETE CASCADE
);

ALTER TABLE Pakages
ADD FOREIGN KEY (wrapId) REFERENCES Wraps(id) ON DELETE CASCADE

INSERT INTO Country( [name]) VALUES (N'USA'); --1
INSERT INTO Country( [name]) VALUES (N'Austria'); --2
INSERT INTO Country( [name]) VALUES (N'Belarus'); --3
INSERT INTO Country( [name]) VALUES (N'Kanada'); --4
INSERT INTO Country( [name]) VALUES (N'Germany'); --5
INSERT INTO Country( [name]) VALUES (N'Switzerland'); --6
INSERT INTO Country( [name]) VALUES (N'Ukraine'); --7

INSERT INTO Manufacturers([name], [countryId]) VALUES (N'Nestle',6);--1
INSERT INTO Manufacturers([name], [countryId]) VALUES (N'Komunarka',3);--2
INSERT INTO Manufacturers([name], [countryId]) VALUES (N'Spartak',3);--3
INSERT INTO Manufacturers([name], [countryId]) VALUES (N'Roshen',7);--4
INSERT INTO Manufacturers([name], [countryId]) VALUES (N'Ferrrero',4);--5
INSERT INTO Manufacturers([name], [countryId]) VALUES (N'Halloren',5);--6

INSERT INTO Shapes([name]) VALUES (N'Candy'); --1
INSERT INTO Shapes([name]) VALUES (N'Lollipop'); --2
INSERT INTO Shapes([name]) VALUES (N'Ñhocolate bar'); --3
INSERT INTO Shapes([name]) VALUES (N'Montpensier'); --4
INSERT INTO Shapes([name]) VALUES (N'Toffee'); --5
INSERT INTO Shapes([name]) VALUES (N'Truffle'); --6

INSERT INTO Wraps([name]) VALUES (N'Twist'); --1
INSERT INTO Wraps([name]) VALUES (N'Flowpack'); --2
INSERT INTO Wraps([name]) VALUES (N'A bar'); --3
INSERT INTO Wraps([name]) VALUES (N'A sock'); --4

INSERT INTO Materials([name],proteins, carbs, fats, calories) VALUES (N'Chokolate', 5, 36, 56, 544); --1
INSERT INTO Materials([name],proteins, carbs, fats, calories) VALUES (N'Sugar', 0, 100, 0, 387); --2
INSERT INTO Materials([name],[e-number]) VALUES (N'E326', 326); --3

INSERT INTO Products([name], [weight],shapeId, manufactureId) VALUES (N'Stolichnye_Small',20, 1, 2); --1
INSERT INTO Products([name], [weight],shapeId, manufactureId) VALUES (N'Stolichnye_Big',50, 3, 2); --2
INSERT INTO Products([name], [weight],shapeId, manufactureId) VALUES (N'Alyonka-Small',20, 3, 2); --3
INSERT INTO Products([name], [weight],shapeId, manufactureId) VALUES (N'Alyonka-Big',100, 3, 2); --4
INSERT INTO Products([name], [weight],shapeId, manufactureId) VALUES (N'Shalena-Bjilka',10, 3, 4); --5

INSERT INTO Pakages(wrapId, [weight], productId, productCount) VALUES (2, 5, 1, 1); --1
INSERT INTO Pakages(wrapId, [weight], productId, productCount) VALUES (3, 5, 2, 1); --2
INSERT INTO Pakages(wrapId, [weight], productId, productCount) VALUES (3, 5, 3, 1); --3
INSERT INTO Pakages(wrapId, [weight], productId, productCount) VALUES (3, 10, 4, 1); --4
INSERT INTO Pakages(wrapId, [weight], productId, productCount) VALUES (1, 5, 5, 1); --5

INSERT INTO DeliveryConditions([description]) VALUES (N'Value:'); --1
INSERT INTO DeliveryConditions([description]) VALUES (N'Numbers:'); --2
INSERT INTO DeliveryConditions([description]) VALUES (N'Humidity:'); --3
INSERT INTO DeliveryConditions([description]) VALUES (N'Marks:'); --4

INSERT INTO ProductsDeliveryConditions([deliveryConditionId],[productId],[value]) VALUES (1, 1, 20); 
INSERT INTO ProductsDeliveryConditions([deliveryConditionId],[productId],[value]) VALUES (2, 1, 10); 
INSERT INTO ProductsDeliveryConditions([deliveryConditionId],[productId],[value]) VALUES (3, 1, 15); 
INSERT INTO ProductsDeliveryConditions([deliveryConditionId],[productId],[value]) VALUES (4, 1, 0); 

INSERT INTO ProductsDeliveryConditions([deliveryConditionId],[productId],[value]) VALUES (1, 2, 10);
INSERT INTO ProductsDeliveryConditions([deliveryConditionId],[productId],[value]) VALUES (2, 2, 2); 
INSERT INTO ProductsDeliveryConditions([deliveryConditionId],[productId],[value]) VALUES (3, 2, 30); 
INSERT INTO ProductsDeliveryConditions([deliveryConditionId],[productId],[value]) VALUES (4, 2, 2);

INSERT INTO ProductsDeliveryConditions([deliveryConditionId],[productId],[value]) VALUES (1, 3, 30);
INSERT INTO ProductsDeliveryConditions([deliveryConditionId],[productId],[value]) VALUES (2, 3, 20); 
INSERT INTO ProductsDeliveryConditions([deliveryConditionId],[productId],[value]) VALUES (3, 3, 20); 
INSERT INTO ProductsDeliveryConditions([deliveryConditionId],[productId],[value]) VALUES (4, 3, 1);

INSERT INTO ProductsDeliveryConditions([deliveryConditionId],[productId],[value]) VALUES (1, 4, 25);
INSERT INTO ProductsDeliveryConditions([deliveryConditionId],[productId],[value]) VALUES (2, 4, 5); 
INSERT INTO ProductsDeliveryConditions([deliveryConditionId],[productId],[value]) VALUES (3, 4, 5); 
INSERT INTO ProductsDeliveryConditions([deliveryConditionId],[productId],[value]) VALUES (4, 4, 9);

INSERT INTO ProductsDeliveryConditions([deliveryConditionId],[productId],[value]) VALUES (1, 5, 20);
INSERT INTO ProductsDeliveryConditions([deliveryConditionId],[productId],[value]) VALUES (2, 5, 40); 
INSERT INTO ProductsDeliveryConditions([deliveryConditionId],[productId],[value]) VALUES (3, 5, 9); 
INSERT INTO ProductsDeliveryConditions([deliveryConditionId],[productId],[value]) VALUES (4, 5, 8);

SELECT wrapId, AVG(p.[weight]) Average 
FROM Pakages AS pac
JOIN Products p ON productId = p.id
GROUP BY wrapId

SELECT p.shapeId, AVG(pdc.[value]) Average_Humidity 
FROM ProductsDeliveryConditions AS pdc
JOIN Products p ON productId = p.id
WHERE deliveryConditionId = 3
GROUP BY p.shapeId
