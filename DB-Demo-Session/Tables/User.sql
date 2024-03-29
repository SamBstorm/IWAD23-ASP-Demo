﻿CREATE TABLE [dbo].[User]
(
	[User_Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	[Email] NVARCHAR(320) NOT NULL,
	[Password] VARBINARY(32) NOT NULL,
	[Salt] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	CONSTRAINT UK_Users_Email UNIQUE (Email),
	CONSTRAINT CK_Users_Email CHECK (Email LIKE '%_@_%._%')
)