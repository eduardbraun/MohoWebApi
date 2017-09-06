CREATE TABLE [dbo].[UserReview]
(
	[UserReviewId] int NOT NULL Identity, 
    [ReviewDeleted] BIT NOT NULL default 0, 
    [ReviewOwnerRefId]  NVARCHAR (450) NOT NULL,
    [UserRefId]  NVARCHAR (450) NOT NULL,
    [ReviewTitle] VARCHAR(50) NULL, 
    [ReviewDescription] VARCHAR(MAX) NULL, 
    [ReviewDate] DATETIME NULL, 
    [UpVoteNum] NCHAR(10) NOT NULL DEFAULT 0,
    [ReviewUsername] VARCHAR(250) NOT NULL, 
    CONSTRAINT [PK_UserReviewId] PRIMARY KEY ([UserReviewId]),
    CONSTRAINT [FK_ReviewOwnerId] FOREIGN KEY (ReviewOwnerRefId) REFERENCES [AspNetUsers] ([Id]),
    CONSTRAINT [FK_ReviewUserRefId] FOREIGN KEY (UserRefId) REFERENCES [AspNetUsers] ([Id])
)
