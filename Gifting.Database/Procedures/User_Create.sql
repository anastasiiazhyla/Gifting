CREATE PROCEDURE [dbo].[User_Create]
	@Id bigint OUTPUT,
	@Email nvarchar(255),
	@Username nvarchar(255),
	@FirstName nvarchar(255),
	@LastName nvarchar(255),
	@PasswordHash nvarchar(MAX)
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
