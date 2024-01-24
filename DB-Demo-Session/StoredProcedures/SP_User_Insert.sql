CREATE PROCEDURE [dbo].[SP_User_Insert]
	@email NVARCHAR(320),
	@password NVARCHAR(32)
AS
	DECLARE @salt UNIQUEIDENTIFIER
	SET @salt = NEWID()
	INSERT INTO [User] ([Email],[Password],[Salt])
	OUTPUT [inserted].[User_Id]
	VALUES (@email, dbo.SF_HashSaltPassword(@password,@salt), @salt)
RETURN
