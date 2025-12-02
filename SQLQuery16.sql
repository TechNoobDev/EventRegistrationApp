-- Table for user accounts (login)
CREATE TABLE [dbo].[tbAccounts] (
    [AccountId]    INT            IDENTITY (1, 1) NOT NULL,
    [Username]     NVARCHAR (50)  NOT NULL,
    [PasswordHash] NVARCHAR (MAX) NOT NULL,
    [CreatedAt]    DATETIME       DEFAULT (getdate()) NOT NULL,
    [IsActive]     BIT            DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([AccountId] ASC),
    UNIQUE NONCLUSTERED ([Username] ASC)
);