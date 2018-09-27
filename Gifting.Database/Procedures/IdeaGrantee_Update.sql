CREATE PROCEDURE [dbo].[IdeaGrantee_Updeate]
	@IdeaId BIGINT,
	@GranteeId BIGINT
AS
BEGIN
IF NOT EXISTS (
	SELECT 1
	FROM [IdeaGrantee]
	WHERE IdeaId = @IdeaId AND GranteeId = @GranteeId)

	BEGIN

		DELETE FROM [IdeaGrantee]
		WHERE IdeaId = @IdeaId

		INSERT INTO [IdeaGrantee]
			([IdeaId]
			,[GranteeId])
		VALUES
			(@IdeaId
			,@GranteeId)

	END
END