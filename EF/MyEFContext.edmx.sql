
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/26/2014 14:29:45
-- Generated from EDMX file: C:\Users\liuu\Documents\Visual Studio 2012\Projects\MyWeb\EF\MyEFContext.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GGN_NewsEF];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TGAMERCA_REFERENCE_TGAME]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TGameRCategory] DROP CONSTRAINT [FK_TGAMERCA_REFERENCE_TGAME];
GO
IF OBJECT_ID(N'[dbo].[FK_TGAMERCA_REFERENCE_TCATEGOR]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TGameRCategory] DROP CONSTRAINT [FK_TGAMERCA_REFERENCE_TCATEGOR];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TCategory];
GO
IF OBJECT_ID(N'[dbo].[TGame]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TGame];
GO
IF OBJECT_ID(N'[dbo].[TGameRCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TGameRCategory];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TCategory'
CREATE TABLE [dbo].[TCategory] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(30)  NOT NULL,
    [State] bit  NOT NULL
);
GO

-- Creating table 'TGame'
CREATE TABLE [dbo].[TGame] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(30)  NOT NULL,
    [State] bit  NOT NULL
);
GO

-- Creating table 'TGameRCategory'
CREATE TABLE [dbo].[TGameRCategory] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GameId] int  NOT NULL,
    [ContentId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TCategory'
ALTER TABLE [dbo].[TCategory]
ADD CONSTRAINT [PK_TCategory]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TGame'
ALTER TABLE [dbo].[TGame]
ADD CONSTRAINT [PK_TGame]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TGameRCategory'
ALTER TABLE [dbo].[TGameRCategory]
ADD CONSTRAINT [PK_TGameRCategory]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [GameId] in table 'TGameRCategory'
ALTER TABLE [dbo].[TGameRCategory]
ADD CONSTRAINT [FK_游戏关联分类]
    FOREIGN KEY ([GameId])
    REFERENCES [dbo].[TGame]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_游戏关联分类'
CREATE INDEX [IX_FK_游戏关联分类]
ON [dbo].[TGameRCategory]
    ([GameId]);
GO

-- Creating foreign key on [ContentId] in table 'TGameRCategory'
ALTER TABLE [dbo].[TGameRCategory]
ADD CONSTRAINT [FK_分类关联游戏]
    FOREIGN KEY ([ContentId])
    REFERENCES [dbo].[TCategory]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_分类关联游戏'
CREATE INDEX [IX_FK_分类关联游戏]
ON [dbo].[TGameRCategory]
    ([ContentId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------