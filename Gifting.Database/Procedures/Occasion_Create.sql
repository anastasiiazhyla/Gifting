CREATE PROCEDURE [dbo].[Occasion_Create]
	@Id BIGINT OUTPUT,
	@Name NVARCHAR(255),
	@UserId BIGINT,
	@Period TINYINT
AS
BEGIN

INSERT INTO [Occasion]
	([Name]
	,[UserId]
	,[Period])
VALUES
	(@Name
	,@UserId
	,@Period)

SELECT @Id = @@IDENTITY

END