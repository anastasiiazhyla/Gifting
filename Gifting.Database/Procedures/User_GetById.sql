CREATE PROCEDURE [dbo].[User_GetById]
	@Id bigint
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
