IF (SELECT COUNT(*) FROM [Grantee]) = 0
BEGIN
	INSERT INTO [Grantee] ([Name]) VALUES ('Mother')
	INSERT INTO [Grantee] ([Name]) VALUES ('Father')
	INSERT INTO [Grantee] ([Name]) VALUES ('Grandmother')
	INSERT INTO [Grantee] ([Name]) VALUES ('Grandfather')
	INSERT INTO [Grantee] ([Name]) VALUES ('Son')
	INSERT INTO [Grantee] ([Name]) VALUES ('Daughter')
	INSERT INTO [Grantee] ([Name]) VALUES ('Wife')
	INSERT INTO [Grantee] ([Name]) VALUES ('Husband')
	INSERT INTO [Grantee] ([Name]) VALUES ('Parents')
	INSERT INTO [Grantee] ([Name]) VALUES ('Grandparents')
	INSERT INTO [Grantee] ([Name]) VALUES ('Me')
END

IF (SELECT COUNT(*) FROM [Occasion]) = 0
BEGIN
	INSERT INTO [Occasion] ([Name], [Period]) VALUES ('Birthday', 1)
	INSERT INTO [Occasion] ([Name], [Period]) VALUES ('New Year', 1)
	INSERT INTO [Occasion] ([Name], [Period]) VALUES ('Christmas', 1)
	INSERT INTO [Occasion] ([Name], [Period]) VALUES ('Father''s Day', 2)           -- 3rd Sunday in June
	INSERT INTO [Occasion] ([Name], [Period]) VALUES ('Mother''s Day', 2)           -- 2nd Sunday in May 
	INSERT INTO [Occasion] ([Name], [Period]) VALUES ('Valentine''s Day', 1)
END