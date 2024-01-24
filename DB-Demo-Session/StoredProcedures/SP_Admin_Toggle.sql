CREATE PROCEDURE [dbo].[SP_Admin_Toggle]
	@id UNIQUEIDENTIFIER
AS
	IF(EXISTS(SELECT [Admin_Id] FROM [AdminUser] WHERE [Admin_Id] = @id))
	BEGIN
		DELETE FROM [AdminUser] WHERE [Admin_Id] = @id
	END
	ELSE
	BEGIN
		INSERT INTO [AdminUser] VALUES (@id)
	END
RETURN 0
