CREATE PROCEDURE [dbo].[Idea_GetAll]
	@PageNumber INT,
	@PageSize INT
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
	ORDER BY [DateCreated] DESC
	OFFSET @PageSize * (@PageNumber - 1) ROWS
	FETCH NEXT @PageSize ROWS ONLY
END
