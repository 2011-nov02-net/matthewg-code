DROP SCHEMA IF EXISTS Exercises;
GO
CREATE SCHEMA Exercises;
GO

DROP TABLE IF EXISTS Exercises.Department;
CREATE TABLE Exercises.Department (
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(99),
	Location NVARCHAR(99),
)

DROP TABLE IF EXISTS Exercises.Employee;
CREATE TABLE Exercises.Employee (
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(99),
	LastName NVARCHAR(99),
	SSN VARCHAR(99) UNIQUE,
	DeptId INT FOREIGN KEY REFERENCES Exercises.Department (Id)
)

DROP TABLE IF EXISTS Exercises.EmployeeDetails;
CREATE TABLE Exercises.EmployeeDetails (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT UNIQUE FOREIGN KEY REFERENCES Exercises.Employee (Id),
	Salary INT CHECK (Salary > 0),
	Address1 NVARCHAR(99),
	Address2 NVARCHAR(99),
	City NVARCHAR(99),
	State NVARCHAR(99),
	Country NVARCHAR(99)
)

INSERT INTO Exercises.Department (Name, Location) VALUES
	('IT', 'RM-201'), ('Sales', 'RM-112'), ('Human Resources', 'RM-102')

INSERT INTO Exercises.Employee (FirstName, LastName, SSN, DeptId) VALUES
	('Matt', 'Goodman', '123-45-6789', (SELECT Id FROM Exercises.Department WHERE Name='IT')),
	('John', 'Smith', '987-65-4321', (SELECT Id FROM Exercises.Department WHERE Name='Sales')),
	('Robert', 'Paulson', '555-55-5555', (SELECT Id FROM Exercises.Department WHERE Name='Human Resources'))

INSERT INTO Exercises.EmployeeDetails (EmployeeId, Salary, Address1, Address2, City, State, Country) VALUES
	((SELECT Id FROM Exercises.Employee WHERE SSN='123-45-6789'), 45000, '200 N. Cherry St', NULL, 'Winston-Salem', 'NC', 'USA'),
	((SELECT Id FROM Exercises.Employee WHERE SSN='987-65-4321'), 35000, NULL, NULL, 'Atlanta', 'GA', 'USA'),
	((SELECT Id FROM Exercises.Employee WHERE SSN='555-55-5555'), 25000, NULL, NULL, NULL, NULL, NULL)

INSERT INTO Exercises.Employee (FirstName, LastName) VALUES ('Tina', 'Smith')
INSERT INTO Exercises.EmployeeDetails (EmployeeId) VALUES ((SELECT Id FROM Exercises.Employee WHERE FirstName='Tina' AND LastName='Smith'))
INSERT INTO Exercises.Department (Name) VALUES ('Marketing')
SELECT * FROM Exercises.Employee WHERE DeptId = (SELECT Id FROM Exercises.Department WHERE Name='Marketing')
SELECT SUM(Salary) AS "Total Salary" FROM Exercises.EmployeeDetails WHERE EmployeeId IN (SELECT Id FROM Exercises.Employee WHERE DeptId = (SELECT Id FROM Exercises.Department WHERE Name='Marketing'))
SELECT DeptId, COUNT(*) AS "# Employees" FROM Exercises.Employee GROUP BY DeptId
UPDATE Exercises.EmployeeDetails SET Salary=90000 WHERE EmployeeId=(SELECT Id FROM Exercises.Employee WHERE FirstName='Tina' AND LastName='Smith')

SELECT * FROM Exercises.EmployeeDetails ed, Exercises.Employee e
WHERE e.Id=ed.EmployeeId
