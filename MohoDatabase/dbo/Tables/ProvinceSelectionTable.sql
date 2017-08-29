CREATE TABLE [dbo].[ProvinceSelectionTable]
(
	[Id] int NOT NULL Identity, 
    [ProvinceName] VARCHAR(150) NOT NULL, 
    [CountryRefId] INT NULL, 

	CONSTRAINT [PK_ProvinceId] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProvinceCountryRefId] FOREIGN KEY (CountryRefId) REFERENCES [CountrySelectionTable] ([Id])
)
