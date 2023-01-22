CREATE TABLE [dbo].[customerTable]
(
	[FName] VARCHAR(50) NOT NULL, 
    [LName] VARCHAR(50) NULL, 
    [DateOfBirth] DATETIME NULL, 
    [Country] VARCHAR(50) NULL, 
    [PhoneNumber] VARCHAR(50) NULL, 
    [Email] VARCHAR(50) NOT NULL, 
    [Password] VARCHAR(50) NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([Email]) 
)
