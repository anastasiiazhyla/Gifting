CREATE PROCEDURE [dbo].[Idea_GetById]
	@Id BIGINT
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
	WHERE
		i.[Id] = @Id
END
