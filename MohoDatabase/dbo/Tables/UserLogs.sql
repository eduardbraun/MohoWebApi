CREATE TABLE [dbo].[UserLogs]
(
	[Id] INT NOT NULL IDENTITY, 
    [UserId] NVARCHAR(450) NOT NULL,
	[LogType] VARCHAR(250) Null,
    [LogMessage] VARCHAR(MAX) NULL, 
    [LogDate] DATETIME NOT NULL DEFAULT getdate(),

	CONSTRAINT [PK_UserLogsId] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserLogUserId] FOREIGN KEY (UserId) REFERENCES [AspNetUsers] ([Id]),
)
