CREATE PROCEDURE [dbo].[User_Update]
	@Id BIGINT OUTPUT,
	@Email NVARCHAR(255),
	@FirstName NVARCHAR(255),
	@LastName NVARCHAR(255)
AS
BEGIN

UPDATE [User]
SET
	[Email] = @Email,
	[FirstName] = @FirstName,
	[LastName] = @LastName
WHERE Id = @Id

END
