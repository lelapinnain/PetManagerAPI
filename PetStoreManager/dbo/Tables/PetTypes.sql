CREATE TABLE [dbo].[PetTypes] (
    [PetTypeId]   INT           IDENTITY (1, 1) NOT NULL,
    [PetTypeName] VARCHAR (250) NULL,
    PRIMARY KEY CLUSTERED ([PetTypeId] ASC)
);

