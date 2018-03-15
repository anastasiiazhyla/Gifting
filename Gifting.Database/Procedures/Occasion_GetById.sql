CREATE PROCEDURE [dbo].[Occasion_GetById]
	@Id BIGINT
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
		[Id] = @Id
END
