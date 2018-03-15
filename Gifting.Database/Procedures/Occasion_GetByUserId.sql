CREATE PROCEDURE [dbo].[Occasion_GetByUserId]
	@UserId BIGINT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		[Id],
		[Name],
		[UserId],
		[Period]
	FROM
		[Occasion]
	WHERE
		(@UserId IS NOT NULL AND [UserId] = @UserId) OR (@UserId IS NULL AND [UserId] IS NULL)
END
