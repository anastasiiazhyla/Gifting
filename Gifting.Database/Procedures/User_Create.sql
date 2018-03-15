CREATE PROCEDURE [dbo].[User_Create]
	@Id BIGINT OUTPUT,
	@Email NVARCHAR(255),
	@Username NVARCHAR(255),
	@FirstName NVARCHAR(255),
	@LastName NVARCHAR(255),
	@PasswordHash NVARCHAR(MAX)
AS
BEGIN

INSERT INTO [User]
	([Email]
	,[Username]
	,[FirstName]
	,[LastName]
	,[PasswordHash])
VALUES
	(@Email
	,@Username
	,@FirstName
	,@LastName
	,@PasswordHash)

SELECT @Id = @@IDENTITY

END
