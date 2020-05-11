CREATE TABLE [dbo].[Corsi] (
    [id]                    INT            IDENTITY (1, 1) NOT NULL,
    [Title]                 NVARCHAR (100) NOT NULL,
    [Description]           NVARCHAR (MAX) NULL,
    [ImagePath]             NVARCHAR (100) NULL,
    [Author]                NVARCHAR (100) NOT NULL,
    [Email]                 NVARCHAR (100) CONSTRAINT [DF_Corsi_Email] DEFAULT ('EUR') NOT NULL,
    [Rating]                REAL           CONSTRAINT [DF_Corsi_Rating] DEFAULT ((0)) NULL,
    [FullPrice_Amount]      NUMERIC (18)   CONSTRAINT [DF_Corsi_FullPrice_Amount] DEFAULT ((0)) NULL,
    [FullPrice_Currency]    NVARCHAR (3)   NULL,
    [CurrentPrice_Amount]   NUMERIC (18)   CONSTRAINT [DF_Corsi_CurrentPrice_Amount] DEFAULT ((0)) NULL,
    [CurrentPrice_Currency] NVARCHAR (3)   CONSTRAINT [DF_Corsi_CurrentPrice_Currency] DEFAULT ('EUR') NULL,
    CONSTRAINT [PK_Corsi_1] PRIMARY KEY CLUSTERED ([id] ASC)
);

