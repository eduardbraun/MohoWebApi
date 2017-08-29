CREATE TABLE [dbo].[CitySeleectionTable]
(
	[Id] int NOT NULL Identity, 
    [RegionName] VARCHAR(150) NOT NULL, 
    [CountryRefId] INT NOT NULL, 
    [ProvinceRefId] INT NOT NULL, 

	CONSTRAINT [PK_CityId] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CityCountryRefId] FOREIGN KEY (CountryRefId) REFERENCES [CountrySelectionTable] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CityProvinceRefId] FOREIGN KEY (ProvinceRefId) REFERENCES [ProvinceSelectionTable] ([Id]) ON DELETE CASCADE
)
