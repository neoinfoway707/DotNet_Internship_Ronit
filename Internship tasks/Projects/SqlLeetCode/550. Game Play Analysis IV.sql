--550. Game Play Analysis IV
--Write a solution to report the fraction of players that logged in again on the day after the day they first logged in, rounded to 2 decimal places. In other words, you need to determine the number of players who logged in on the day immediately following their initial login, and divide it by the number of total players.
WITH FirstLogin AS (
    SELECT 
        player_id,
        MIN(event_date) AS first_login
    FROM Activity
    GROUP BY player_id
),
NextDayPlayers AS (
    SELECT DISTINCT f.player_id
    FROM FirstLogin f
    JOIN Activity a
        ON a.player_id = f.player_id
       AND a.event_date = DATEADD(DAY, 1, f.first_login)
)
SELECT 
    ROUND(
        CAST((SELECT COUNT(*) FROM NextDayPlayers) AS FLOAT)
        / (SELECT COUNT(*) FROM FirstLogin),
    2) AS fraction;