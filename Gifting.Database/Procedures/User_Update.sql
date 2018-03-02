CREATE PROCEDURE [dbo].[User_Update]
	@Id bigint OUTPUT,
	@Email nvarchar(255),
	@FirstName nvarchar(255),
	@LastName nvarchar(255)
AS
BEGIN

UPDATE [User]
SET
	[Email] = @Email,
	[FirstName] = @FirstName,
	[LastName] = @LastName
WHERE Id = @Id

END
