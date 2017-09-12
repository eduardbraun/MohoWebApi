CREATE TABLE [dbo].[SendEmailLog]
(
	[Id] int NOT NULL Identity, 
	[Message] VARCHAR(MAX) NULL, 
    [FromEmail] VARCHAR(250) NULL, 
	[ToEmail] VARCHAR(250) NULL,
    [SendDate] DATETIME NOT NULL DEFAULT getdate(), 
    [RecipientUserId] NVARCHAR(450) NULL, 
    CONSTRAINT [PK_SendEmailId] PRIMARY KEY (Id),
	CONSTRAINT [FK_RecipientUserId] FOREIGN KEY (RecipientUserId) REFERENCES [AspNetUsers] ([Id]),
)
