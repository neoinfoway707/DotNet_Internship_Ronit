create database customer

--#3082 D1
use customer

drop customer

create table Person
(
	PersonID int,
	FirstName varchar(200),
	LastName varchar(200),
	Address varchar(300),
	City varchar(50)
)

select * from Person
delete from Person
insert into Person Values
(1, 'Hansen', 'Ola', 'Timoteivn 10', 'Sandnes'),
(2, 'Svendson', 'Tove', 'Borgvn 23', 'Sandnes'),
(3, 'Pettersen', 'Kari', 'Storgt 20', 'Stavanger');

alter table Person
add Birthdate date

insert into Person Values
(4,'demo','mode','str 12','citty2','2004-08-21')

create table student(
studentID INT PRIMARY KEY,              
FullName VARCHAR(100) NOT NULL,    
Email VARCHAR(255) UNIQUE,              
City VARCHAR(100)
);

select * from student;

INSERT INTO student (studentID,FullName,Email,City)
VALUES
(1, 'Viraj', 'V@example.com', 'JND'),
(2, 'Mayank', 'M@example.com', 'RJK'),
(3, 'Rajan', 'R@example.com', 'Gandhinagar'),
(4, 'Krishiv', 'K@example.com', 'Baroda'),
(5, 'Arjun', 'A@example.com', 'Ahmedabad');

create table orders
(
	OrderID int primary key,
	OrderNumber int not null,
	studentID int,
	foreign key (studentID) references student(studentID),

)
select * from orders
INSERT INTO Orders (OrderID, OrderNumber, studentID)
VALUES
(101, 5001, 1),
(102, 5002, 2),
(103, 5003, 3);

select * from orders
select * from student

select distinct City from Student

select * from student
where City = 'Gandhinagar'

select * from student
order by FullName ASC

select * from student
order by FullName DESC

select * from student
where City = 'JND' and FullName = 'Viraj'

select distinct City
from student
where (City = 'RJK' or City = 'JND')
and not FullName = 'Arjun'
order by City ASC

--#3083 D2
Select top 3 * from student

SELECT MIN(OrderNumber) AS SmallestOrder,
       MAX(OrderNumber) AS LargestOrder
FROM Orders;

SELECT COUNT(*) AS TotalPeople FROM student;

SELECT SUM(OrderNumber) AS TotalOrderValue FROM Orders;

SELECT AVG(OrderNumber) AS AverageOrderValue FROM Orders;

SELECT * FROM student WHERE FullName LIKE 'K%';

SELECT * FROM student WHERE FullName LIKE '_rjun';

SELECT * FROM student
WHERE City IN ('RJK', 'JND');

SELECT * FROM Orders
WHERE OrderNumber BETWEEN 5001 AND 5003;

select top 5 
	s.City,
	count(s.StudentID) as total,
	min(o.OrderNumber) as min_order,
	max(o.OrderNumber) as max_order,
	avg(o.OrderNumber) as avg_order
from student s
left join Orders o on s.studentID = o.studentID
where s.City in ('JND','Gandhinagar')
group by s.City
having count(s.studentID) > 0
order by avg_order DESC

--#3084 D3
create table departments
(
	ID int primary key,
	DepartmentName varchar(50)
)


INSERT INTO departments VALUES
(1, 'HR'),
(2, 'IT'),
(3, 'Finance'),
(4, 'Marketing');


CREATE TABLE employees (
    EmployeeID INT PRIMARY KEY,
    name VARCHAR(50),
    salary DECIMAL(10,2),
    DepartmentID INT,
    ManagerID INT,
    FOREIGN KEY (DepartmentID) REFERENCES departments(ID)
);

INSERT INTO employees VALUES
(1, 'Aryan', 50000, 1, 3),
(2, 'Keval', 55000, 1, 3),
(3, 'Vedant', 80000, 2, NULL), 
(4, 'Sahil', 60000, 2, 3),
(5, 'Darshit', 45000, 3, 6),
(6, 'Harsh', 90000, 3, NULL), 
(7, 'Jay', 40000, NULL, NULL); 

select * from departments
select * from employees

select e.name,d.DepartmentName from employees e
left join departments d
on d.ID = e.DepartmentID
--(leftjoin) give me all rows from employess and matching rows from departments

select e.name,d.DepartmentName from employees e
right join departments d
on e.DepartmentID = d.ID
--(rightjoin) give me all rows from employess and matching rows from departments

select e.name,d.DepartmentName from employees e
full join departments d
on e.DepartmentID = d.ID
--(fulljoin) give me all rows from employees and departments, match where possible

select A.name as employee,B.name as manager from employees A
join employees B
on A.ManagerID = B.EmployeeID

select DepartmentID,count(*) as total_employee from employees
group by DepartmentID

select DepartmentID,count(*) as total_employee from employees
group by DepartmentID
having count(*) > 1

select DepartmentName from departments d
where exists
(
	select 1 from employees e
	where e.DepartmentID = d.ID
)
--(exists)Give me all departments where at least one employee exists in that department
select name,salary from employees
where salary > ANY (
	select salary from employees where DepartmentID = 3
)
--(any)Give me employees whose salary is greater than at least one employee in department 3
SELECT name, salary FROM employees
WHERE salary > ALL (
    SELECT salary FROM employees WHERE DepartmentID = 2
);
--(all)Give me employees whose salary is greater than every employee in department 2
--union,unionall

create table Employees_US
(
 name varchar(10),
 salary varchar(10)
)
create table Employees_India
(
 name varchar(10),
 salary varchar(10)
)
insert into Employees_US
values('a','1000'),('b','2000')
insert into Employees_India
values('b','2000'),('c','3000')

select * from Employees_India
select * from Employees_US

select Name, Salary from Employees_US
union
select Name, Salary from Employees_India
--(union)Give me all unique employees from both tables

select Name, Salary from Employees_US
union all
select Name, Salary from Employees_India
--(union all)Give me all employees from both tables, including duplicates

