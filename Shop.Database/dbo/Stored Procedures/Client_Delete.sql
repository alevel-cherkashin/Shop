
CREATE PROCEDURE [dbo].Client_Delete
	@Id int
AS
BEGIN
	UPDATE Client
	SET IsDeleted = 1
	WHERE Id=@Id
END