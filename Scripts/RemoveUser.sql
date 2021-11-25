USE [UserFormSumission]
GO

CREATE PROCEDURE [dbo].[spRemoveUser]

 @email NVARCHAR(50)
 AS
BEGIN
DELETE FROM [dbo].[User]
      WHERE email = @email

END
