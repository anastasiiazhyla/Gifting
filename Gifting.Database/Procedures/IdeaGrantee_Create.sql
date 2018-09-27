CREATE PROCEDURE [dbo].[IdeaGrantee_Create]
	@IdeaId BIGINT,
	@GranteeId BIGINT
AS
BEGIN

INSERT INTO [IdeaGrantee]
	([IdeaId]
	,[GranteeId])
VALUES
	(@IdeaId
	,@GranteeId)

END