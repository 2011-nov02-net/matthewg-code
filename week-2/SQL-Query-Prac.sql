------------------------------------------intro----------------------------------------------------------

SELECT (c.FirstName + ' ' + c.LastName) AS "Full Name", c.CustomerId, c.Country FROM Customer c
WHERE c.Country != 'USA'

SELECT * FROM Customer c
WHERE c.Country = 'Brazil'

SELECT * FROM Employee e
WHERE e.Title = 'Sales Support Agent'

SELECT i.BillingCountry FROM Invoice i
GROUP BY i.BillingCountry

SELECT COUNT(*) AS "# Invoices", SUM(i.Total) AS "Sales Total" FROM Invoice i
WHERE i.InvoiceDate >= '2009-01-01' AND i.InvoiceDate < '2010-01-01'

SELECT COUNT(*) FROM InvoiceLine l
WHERE l.InvoiceId = 37

SELECT i.BillingCountry, COUNT(*) AS "# Invoices" FROM Invoice i
GROUP BY i.BillingCountry

SELECT i.BillingCountry, SUM(i.Total) AS "Sales Total", COUNT(*) AS "# Invoices" FROM Invoice i
GROUP BY i.BillingCountry
ORDER BY "Sales Total" DESC, i.BillingCountry

---------------------------------------------------JOINS------------------------------------------------------------------------------

SELECT i.* FROM Invoice i
INNER JOIN Customer c ON c.CustomerId=i.CustomerId
WHERE c.Country='Brazil'

SELECT i.*, (e.FirstName + ' ' + e.LastName) AS "Sales Agent" FROM Invoice i
INNER JOIN Customer c ON c.CustomerId=i.CustomerId
LEFT JOIN Employee e ON c.SupportRepId=e.EmployeeId

SELECT p.PlaylistId, p.Name, COUNT(*) AS "# Tracks" FROM PlaylistTrack pt
LEFT JOIN Playlist p ON pt.PlaylistId=p.PlaylistId
GROUP BY p.Name, p.PlaylistId
ORDER BY "# Tracks" DESC, p.Name

SELECT TOP(1) (e.FirstName + ' ' + e.LastName) as "Sales Agent", SUM(i.Total) AS "Sales in $" FROM Employee e
INNER JOIN Customer c ON e.EmployeeId=c.SupportRepId
INNER JOIN Invoice i ON c.CustomerId=i.CustomerId
WHERE i.InvoiceDate >= '2009-01-01' AND i.InvoiceDate < '2010-01-01'
GROUP BY e.EmployeeId, e.FirstName, e.LastName
ORDER BY "Sales in $" DESC

SELECT (e.FirstName + ' ' + e.LastName) as "Sales Agent", COUNT(*) AS "# Customers" FROM Employee e
INNER JOIN Customer c ON e.EmployeeId=c.SupportRepId
GROUP BY e.EmployeeId, e.FirstName, e.LastName
ORDER BY "# Customers" DESC, "Sales Agent"

SELECT TOP(1) t.TrackId, t.Name, COUNT(*) AS "# Purchases" FROM Track t
LEFT JOIN InvoiceLine l ON t.TrackId=l.TrackId
INNER JOIN Invoice i ON l.InvoiceId=i.InvoiceId
WHERE i.InvoiceDate >= '2010-01-01'
GROUP BY t.TrackId, t.Name
ORDER BY "# Purchases" DESC

SELECT TOP(3) r.Name, COUNT(*) AS "# Sales" FROM Artist r
INNER JOIN Album a ON a.ArtistId=r.ArtistId
INNER JOIN Track t ON a.AlbumId = t.AlbumId
INNER JOIN InvoiceLine l ON l.TrackId=t.TrackId
INNER JOIN Invoice i ON i.InvoiceId=l.InvoiceId
GROUP BY r.Name
ORDER BY "# Sales" DESC, r.Name

SELECT (c.FirstName + ' ' + c.LastName) AS "Customer Name" FROM Customer c
CROSS JOIN Customer c2
WHERE c.CustomerId != c2.CustomerId AND SUBSTRING(c.FirstName, 1, 1) = SUBSTRING(c2.FirstName, 1, 1) AND SUBSTRING(c.LastName, 1, 1) = SUBSTRING(c2.LastName, 1, 1)


------------------------------------------------Set-ops--------------------------------------------------------------------------



------------------------------------------------Subquery------------------------------------------------------------------------------

WITH artists_with_albums AS (
	SELECT a.ArtistId FROM Album a
)
SELECT * FROM Artist r
WHERE r.ArtistId NOT IN (
	SELECT * FROM artists_with_albums
)

SELECT * FROM Artist r
WHERE r.ArtistId NOT IN (
	SELECT a.ArtistId FROM Album a
	WHERE a.AlbumId IN (
		SELECT t.AlbumId FROM Track t
		WHERE t.GenreId IN (
			SELECT GenreId FROM Genre g
			WHERE g.Name='Latin'
		)
	)
)

SELECT TOP(1) t.Name, t.Milliseconds FROM Track t
WHERE t.MediaTypeId IN (
	SELECT m.MediaTypeId FROM MediaType m
	WHERE m.Name LIKE '%video%'
)
ORDER BY t.Milliseconds DESC

SELECT (c.FirstName + ' ' + c.LastName) AS "Customer Name" FROM Customer c
WHERE c.City IN (
	SELECT e.City FROM Employee e
	where e.ReportsTo IS NULL
)


SELECT COUNT(*) AS "# Tracks", SUM(l.UnitPrice) AS "Total Price" FROM InvoiceLine l
WHERE l.InvoiceId IN (
	SELECT i.InvoiceId FROM Invoice i
	WHERE i.CustomerId IN (
		SELECT c.CustomerId FROM Customer c
		WHERE c.Country = 'Germany'
	)
) AND l.TrackId IN (
	SELECT t.TrackId FROM Track t
	WHERE t.MediaTypeId IN (
		SELECT m.MediaTypeId FROM MediaType m
		WHERE m.Name LIKE '%audio%'
	)
)



SELECT (c.FirstName + ' ' + c.LastName) AS "Customer Name", c.Country FROM Customer c
WHERE c.SupportRepId IN (
	SELECT e.EmployeeId FROM Employee e
	WHERE e.BirthDate - e.HireDate < 35
)


--------------------------------------------Table-Modification----------------------------------------------------------------------

SELECT * FROM Employee

INSERT INTO Employee VALUES
(9, 'Goodman', 'Matt', 'Associate', NULL, NULL, NULL, 'Some address', 'Winston-Salem', 'NC', 'USA', NULL, NULL, NULL, NULL)

DELETE FROM Employee
WHERE EmployeeId=9

SELECT * FROM Customer c
WHERE c.CustomerId=32

UPDATE Customer
SET FirstName = 'Robert', LastName = 'Walter'
WHERE CustomerId=32
