CREATE TABLE [dbo].[CategoryClient] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [CategoryName] NVARCHAR (50) NULL,
    [IsDeleted]    BIT           NULL,
    CONSTRAINT [PK_CategoryClient] PRIMARY KEY CLUSTERED ([Id] ASC)
);

