
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/19/2023 08:30:35
-- Generated from EDMX file: C:\Users\Saba\source\repos\sabay79\Employee-Review-Management-System\src\EmployeeReviewManagementSystem\EStar.WebApp\Models\ERMSModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EStarDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Employee_Department]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [FK_Employee_Department];
GO
IF OBJECT_ID(N'[dbo].[FK_Review_Answer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Review] DROP CONSTRAINT [FK_Review_Answer];
GO
IF OBJECT_ID(N'[dbo].[FK_Review_Category]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Review] DROP CONSTRAINT [FK_Review_Category];
GO
IF OBJECT_ID(N'[dbo].[FK_Review_Department]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Review] DROP CONSTRAINT [FK_Review_Department];
GO
IF OBJECT_ID(N'[dbo].[FK_Review_Employee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Review] DROP CONSTRAINT [FK_Review_Employee];
GO
IF OBJECT_ID(N'[dbo].[FK_Review_Question]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Review] DROP CONSTRAINT [FK_Review_Question];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Answer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Answer];
GO
IF OBJECT_ID(N'[dbo].[Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category];
GO
IF OBJECT_ID(N'[dbo].[Department]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Department];
GO
IF OBJECT_ID(N'[dbo].[Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employee];
GO
IF OBJECT_ID(N'[dbo].[Question]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Question];
GO
IF OBJECT_ID(N'[dbo].[Review]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Review];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Answers'
CREATE TABLE [dbo].[Answers] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Answer1] nvarchar(max)  NOT NULL,
    [Score] int  NOT NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Category1] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Gender] nvarchar(max)  NOT NULL,
    [Designation] nvarchar(max)  NOT NULL,
    [DepartmentID] int  NOT NULL,
    [YearsOfExperience] int  NULL,
    [Salary] int  NULL,
    [City] nvarchar(max)  NULL,
    [Country] nvarchar(max)  NULL,
    [Username] nvarchar(max)  NULL,
    [Password] nvarchar(max)  NULL
);
GO

-- Creating table 'Questions'
CREATE TABLE [dbo].[Questions] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Question1] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Reviews'
CREATE TABLE [dbo].[Reviews] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [DepartmentID] int  NOT NULL,
    [EmployeeID] int  NOT NULL,
    [CategoryID] int  NULL,
    [QuestionID] int  NOT NULL,
    [AnswerID] int  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Answers'
ALTER TABLE [dbo].[Answers]
ADD CONSTRAINT [PK_Answers]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [PK_Questions]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [PK_Reviews]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AnswerID] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [FK_Review_Answer]
    FOREIGN KEY ([AnswerID])
    REFERENCES [dbo].[Answers]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Review_Answer'
CREATE INDEX [IX_FK_Review_Answer]
ON [dbo].[Reviews]
    ([AnswerID]);
GO

-- Creating foreign key on [CategoryID] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [FK_Review_Category]
    FOREIGN KEY ([CategoryID])
    REFERENCES [dbo].[Categories]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Review_Category'
CREATE INDEX [IX_FK_Review_Category]
ON [dbo].[Reviews]
    ([CategoryID]);
GO

-- Creating foreign key on [DepartmentID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_Employee_Department]
    FOREIGN KEY ([DepartmentID])
    REFERENCES [dbo].[Departments]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Employee_Department'
CREATE INDEX [IX_FK_Employee_Department]
ON [dbo].[Employees]
    ([DepartmentID]);
GO

-- Creating foreign key on [DepartmentID] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [FK_Review_Department]
    FOREIGN KEY ([DepartmentID])
    REFERENCES [dbo].[Departments]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Review_Department'
CREATE INDEX [IX_FK_Review_Department]
ON [dbo].[Reviews]
    ([DepartmentID]);
GO

-- Creating foreign key on [EmployeeID] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [FK_Review_Employee]
    FOREIGN KEY ([EmployeeID])
    REFERENCES [dbo].[Employees]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Review_Employee'
CREATE INDEX [IX_FK_Review_Employee]
ON [dbo].[Reviews]
    ([EmployeeID]);
GO

-- Creating foreign key on [QuestionID] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [FK_Review_Question]
    FOREIGN KEY ([QuestionID])
    REFERENCES [dbo].[Questions]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Review_Question'
CREATE INDEX [IX_FK_Review_Question]
ON [dbo].[Reviews]
    ([QuestionID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------