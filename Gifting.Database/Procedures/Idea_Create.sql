CREATE PROCEDURE [dbo].[Idea_Create]
	@Id BIGINT OUTPUT,
	@Name NVARCHAR(255),
	@Description NVARCHAR(MAX),
	@DateCreated DATETIME,
	@Tags NVARCHAR(MAX),
	@ImageUrl NVARCHAR(MAX),
	@UserId BIGINT,
	@IsApproved BIT,
	@WhereToBuy  NVARCHAR(MAX)
AS
BEGIN

INSERT INTO [Idea]
	([Name]
	,[Description]
	,[DateCreated]
	,[Tags]
	,[ImageUrl]
	,[UserId]
	,[IsApproved]
	,[WhereToBuy])
VALUES
	(@Name
	,@Description
	,@DateCreated
	,@Tags
	,@ImageUrl
	,@UserId
	,@IsApproved
	,@WhereToBuy)

SELECT @Id = @@IDENTITY

END