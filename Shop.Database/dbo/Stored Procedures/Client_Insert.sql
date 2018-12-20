-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.Client_Insert 
	-- Add the parameters for the stored procedure here
	@Name nvarchar(max),
	@Id int OUTPUT
AS
BEGIN

	INSERT INTO Client ([Name],IsDeleted)
	VALUES (@Name,0);

	SET @Id = SCOPE_IDENTITY();

END