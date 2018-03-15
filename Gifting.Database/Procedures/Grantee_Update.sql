CREATE PROCEDURE [dbo].[Grantee_Update]
	@Id BIGINT,
	@Name NVARCHAR(255)
AS
BEGIN

UPDATE [Grantee]
SET
	[Name] = @Name
WHERE Id = @Id

END