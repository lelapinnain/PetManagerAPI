CREATE TABLE [dbo].[InvoicePayments] (
    [PaymentId]       INT             IDENTITY (1, 1) NOT NULL,
    [InvoiceId]       INT             NOT NULL,
    [PaymentAmount]   DECIMAL (18, 2) NOT NULL,
    [PaymentDate]     DATETIME        NOT NULL,
    [PaymentMethodId] INT             NOT NULL,
    CONSTRAINT [PK_InvoicePayments] PRIMARY KEY CLUSTERED ([PaymentId] ASC),
    CONSTRAINT [FK_InvoicePayments_Invoices] FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoices] ([InvoiceId]),
    CONSTRAINT [FK_InvoicePayments_PaymentMethod] FOREIGN KEY ([PaymentMethodId]) REFERENCES [dbo].[PaymentMethod] ([PaymentMethodId])
);

