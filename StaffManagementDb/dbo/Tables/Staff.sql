CREATE TABLE [dbo].[Staff] (
    [StaffId] INT          IDENTITY (1, 1) NOT NULL,
    [Name]    VARCHAR (30) NULL,
    [Email]   VARCHAR (40) NULL,
    [Address] VARCHAR (50) NULL,
    [Phone]   VARCHAR (50) NULL,
    [RoleId]  INT          NULL,
    PRIMARY KEY CLUSTERED ([StaffId] ASC),
    FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([RoleId])
);





