﻿CREATE TABLE [dbo].[Grantee]
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(255) NOT NULL,
	[UserId] BIGINT NULL FOREIGN KEY REFERENCES [User](Id)
)
