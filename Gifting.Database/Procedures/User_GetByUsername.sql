CREATE PROCEDURE [dbo].[User_GetByUsername]
	@Username NVARCHAR(255)
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
		[Username] = @Username
END
