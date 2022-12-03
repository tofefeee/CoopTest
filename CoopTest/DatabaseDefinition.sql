CREATE TABLE [dbo].[Assortments] (
    [Id]         INT         NOT NULL,
    [Name]       NCHAR (100) NOT NULL,
    [ActiveFrom] DATETIME    NOT NULL,
    [ActiveTo]   DATETIME  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Assortments] (
    [Id]         INT         NOT NULL,
    [Name]       NCHAR (100) NOT NULL,
    [ActiveFrom] DATETIME    NOT NULL,
    [ActiveTo]   DATETIME    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[AssortmentProducts]
(
	[ProductId] INT NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES Products(Id),
  [AssortmentId] INT NOT NULL FOREIGN KEY REFERENCES Assortments(Id)
);

CREATE SEQUENCE dbo.Id  
    AS int  
    START WITH 1  
    INCREMENT BY 1 ;