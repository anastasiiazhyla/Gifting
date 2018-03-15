CREATE PROCEDURE [dbo].[Idea_GetById]
	@Id BIGINT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		[Id],
		[Name],
		[Description],
		[DateCreated],
		[Tags],
		[ImageUrl],
		[UserId],
		[IsApproved]
	FROM
		[Idea]
	WHERE
		[Id] = @Id
END
