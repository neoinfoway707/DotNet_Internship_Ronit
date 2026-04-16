--183. Customers Who Never Order
--Write a solution to find all customers who never order anything.

--Return the result table in any order.

select name as Customers from Customers c
left join Orders o on c.id = o.customerId
where o.customerId is null