CREATE TABLE [dbo].[Invoices] (
    [InvoiceId]          INT             IDENTITY (1, 1) NOT NULL,
    [PetinfoId]          INT             NOT NULL,
    [CustomerId]         INT             NOT NULL,
    [ActualPrice]        DECIMAL (18, 2) NOT NULL,
    [DiscountAmount]     DECIMAL (18, 2) NULL,
    [PriceAfterDiscount] DECIMAL (18, 2) NOT NULL,
    [RegistrationFees]   DECIMAL (18, 2) NULL,
    [Tax]                DECIMAL (18, 2) NULL,
    [PriceAfterTax]      DECIMAL (18, 2) NULL,
    [DepositAmount]      DECIMAL (18, 2) NULL,
    [RemainingBalance]   DECIMAL (18, 2) NULL,
    [DateOfPurchase]     DATETIME        NOT NULL,
    [PickupDate]         DATETIME        NULL,
    [DepositDate]        DATETIME        NULL,
    [ExpectedPickupDate] DATETIME        NULL,
    CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED ([InvoiceId] ASC),
    CONSTRAINT [FK_Invoices_Customers] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([CustomerId]),
    CONSTRAINT [FK_Invoices_PetInfo] FOREIGN KEY ([PetinfoId]) REFERENCES [dbo].[PetInfo] ([PetId])
);

