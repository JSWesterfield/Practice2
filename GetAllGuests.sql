USE [Waterbnb]
GO


GO

GO

-- Create (or Re-create) the procedure
PROCEDURE GetAllGuests
AS
    SELECT id, UserId, Location, DateCreated, TripDurationDays, DateModified, FirstName, LastName, NumOfGuests
    FROM WaterbnbGuests

	EXEC GetAllGuests
