CREATE TABLE [dbo].[Lessons] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [CorsiId]     INT            NOT NULL,
    [Title ]      NVARCHAR (100) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Duration]    NVARCHAR (8)   DEFAULT ('00:00:00') NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CorsiId]) REFERENCES [dbo].[Corsi] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
);

