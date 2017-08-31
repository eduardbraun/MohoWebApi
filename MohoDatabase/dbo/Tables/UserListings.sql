CREATE TABLE [dbo].[UserListings]
(
	[UserListingId] int NOT NULL Identity, 
	[ListingName] VARCHAR(100) NOT NULL, 
    [CountryName] VARCHAR(100) NOT NULL, 
    [ProvinceName] VARCHAR(100) NOT NULL, 
    [CityName] VARCHAR(100) NOT NULL, 
    [OwnerId] NVARCHAR(450) NOT NULL, 
    [ListingDate] DATETIME NULL, 
    [LastUpdatedDate] DATETIME NULL, 
    [ListingDescription] VARCHAR(450) NULL, 
    [ListingTitle] VARCHAR(50) NOT NULL, 
    [PhoneNumber] VARCHAR(50) NULL, 
    [Email] VARCHAR(100) NULL, 
    [FullName] VARCHAR(50) NULL, 
    [Address] VARCHAR(50) NULL, 
    [Views] INT NULL,

	[ListingTypeRefId] INT NULL, 
    [CountryRefId] INT NULL, 
    [ProvinceRefId] INT NULL, 
    [CityRefId] INT NULL, 
    [ListingEnabled] BIT NOT NULL default 1, 
    CONSTRAINT [PK_UserListing] PRIMARY KEY ([UserListingId]),
    CONSTRAINT [FK_OwnerId] FOREIGN KEY (OwnerId) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
  
)
