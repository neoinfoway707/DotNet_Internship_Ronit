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

--Exists:Give me rows where at least one matching row exists in the subquery
--Any:Give me rows where the condition is true for at least one value in the subquery
--All:Give me rows where the condition is true for every value in the subquery
--🔹 INNER JOIN
--“Give me only the rows where both tables have matching data”
--🔹 LEFT JOIN
--“Give me all rows from the left table and matching rows from the right table”
--🔹 RIGHT JOIN
--“Give me all rows from the right table and matching rows from the left table”
--🔹 FULL JOIN
--“Give me all rows from both tables, matching where possible and filling NULL where not”
--🔹 CROSS JOIN
--“Give me all possible combinations of rows from both tables”
--🔹 SELF JOIN
--“Join a table with itself to relate its own rows”
--🔹 NATURAL JOIN (less used)
--“Automatically join tables based on columns with the same name”
	
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
