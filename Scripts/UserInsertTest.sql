USE [UserFormSubmissionTest]
GO
/****** Object:  StoredProcedure [dbo].[spAddUser]    Script Date: 25/11/2021 13:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spAddUser]
    @email NVARCHAR(50), 
    @password NVARCHAR(50),
	@createdDate DATE
AS
BEGIN
    SET NOCOUNT ON

    DECLARE @salt UNIQUEIDENTIFIER=NEWID()

        INSERT INTO dbo.[User] (Email, PasswordHash, Salt,CreatedDate)
        VALUES(@email, HASHBYTES('SHA2_512', @password+CAST(@salt AS NVARCHAR(36))), @salt, @createdDate)

END