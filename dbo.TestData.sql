CREATE TABLE [dbo].[TestData] (
    [ID]       INT          IDENTITY (1, 1) NOT NULL,
    [UserName] VARCHAR (40) NULL,
    [Password] VARCHAR (20) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

