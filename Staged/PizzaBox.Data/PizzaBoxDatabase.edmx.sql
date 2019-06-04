
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/03/2019 02:23:10
-- Generated from EDMX file: C:\Users\jmau0\Desktop\Revature\DOT NET CORE Week 1-3 Jump\Project-1\Staged\PizzaBox.Data\PizzaBoxDatabase.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [model];
GO
IF SCHEMA_ID(N'PizzaBoxDbSchema') IS NULL EXECUTE(N'CREATE SCHEMA [PizzaBoxDbSchema]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[PizzaBoxDbSchema].[FK_OutletEmployee]', 'F') IS NOT NULL
    ALTER TABLE [PizzaBoxDbSchema].[People_Employee] DROP CONSTRAINT [FK_OutletEmployee];
GO
IF OBJECT_ID(N'[PizzaBoxDbSchema].[FK_PersonAddress]', 'F') IS NOT NULL
    ALTER TABLE [PizzaBoxDbSchema].[Addresses] DROP CONSTRAINT [FK_PersonAddress];
GO
IF OBJECT_ID(N'[PizzaBoxDbSchema].[FK_OutletAddress]', 'F') IS NOT NULL
    ALTER TABLE [PizzaBoxDbSchema].[Addresses] DROP CONSTRAINT [FK_OutletAddress];
GO
IF OBJECT_ID(N'[PizzaBoxDbSchema].[FK_OutletOrder]', 'F') IS NOT NULL
    ALTER TABLE [PizzaBoxDbSchema].[Orders] DROP CONSTRAINT [FK_OutletOrder];
GO
IF OBJECT_ID(N'[PizzaBoxDbSchema].[FK_PersonOrder]', 'F') IS NOT NULL
    ALTER TABLE [PizzaBoxDbSchema].[Orders] DROP CONSTRAINT [FK_PersonOrder];
GO
IF OBJECT_ID(N'[PizzaBoxDbSchema].[FK_OutletFeature]', 'F') IS NOT NULL
    ALTER TABLE [PizzaBoxDbSchema].[Features] DROP CONSTRAINT [FK_OutletFeature];
GO
IF OBJECT_ID(N'[PizzaBoxDbSchema].[FK_OutletItem]', 'F') IS NOT NULL
    ALTER TABLE [PizzaBoxDbSchema].[Items] DROP CONSTRAINT [FK_OutletItem];
GO
IF OBJECT_ID(N'[PizzaBoxDbSchema].[FK_Employee_inherits_Person]', 'F') IS NOT NULL
    ALTER TABLE [PizzaBoxDbSchema].[People_Employee] DROP CONSTRAINT [FK_Employee_inherits_Person];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[PizzaBoxDbSchema].[People]', 'U') IS NOT NULL
    DROP TABLE [PizzaBoxDbSchema].[People];
GO
IF OBJECT_ID(N'[PizzaBoxDbSchema].[Addresses]', 'U') IS NOT NULL
    DROP TABLE [PizzaBoxDbSchema].[Addresses];
GO
IF OBJECT_ID(N'[PizzaBoxDbSchema].[Features]', 'U') IS NOT NULL
    DROP TABLE [PizzaBoxDbSchema].[Features];
GO
IF OBJECT_ID(N'[PizzaBoxDbSchema].[Items]', 'U') IS NOT NULL
    DROP TABLE [PizzaBoxDbSchema].[Items];
GO
IF OBJECT_ID(N'[PizzaBoxDbSchema].[Orders]', 'U') IS NOT NULL
    DROP TABLE [PizzaBoxDbSchema].[Orders];
GO
IF OBJECT_ID(N'[PizzaBoxDbSchema].[StateTaxes]', 'U') IS NOT NULL
    DROP TABLE [PizzaBoxDbSchema].[StateTaxes];
GO
IF OBJECT_ID(N'[PizzaBoxDbSchema].[Outlets]', 'U') IS NOT NULL
    DROP TABLE [PizzaBoxDbSchema].[Outlets];
GO
IF OBJECT_ID(N'[PizzaBoxDbSchema].[People_Employee]', 'U') IS NOT NULL
    DROP TABLE [PizzaBoxDbSchema].[People_Employee];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'People'
CREATE TABLE [PizzaBoxDbSchema].[People] (
    [Id] uniqueidentifier  NOT NULL,
    [FName] nvarchar(max)  NOT NULL,
    [MName] nvarchar(max)  NULL,
    [LName] nvarchar(max)  NOT NULL,
    [Gender] bit  NULL,
    [DoB] datetime  NULL,
    [Phone] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NULL
);
GO

-- Creating table 'Addresses'
CREATE TABLE [PizzaBoxDbSchema].[Addresses] (
    [Id] uniqueidentifier  NOT NULL,
    [PersonId] uniqueidentifier  NULL,
    [OutletId] uniqueidentifier  NULL,
    [State] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Street] nvarchar(max)  NOT NULL,
    [Zip] nvarchar(max)  NOT NULL,
    [Apt] nvarchar(max)  NULL
);
GO

-- Creating table 'Features'
CREATE TABLE [PizzaBoxDbSchema].[Features] (
    [Id] uniqueidentifier  NOT NULL,
    [OutletId] uniqueidentifier  NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Cost] float  NOT NULL
);
GO

