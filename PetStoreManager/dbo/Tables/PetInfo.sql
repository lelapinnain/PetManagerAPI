CREATE TABLE [dbo].[PetInfo] (
    [PetId]               INT             IDENTITY (1, 1) NOT NULL,
    [PetName]             NVARCHAR (MAX)  NOT NULL,
    [BuyPrice]            DECIMAL (18, 2) NOT NULL,
    [BreedId]             INT             DEFAULT ((1)) NOT NULL,
    [Dob]                 DATE            NOT NULL,
    [Microchip]           NVARCHAR (MAX)  NOT NULL,
    [Images]              NVARCHAR (MAX)  NOT NULL,
    [ReceiveDate]         DATE            NOT NULL,
    [TransportationPrice] DECIMAL (18, 2) NOT NULL,
    [Color]               NVARCHAR (50)   NOT NULL,
    [Gender]              NVARCHAR (50)   NOT NULL,
    [isSold]              BIT             NOT NULL,
    [PetTypeId]           INT             NULL,
    [BreederId]           INT             NULL,
    [VaccinePostponed]    BIT             CONSTRAINT [DF_PetInfo_VaccinePostponed] DEFAULT ((0)) NOT NULL,
    [VaccinePostponeDate] DATE            NULL,
    [Breed]               NVARCHAR (50)   NULL,
    PRIMARY KEY CLUSTERED ([PetId] ASC),
    CONSTRAINT [FK_PetInfo_BreedInfo] FOREIGN KEY ([BreedId]) REFERENCES [dbo].[BreedInfo] ([BreedId])
);

