CREATE TABLE tbEventRegistrations
(
    RegistrationId INT IDENTITY(1,1) PRIMARY KEY,  -- Auto-incrementing ID
    EventId INT NOT NULL,                          -- FK to tbEvents
    FirstName NVARCHAR(100) NOT NULL,
    MiddleName NVARCHAR(100) NULL,                -- Optional
    LastName NVARCHAR(100) NOT NULL,
    SuffixName NVARCHAR(50) NULL,                 -- Optional
    YearLevel NVARCHAR(50) NOT NULL,
    Section NVARCHAR(50) NOT NULL,
    School NVARCHAR(150) NOT NULL,
    RegisteredAt DATETIME NOT NULL DEFAULT GETDATE(),

    -- Foreign key constraint linking to Events table
    CONSTRAINT FK_tbEventRegistrations_tbEvents FOREIGN KEY (EventId)
        REFERENCES tbEvents(EventId)
        ON DELETE CASCADE
);
