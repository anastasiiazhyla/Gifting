CREATE PROCEDURE [dbo].[Grantee_GetByUserId]
	@UserId BIGINT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		[Id],
		[Name],
		[UserId]
	FROM
		[Grantee]
	WHERE
		(@UserId IS NOT NULL AND [UserId] = @UserId) OR (@UserId IS NULL AND [UserId] IS NULL)
END
