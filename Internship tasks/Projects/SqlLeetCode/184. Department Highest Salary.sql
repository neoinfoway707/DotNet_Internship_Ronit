--184. Department Highest Salary
--Write a solution to find employees who have the highest salary in each of the departments.

--Return the result table in any order.

select d.name as Department,e.name as Employee,e.salary as Salary from Employee e
inner join Department d on d.id = e.departmentId
where e.salary = (
    select max(e2.salary) from employee e2
    where e2.departmentId = e.departmentId
)