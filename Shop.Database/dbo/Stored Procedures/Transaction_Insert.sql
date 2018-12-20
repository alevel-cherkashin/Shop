
CREATE PROCEDURE [dbo].Transaction_Insert
	@Date datetime,
	@Amount float,
	@ClientId int,
	@IsDelete bit
AS
BEGIN
	INSERT INTO [Transaction] ([Date], Amount,ClientId,IsDeleted)
	VALUES(@Date,@Amount,@ClientId,0)
END