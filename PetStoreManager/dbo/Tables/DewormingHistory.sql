CREATE TABLE [dbo].[DewormingHistory] (
    [DewormingHistoryId] INT  IDENTITY (1, 1) NOT NULL,
    [PetInfoId]          INT  NOT NULL,
    [DewormingId]        INT  NOT NULL,
    [DewormingStartDate] DATE NULL,
    [DewormingEndDate]   DATE NULL,
    CONSTRAINT [PK_DewormingHistory] PRIMARY KEY CLUSTERED ([DewormingHistoryId] ASC),
    CONSTRAINT [FK_DewormingHistory_DewormingInfo] FOREIGN KEY ([DewormingId]) REFERENCES [dbo].[DewormingInfo] ([DewormingId]),
    CONSTRAINT [FK_DewormingHistory_PetInfo] FOREIGN KEY ([PetInfoId]) REFERENCES [dbo].[PetInfo] ([PetId])
);

