CREATE PROCEDURE [dbo].[IdeaForEvent_Updeate]
	@IdeaId BIGINT,
	@OccasionId BIGINT
AS
BEGIN
IF NOT EXISTS (
	SELECT 1
	FROM [IdeaOccasion]
	WHERE IdeaId = @IdeaId AND OccasionId = @OccasionId)

	BEGIN

		DELETE FROM [IdeaOccasion]
		WHERE IdeaId = @IdeaId

		INSERT INTO [IdeaOccasion]
			([IdeaId]
			,[OccasionId])
		VALUES
			(@IdeaId
			,@OccasionId)

	END
END