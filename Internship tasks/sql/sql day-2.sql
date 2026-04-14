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