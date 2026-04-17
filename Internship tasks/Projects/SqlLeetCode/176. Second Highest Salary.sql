--176. Second Highest Salary
--Query:Write a solution to find the second highest distinct salary from the Employee table. If there is no second highest salary, return null (return None in Pandas).

SELECT MAX(salary) AS SecondHighestSalary
FROM Employee
WHERE salary < (SELECT MAX(salary) FROM Employee);


------------------------------------------------------------------------------------
-- Create Employee table if not exists
IF NOT EXISTS (
    SELECT * 
    FROM sys.objects 
    WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') 
    AND type = 'U'
)
BEGIN
    CREATE TABLE Employee (
        id INT,
        salary INT
    );
END

-- Clear table
TRUNCATE TABLE Employee;

-- Insert data
INSERT INTO Employee (id, salary)
VALUES 
(1, 100),
(2, 200),
(3, 300);

select * from Employee

