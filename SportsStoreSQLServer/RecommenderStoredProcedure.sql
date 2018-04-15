SET ANSI_NULLS ON
GO
SET ANSI_NULLS ON
GO
ALTER PROCEDURE ShowRecommendation (@ProductID int)
--WITH EXECUTE AS CALLER  
AS 
SELECT top(4) b.ProductID,
        count(*) AS Frequency
into tempRec
FROM
    CartLine a,
    CartLine b
WHERE
    a.OrderID = b.OrderID
    and a.productID = @ProductID
    and b.productid != @ProductID
GROUP BY
    b.ProductID
ORDER BY 2 desc;
SELECT p.*
FROM tempRec t, Products P
WHERE t.ProductID = P.ProductID;
DROP TABLE tempRec;
GO