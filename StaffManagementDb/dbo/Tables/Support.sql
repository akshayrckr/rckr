CREATE TABLE [dbo].[Support] (
    [SId]      INT          NOT NULL,
    [Position] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([SId] ASC),
    CONSTRAINT [fk_Support_Staff] FOREIGN KEY ([SId]) REFERENCES [dbo].[Staff] ([StaffId]) ON DELETE CASCADE ON UPDATE CASCADE
);

