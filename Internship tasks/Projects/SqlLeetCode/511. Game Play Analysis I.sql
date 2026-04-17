--511. Game Play Analysis I
--Write a solution to find the first login date for each player.

--Return the result table in any order.
SELECT 
    player_id,
    MIN(event_date) AS first_login
FROM Activity
GROUP BY player_id;