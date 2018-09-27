CREATE PROCEDURE [dbo].[IdeaOccasion_Create]
	@IdeaId BIGINT,
	@OccasionId BIGINT
AS
BEGIN

INSERT INTO [IdeaOccasion]
	([IdeaId]
	,[OccasionId])
VALUES
	(@IdeaId
	,@OccasionId)

END