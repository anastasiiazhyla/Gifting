﻿CREATE TABLE [dbo].[Event]
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[OccasionId] BIGINT NOT NULL FOREIGN KEY REFERENCES Occasion(Id),
	[GranteeId] BIGINT NOT NULL FOREIGN KEY REFERENCES Grantee(Id)
)