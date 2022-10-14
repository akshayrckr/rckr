CREATE TABLE [dbo].[Admin] (
    [AId]       INT          NOT NULL,
    [Privelage] VARCHAR (50) NULL,
    [Type]      VARCHAR (15) NULL,
    PRIMARY KEY CLUSTERED ([AId] ASC),
    CONSTRAINT [fk_Admin_Staff] FOREIGN KEY ([AId]) REFERENCES [dbo].[Staff] ([StaffId]) ON DELETE CASCADE ON UPDATE CASCADE
);

