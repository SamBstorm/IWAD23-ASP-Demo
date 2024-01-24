﻿CREATE TABLE [dbo].[AdminUser]
(
	[Admin_Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	CONSTRAINT FK_AdminUser_User FOREIGN KEY ([Admin_Id]) REFERENCES [User]([User_Id])
)
