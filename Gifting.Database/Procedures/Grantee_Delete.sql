﻿CREATE PROCEDURE [dbo].[Grantee_Delete]
	@Id BIGINT
AS
BEGIN

DELETE
FROM [Grantee]
WHERE Id = @Id

END