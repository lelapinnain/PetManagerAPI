CREATE TABLE [dbo].[BreedInfo] (
    [BreedId]   INT           IDENTITY (1, 1) NOT NULL,
    [BreedName] VARCHAR (150) NULL,
    [BreedSize] VARCHAR (10)  NULL,
    CONSTRAINT [PK__Table__D1E9AE9DB59864B2] PRIMARY KEY CLUSTERED ([BreedId] ASC)
);

