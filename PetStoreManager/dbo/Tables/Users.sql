CREATE TABLE [dbo].[Users] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Email]     VARCHAR (150) NULL,
    [FirstName] VARCHAR (50)  NULL,
    [LastName]  VARCHAR (50)  NULL,
    [Password]  VARCHAR (MAX) NULL,
    [isActive]  BIT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

