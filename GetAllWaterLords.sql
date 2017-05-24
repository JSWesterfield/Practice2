USE Waterbnb
GO

GO

GO

-- Create (or Re-create) the procedure
ALTER PROCEDURE GetAllWaterLords
AS
    SELECT id, Location, DateTime, NumOfGuests, Rating, ProfileId, Booked, FirstName, LastName, DateModified, DateCreated
    FROM WaterLordProfile

EXEC GetAllWaterLords
