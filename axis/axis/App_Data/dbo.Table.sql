CREATE TABLE [dbo].[Table]
(
	[UserId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Email] NCHAR(150) NOT NULL, 
    [Password] NCHAR(200) NOT NULL, 
    [PasswordSalt] NCHAR(200) NOT NULL 
)
