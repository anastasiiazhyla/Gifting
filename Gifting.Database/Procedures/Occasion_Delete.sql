CREATE PROCEDURE [dbo].[Occasion_Delete]
	@Id BIGINT
AS
BEGIN

DELETE
FROM [Occasion]
WHERE Id = @Id

END