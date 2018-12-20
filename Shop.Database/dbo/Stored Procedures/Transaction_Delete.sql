
CREATE PROCEDURE [dbo].Transaction_Delete
	@Id int
AS
BEGIN
	UPDATE [Transaction]
	SET IsDeleted =1
	WHERE Id = @Id
END