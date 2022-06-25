CREATE TABLE [dbo].[AppointmentPets] (
    [AppointmentPetID]     INT IDENTITY (1, 1) NOT NULL,
    [AppointmentHistoryId] INT NOT NULL,
    [PetId]                INT NOT NULL,
    CONSTRAINT [PK_AppointmentPets] PRIMARY KEY CLUSTERED ([AppointmentPetID] ASC),
    CONSTRAINT [FK_AppointmentPets_AppointmentHistory] FOREIGN KEY ([AppointmentHistoryId]) REFERENCES [dbo].[AppointmentHistory] ([AppointmentId]),
    CONSTRAINT [FK_AppointmentPets_PetInfo] FOREIGN KEY ([PetId]) REFERENCES [dbo].[PetInfo] ([PetId])
);

