--197. Rising Temperature
--Write a solution to find all dates' id with higher temperatures compared to its previous dates (yesterday).

--Return the result table in any order.

SELECT w1.id
FROM Weather w1
JOIN Weather w2
    ON w1.recordDate = DATEADD(DAY, 1, w2.recordDate)
WHERE w1.temperature > w2.temperature;