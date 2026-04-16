--196. Delete Duplicate Emails
--Write a solution to delete all duplicate emails, keeping only one unique email with the smallest id.

--For SQL users, please note that you are supposed to write a DELETE statement and not a SELECT one.

--After running your script, the answer shown is the Person table. The driver will first compile and run your piece of code and then show the Person table. The final order of the Person table does not matter.

delete p1 from Person p1
join Person p2 
    on p1.email = p2.email and
    p1.id > p2.id