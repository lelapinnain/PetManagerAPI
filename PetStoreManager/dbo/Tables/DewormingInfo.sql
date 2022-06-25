CREATE TABLE [dbo].[DewormingInfo] (
    [DewormingId]    INT           IDENTITY (1, 1) NOT NULL,
    [DewormingTitle] VARCHAR (150) NULL,
    CONSTRAINT [PK_DewormingInfo] PRIMARY KEY CLUSTERED ([DewormingId] ASC)
);

