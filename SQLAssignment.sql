DROP TABLE IF EXISTS Orders
DROP TABLE IF EXISTS Customers
DROP TABLE IF EXISTS Products

CREATE TABLE Products (
	ID INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(99),
	Price MONEY
)

CREATE TABLE Customers (
	ID INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(99),
	LastName NVARCHAR(99),
	CardNumber NVARCHAR(16)
)

CREATE TABLE Orders (
	ID INT PRIMARY KEY IDENTITY,
	ProductID INT FOREIGN KEY REFERENCES Products (ID),
	CustomerID INT FOREIGN KEY REFERENCES Customers (ID)
)

INSERT INTO Products (Name, Price) VALUES
	('Bagel', 2), ('Muffin', 3), ('Cin. Roll', 4)
INSERT INTO Customers (FirstName, LastName, CardNumber) VALUES
	('Matt', 'Goodman', '1234567890123456'), ('Nick', 'Escalona', '0987654321098765'), ('Joe', 'Biden', '5555555555555555')
INSERT INTO Orders (ProductID, CustomerID) VALUES
	(1, 1), (3, 2), (2, 3)


INSERT INTO Products (Name, Price) VALUES ('iPhone', 200)

INSERT INTO Customers (FirstName, LastName) VALUES ('Tina', 'Smith')

INSERT INTO Orders (ProductID, CustomerID) VALUES (4, 4)

SELECT * FROM Orders
WHERE CustomerID = (SELECT ID FROM Customers WHERE FirstName='Tina' AND LastName='Smith')

SELECT SUM(Price) FROM Products p
INNER JOIN Orders o ON p.ID = o.ProductID
WHERE p.Name = 'iPhone'

UPDATE Products
SET Price=250
WHERE Name='iPhone'