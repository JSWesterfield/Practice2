USE [Waterbnb]
GO
/****** Object:  StoredProcedure [dbo].[Guest_Insert]    Script Date: 5/24/2017 3:13:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER proc [dbo].[Guest_Insert]

/*

Execute dbo.Guest_Insert

*/

as

BEGIN 

	Declare @Id int = 0;

	/* declare names values to our variables*/ /* @UserId could easily be named @UserName or @NameId, it all is insert into UserId in our SQL table dbo.WaterbnbGuests */
	Declare @UserId nvarchar(100) = 'asqwedaqweqdsc200asds'
		, @Location nvarchar(100) = 'Hong Kong'
		, @TripDurationDays int = 14
		, @FirstName nvarchar(100) = 'Mike'
		, @LastName nvarchar(100) = 'Chang'
		, @NumOfGuests int = 4

	
	INSERT INTO [dbo].[WaterbnbGuests]
           ([UserId]
           ,[Location]
           ,[TripDurationDays]
           ,[FirstName]
           ,[LastName]
           ,[NumOfGuests])
     VALUES
           (@UserId
           ,@Location
           ,@TripDurationDays
           ,@FirstName
           ,@LastName
           ,@NumOfGuests)

	SET @Id = SCOPE_IDENTITY()


	/* Select statement used to visually inspect what we inserted */
	Select *
	From dbo.WaterbnbGuests
	Where Id = @Id

END