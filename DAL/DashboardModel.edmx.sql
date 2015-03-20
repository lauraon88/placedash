
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/19/2015 14:40:10
-- Generated from EDMX file: C:\Users\marmionc\Documents\Visual Studio 2013\Projects\PlacementDashboard\DAL\DashboardModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PlacementDashboard];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Consutant_Projects]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Consultant_Project] DROP CONSTRAINT [FK_Consutant_Projects];
GO
IF OBJECT_ID(N'[dbo].[FK_Consultant_Projects]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Consultant_Project] DROP CONSTRAINT [FK_Consultant_Projects];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projects];
GO
IF OBJECT_ID(N'[dbo].[Consultants]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Consultants];
GO
IF OBJECT_ID(N'[dbo].[Consultant_Project]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Consultant_Project];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Consultants'
CREATE TABLE [dbo].[Consultants] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [PhoneNumber] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Consultant_Project'
CREATE TABLE [dbo].[Consultant_Project] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjStartDate] datetime  NOT NULL,
    [ProjEndDate] datetime  NOT NULL,
    [BillableStatus] bit  NOT NULL,
    [BillableDaysMonth] int  NULL,
    [BillableDaysYTD] int  NULL,
    [ProjectId] int  NOT NULL,
    [ConsultantId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Consultants'
ALTER TABLE [dbo].[Consultants]
ADD CONSTRAINT [PK_Consultants]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Consultant_Project'
ALTER TABLE [dbo].[Consultant_Project]
ADD CONSTRAINT [PK_Consultant_Project]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProjectId] in table 'Consultant_Project'
ALTER TABLE [dbo].[Consultant_Project]
ADD CONSTRAINT [FK_Consutant_Projects]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[Projects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Consutant_Projects'
CREATE INDEX [IX_FK_Consutant_Projects]
ON [dbo].[Consultant_Project]
    ([ProjectId]);
GO

-- Creating foreign key on [ConsultantId] in table 'Consultant_Project'
ALTER TABLE [dbo].[Consultant_Project]
ADD CONSTRAINT [FK_Consultant_Projects]
    FOREIGN KEY ([ConsultantId])
    REFERENCES [dbo].[Consultants]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Consultant_Projects'
CREATE INDEX [IX_FK_Consultant_Projects]
ON [dbo].[Consultant_Project]
    ([ConsultantId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------