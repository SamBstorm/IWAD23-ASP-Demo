CREATE VIEW [dbo].[V_Users_with_Profile]
	AS 
		SELECT	[User].[User_Id],
				[User].[Email],
				'********' AS [Password],
				[UserProfile].[User_Profile_Id],
				[UserProfile].[First_name],
				[UserProfile].[Last_name],
				[UserProfile].[Birth_date]
			FROM [User]
				JOIN [UserProfile] ON [User].[User_Id] = [UserProfile].[User_Id]
