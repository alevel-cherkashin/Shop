
CREATE PROCEDURE [dbo].Transaction_Update
	@Id int,
	@Date datetime,
	@Amount float
AS
BEGIN
	UPDATE [Transaction] SET [Date]= @Date, Amount= @Amount
	WHERE Id=@Id
END