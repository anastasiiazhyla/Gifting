CREATE PROCEDURE [dbo].[Idea_GetAll]
	@PageNumber INT,
	@PageSize INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		i.[Id],
		i.[Name],
		i.[Description],
		i.[DateCreated],
		i.[Tags],
		i.[ImageUrl],
		i.[UserId],
		i.[IsApproved],
		i.[WhereToBuy],
		io.[OccasionId],
		ig.[GranteeId]
	FROM
		[Idea] i
		LEFT JOIN [IdeaOccasion] io on i.Id = io.IdeaId
		LEFT JOIN [IdeaGrantee] ig on ig.IdeaId = i.Id
	ORDER BY [DateCreated] DESC
	OFFSET @PageSize * (@PageNumber - 1) ROWS
	FETCH NEXT @PageSize ROWS ONLY
END
