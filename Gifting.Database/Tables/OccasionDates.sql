﻿CREATE TABLE [dbo].[OccasionDates]
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[OccasionId] BIGINT NOT NULL FOREIGN KEY REFERENCES [Occasion](Id),
	[Date] date NOT NULL
)