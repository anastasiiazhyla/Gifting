CREATE PROCEDURE [dbo].[User_GetById]
	@Id BIGINT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		[Id],
		[FirstName],
		[LastName],
		[Username],
		[Email],
		[PasswordHash]
	FROM
		[User]
	WHERE
		[Id] = @Id
END
