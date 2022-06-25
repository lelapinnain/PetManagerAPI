CREATE TABLE [dbo].[AppointmentHistory] (
    [AppointmentId]        INT            IDENTITY (1, 1) NOT NULL,
    [CustomerName]         NVARCHAR (MAX) NOT NULL,
    [CustomerPhoneNumber]  NVARCHAR (50)  NOT NULL,
    [AppointmentDate]      DATE           NULL,
    [AppointmentStartTime] DATETIME       NULL,
    [AppointmentDuration]  INT            NULL,
    [PaymentMethodId]      INT            NULL,
    [Notes]                NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AppointmentHistory] PRIMARY KEY CLUSTERED ([AppointmentId] ASC),
    CONSTRAINT [FK_AppointmentHistory_PaymentMethod] FOREIGN KEY ([PaymentMethodId]) REFERENCES [dbo].[PaymentMethod] ([PaymentMethodId])
);

