--177. Nth Highest Salary
--Query:Write a solution to find the nth highest distinct salary from the Employee table. If there are less than n distinct salaries, return null.

CREATE FUNCTION getNthHighestSalary(@N INT)
RETURNS INT
AS
BEGIN
    RETURN (
        SELECT MAX(salary)
        FROM (
            SELECT salary,
                   DENSE_RANK() OVER (ORDER BY salary DESC) AS rnk
            FROM Employee
        ) t
        WHERE rnk = @N
    );
END