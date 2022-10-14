CREATE TABLE [dbo].[Teacher] (
    [TId]       INT          NOT NULL,
    [Privelage] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([TId] ASC),
    CONSTRAINT [fk_teacher_Staff] FOREIGN KEY ([TId]) REFERENCES [dbo].[Staff] ([StaffId]) ON DELETE CASCADE ON UPDATE CASCADE
);

