--175. Combine Two Tables
--Query:Write a solution to report the first name, last name, city, and state of each person in the Person table. If the address of a personId is not present in the Address table, report null instead.Return the result table in any order.

SELECT p.firstName,p.lastName,a.city,a.state
FROM Person p
LEFT JOIN Address a
ON p.personId = a.personId;

------------------------------------------------------------------------------------

Create database LeetCodeDB_Ronit
use LeetCodeDB_Ronit

-- Create Person table if not exists
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Person]') AND type = 'U')
BEGIN
    CREATE TABLE Person (
        personId INT,
        firstName VARCHAR(255),
        lastName VARCHAR(255)
    );
END

-- Create Address table if not exists
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Address]') AND type = 'U')
BEGIN
    CREATE TABLE Address (
        addressId INT,
        personId INT,
        city VARCHAR(255),
        state VARCHAR(255)
    );
END

-- Clear tables
TRUNCATE TABLE Person;
TRUNCATE TABLE Address;

-- Insert data into Person
INSERT INTO Person (personId, lastName, firstName)
VALUES 
(1, 'Wang', 'Allen'),
(2, 'Alice', 'Bob');

-- Insert data into Address
INSERT INTO Address (addressId, personId, city, state)
VALUES 
(1, 2, 'New York City', 'New York'),
(2, 3, 'Leetcode', 'California');

select * from Person
select * from Address

