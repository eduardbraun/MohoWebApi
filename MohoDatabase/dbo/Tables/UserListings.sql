CREATE TABLE [dbo].[UserListings]
(
	[UserListingId] int NOT NULL Identity, 
	[ListingType] INT NOT NULL, 
    [CountryType] INT NOT NULL, 
    [ProvinceType] INT NOT NULL, 
    [CityType] INT NOT NULL, 
    [OwnerId] NVARCHAR(450) NOT NULL, 
    [ListingDate] DATETIME NULL, 
    [LastUpdatedDate] DATETIME NULL, 
    [ListingDescription] VARCHAR(50) NULL, 
    [ListingTitle] VARCHAR(50) NOT NULL, 
    [PhoneNumber] VARCHAR(50) NULL, 
    [Email] VARCHAR(50) NULL, 
    [FullName] VARCHAR(50) NULL, 
    [Address] VARCHAR(50) NULL, 
    [Views] INT NULL,

	CONSTRAINT [PK_UserListing] PRIMARY KEY ([UserListingId]),
    CONSTRAINT [FK_OwnerId] FOREIGN KEY (OwnerId) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
  
)
