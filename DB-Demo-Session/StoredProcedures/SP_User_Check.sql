CREATE PROCEDURE [dbo].[SP_User_Check]
	@email NVARCHAR(320),
	@password NVARCHAR(32)
AS
	SELECT * FROM [User] WHERE [Email] = @email AND [Password] = dbo.SF_HashSaltPassword(@password, [Salt]);
RETURN 0