-- Creating table 'Items'
CREATE TABLE [PizzaBoxDbSchema].[Items] (
    [Id] uniqueidentifier  NOT NULL,
    [OutletId] uniqueidentifier  NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Cost] float  NOT NULL,
    [Features] nvarchar(max)  NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [PizzaBoxDbSchema].[Orders] (
    [Id] uniqueidentifier  NOT NULL,
    [OutletId] uniqueidentifier  NULL,
    [PersonId] uniqueidentifier  NULL,
    [DateOrdered] datetime  NOT NULL,
    [Items] nvarchar(max)  NOT NULL,
    [SubTotal] float  NOT NULL,
    [Total] float  NOT NULL
);
GO

-- Creating table 'StateTaxes'
CREATE TABLE [PizzaBoxDbSchema].[StateTaxes] (
    [Id] uniqueidentifier  NOT NULL,
    [Territory] nvarchar(max)  NOT NULL,
    [TaxRate] float  NOT NULL
);
GO

-- Creating table 'Outlets'
CREATE TABLE [PizzaBoxDbSchema].[Outlets] (
    [Id] uniqueidentifier  NOT NULL,
    [Organization] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'People_Employee'
CREATE TABLE [PizzaBoxDbSchema].[People_Employee] (
    [OutletId] uniqueidentifier  NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Position] nvarchar(max)  NOT NULL,
    [Wage] float  NOT NULL,
    [WageType] float  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'People'
ALTER TABLE [PizzaBoxDbSchema].[People]
ADD CONSTRAINT [PK_People]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Addresses'
ALTER TABLE [PizzaBoxDbSchema].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Features'
ALTER TABLE [PizzaBoxDbSchema].[Features]
ADD CONSTRAINT [PK_Features]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Items'
ALTER TABLE [PizzaBoxDbSchema].[Items]
ADD CONSTRAINT [PK_Items]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Orders'
ALTER TABLE [PizzaBoxDbSchema].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StateTaxes'
ALTER TABLE [PizzaBoxDbSchema].[StateTaxes]
ADD CONSTRAINT [PK_StateTaxes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Outlets'
ALTER TABLE [PizzaBoxDbSchema].[Outlets]
ADD CONSTRAINT [PK_Outlets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'People_Employee'
ALTER TABLE [PizzaBoxDbSchema].[People_Employee]
ADD CONSTRAINT [PK_People_Employee]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [OutletId] in table 'People_Employee'
ALTER TABLE [PizzaBoxDbSchema].[People_Employee]
ADD CONSTRAINT [FK_OutletEmployee]
    FOREIGN KEY ([OutletId])
    REFERENCES [PizzaBoxDbSchema].[Outlets]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OutletEmployee'
CREATE INDEX [IX_FK_OutletEmployee]
ON [PizzaBoxDbSchema].[People_Employee]
    ([OutletId]);
GO

-- Creating foreign key on [PersonId] in table 'Addresses'
ALTER TABLE [PizzaBoxDbSchema].[Addresses]
ADD CONSTRAINT [FK_PersonAddress]
    FOREIGN KEY ([PersonId])
    REFERENCES [PizzaBoxDbSchema].[People]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonAddress'
CREATE INDEX [IX_FK_PersonAddress]
ON [PizzaBoxDbSchema].[Addresses]
    ([PersonId]);
GO

-- Creating foreign key on [OutletId] in table 'Addresses'
ALTER TABLE [PizzaBoxDbSchema].[Addresses]
ADD CONSTRAINT [FK_OutletAddress]
    FOREIGN KEY ([OutletId])
    REFERENCES [PizzaBoxDbSchema].[Outlets]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OutletAddress'
CREATE INDEX [IX_FK_OutletAddress]
ON [PizzaBoxDbSchema].[Addresses]
    ([OutletId]);
GO

-- Creating foreign key on [OutletId] in table 'Orders'
ALTER TABLE [PizzaBoxDbSchema].[Orders]
ADD CONSTRAINT [FK_OutletOrder]
    FOREIGN KEY ([OutletId])
    REFERENCES [PizzaBoxDbSchema].[Outlets]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OutletOrder'
CREATE INDEX [IX_FK_OutletOrder]
ON [PizzaBoxDbSchema].[Orders]
    ([OutletId]);
GO

-- Creating foreign key on [PersonId] in table 'Orders'
ALTER TABLE [PizzaBoxDbSchema].[Orders]
ADD CONSTRAINT [FK_PersonOrder]
    FOREIGN KEY ([PersonId])
    REFERENCES [PizzaBoxDbSchema].[People]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonOrder'
CREATE INDEX [IX_FK_PersonOrder]
ON [PizzaBoxDbSchema].[Orders]
    ([PersonId]);
GO

-- Creating foreign key on [OutletId] in table 'Features'
ALTER TABLE [PizzaBoxDbSchema].[Features]
ADD CONSTRAINT [FK_OutletFeature]
    FOREIGN KEY ([OutletId])
    REFERENCES [PizzaBoxDbSchema].[Outlets]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OutletFeature'
CREATE INDEX [IX_FK_OutletFeature]
ON [PizzaBoxDbSchema].[Features]
    ([OutletId]);
GO

-- Creating foreign key on [OutletId] in table 'Items'
ALTER TABLE [PizzaBoxDbSchema].[Items]
ADD CONSTRAINT [FK_OutletItem]
    FOREIGN KEY ([OutletId])
    REFERENCES [PizzaBoxDbSchema].[Outlets]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OutletItem'
CREATE INDEX [IX_FK_OutletItem]
ON [PizzaBoxDbSchema].[Items]
    ([OutletId]);
GO

-- Creating foreign key on [Id] in table 'People_Employee'
ALTER TABLE [PizzaBoxDbSchema].[People_Employee]
ADD CONSTRAINT [FK_Employee_inherits_Person]
    FOREIGN KEY ([Id])
    REFERENCES [PizzaBoxDbSchema].[People]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------