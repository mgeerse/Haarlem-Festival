DELETE FROM Dining;

SET NOCOUNT ON;
GO
-- Declare the variable to be used.
DECLARE @i int;

-- Initialize the variable.
SET @i = 1;

-- Test the variable to see if the loop is finished.
WHILE (@i < 70)
BEGIN;
   -- Insert a row into the table.
   INSERT INTO Dining(Id, Cuisine_Id) VALUES
       (@i, 1)
   -- Increment the variable to count this iteration
   -- of the loop.
   SET @i = @i + 1;
END;
GO
SET NOCOUNT OFF;
GO