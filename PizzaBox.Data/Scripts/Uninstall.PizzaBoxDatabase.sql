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
IF OBJECT_ID(N'[PizzaBoxDbSchema].[FK_OrderItem]', 'F') IS NOT NULL
    ALTER TABLE [PizzaBoxDbSchema].[Items] DROP CONSTRAINT [FK_OrderItem];
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
-- Script has ended
-- --------------------------------------------------