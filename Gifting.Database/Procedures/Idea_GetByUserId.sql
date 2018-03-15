CREATE PROCEDURE [dbo].[Idea_GetByUserId]
	@UserId BIGINT
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
		[UserId] = @UserId
END
