CREATE TABLE [dbo].[Customers] (
    [CustomerId] INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]  VARCHAR (150)  NULL,
    [LastName]   VARCHAR (150)  NULL,
    [Address]    NVARCHAR (MAX) NULL,
    [Email]      NVARCHAR (MAX) NULL,
    [Phone]      NVARCHAR (150) NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([CustomerId] ASC)
);

