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