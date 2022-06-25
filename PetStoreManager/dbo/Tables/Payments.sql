CREATE TABLE [dbo].[Payments] (
    [PaymentID]       INT             IDENTITY (1, 1) NOT NULL,
    [InvoiceId]       INT             NULL,
    [PaymentMethodId] INT             NULL,
    [Amount]          DECIMAL (18, 2) NULL,
    [PaymentDate]     DATETIME        NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([PaymentID] ASC),
    CONSTRAINT [FK_Transactions_Invoices] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoices] ([InvoiceId]),
    CONSTRAINT [FK_Transactions_PaymentMethod] FOREIGN KEY ([PaymentMethodId]) REFERENCES [dbo].[PaymentMethod] ([PaymentMethodId])
);

