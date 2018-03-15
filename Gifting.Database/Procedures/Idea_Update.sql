CREATE PROCEDURE [dbo].[Idea_Update]
	@Id BIGINT,
	@Name NVARCHAR(255),
	@Description NVARCHAR(MAX),
	@Tags NVARCHAR(MAX),
	@ImageUrl NVARCHAR(MAX)
AS
BEGIN

UPDATE [Idea]
SET
	[Name] = @Name,
	[Description] = @Description,
	[Tags] = @Tags,
	[ImageUrl] = @ImageUrl
WHERE Id = @Id

END