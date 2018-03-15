CREATE PROCEDURE [dbo].[Occasion_Update]
	@Id BIGINT,
	@Name NVARCHAR(255),
	@Period TINYINT
AS
BEGIN

UPDATE [Occasion]
SET
	[Name] = @Name,
	[Period] = @Period
WHERE Id = @Id

END