CREATE TABLE [dbo].[VaccineInfo] (
    [VaccineId]    INT           IDENTITY (1, 1) NOT NULL,
    [VaccineTitle] VARCHAR (150) NULL,
    CONSTRAINT [PK__VaccineI__45DC6889925BF0F7] PRIMARY KEY CLUSTERED ([VaccineId] ASC)
);

