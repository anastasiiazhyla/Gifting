CREATE PROCEDURE [dbo].[Grantee_GetById]
	@Id BIGINT
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
		[Id] = @Id
END
