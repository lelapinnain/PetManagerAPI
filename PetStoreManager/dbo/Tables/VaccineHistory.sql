CREATE TABLE [dbo].[VaccineHistory] (
    [VaccineHistoryId] INT           IDENTITY (1, 1) NOT NULL,
    [PetInfoId]        INT           NOT NULL,
    [VaccineId]        INT           NOT NULL,
    [VaccineDate]      DATE          NULL,
    [Notes]            VARCHAR (150) NULL,
    [IsPostponed]      BIT           NULL,
    [PostponeDate]     DATE          NULL,
    [IsDone]           BIT           NULL,
    [ActualDate]       DATE          NULL,
    CONSTRAINT [PK__VaccineH__0FB3B99744C9E3F8] PRIMARY KEY CLUSTERED ([VaccineHistoryId] ASC),
    CONSTRAINT [FK_VaccineHistory_PetInfo] FOREIGN KEY ([PetInfoId]) REFERENCES [dbo].[PetInfo] ([PetId]),
    CONSTRAINT [FK_VaccineHistory_VaccineInfo] FOREIGN KEY ([VaccineId]) REFERENCES [dbo].[VaccineInfo] ([VaccineId])
);

