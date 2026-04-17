--181. Employees Earning More Than Their Managers
--Write a solution to find the employees who earn more than their managers.

--Return the result table in any order.

SELECT e.name as employee
FROM Employee e
JOIN Employee m ON e.managerId = m.id
WHERE e.salary > m.salary;