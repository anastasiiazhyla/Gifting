CREATE PROCEDURE [dbo].[Grantee_Create]
	@Id BIGINT OUTPUT,
	@Name NVARCHAR(255),
	@UserId BIGINT
AS
BEGIN

INSERT INTO [Grantee]
	([Name]
	,[UserId])
VALUES
	(@Name
	,@UserId)

SELECT @Id = @@IDENTITY

END