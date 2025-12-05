CREATE TABLE [dbo].[tbRegistrations] (
    [RegistrationId]   INT           IDENTITY (1, 1) NOT NULL,
    [UserId]           INT           NOT NULL,
    [EventId]          INT           NOT NULL,
    [RegistrationDate] DATETIME      DEFAULT (getdate()) NOT NULL,
    [Status]           NVARCHAR (20) DEFAULT ('Pending') NOT NULL,
    PRIMARY KEY CLUSTERED ([RegistrationId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[tbUsers] ([UserId])
);