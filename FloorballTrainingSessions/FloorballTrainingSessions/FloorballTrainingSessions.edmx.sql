
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/11/2017 21:12:38
-- Generated from EDMX file: C:\Users\k\Documents\GitHub\git\FloorballTrainingSessions\FloorballTrainingSessions\FloorballTrainingSessions.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-FloorballTrainingSessions-10e79e49-b34c-4674-a34f-782796876bcd];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO



-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------



-- Creating table 'ExcersiseBelongsToCategory'
CREATE TABLE [dbo].[ExcersiseBelongsToCategory] (
    [Id] int  NOT NULL,
    [Excersise] int  NOT NULL,
    [ExcersiseCategory] int  NOT NULL
);
GO

-- Creating table 'ExcersiseBelongsToSeasonParts'
CREATE TABLE [dbo].[ExcersiseBelongsToSeasonParts] (
    [Id] int  NOT NULL,
    [Excersise] int  NOT NULL,
    [SeasonPart] int  NOT NULL
);
GO

-- Creating table 'ExcersiseCategories'
CREATE TABLE [dbo].[ExcersiseCategories] (
    [Id] int  NOT NULL,
    [ExcersiseCategoryName] varchar(50)  NOT NULL
);
GO

-- Creating table 'Excersises'
CREATE TABLE [dbo].[Excersises] (
    [Id] int  NOT NULL,
    [ExcersiseName] varchar(50)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Image] varbinary(max)  NULL
);
GO

-- Creating table 'PlayerFunctions'
CREATE TABLE [dbo].[PlayerFunctions] (
    [Id] int  NOT NULL,
    [PlayerFunctionName] varchar(50)  NOT NULL,
    [IsPlayer] bit  NOT NULL,
    [IsGoalie] bit  NOT NULL,
    [IsTrainer] bit  NOT NULL,
    [IsManager] bit  NOT NULL
);
GO

-- Creating table 'Players'
CREATE TABLE [dbo].[Players] (
    [Id] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [User] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'PlayerSigningToTrainings'
CREATE TABLE [dbo].[PlayerSigningToTrainings] (
    [Id] int  NOT NULL,
    [Training] int  NOT NULL,
    [Player] int  NOT NULL,
    [Status] bit  NOT NULL,
    [PlayerSignedDate] binary(8)  NOT NULL
);
GO

-- Creating table 'SeasonParts'
CREATE TABLE [dbo].[SeasonParts] (
    [Id] int  NOT NULL,
    [SeasonPartName] varchar(50)  NOT NULL
);
GO

-- Creating table 'Seasons'
CREATE TABLE [dbo].[Seasons] (
    [Id] int  NOT NULL,
    [SeasonName] varchar(50)  NOT NULL,
    [IsActiveSeason] bit  NOT NULL
);
GO

-- Creating table 'TeamPlayers'
CREATE TABLE [dbo].[TeamPlayers] (
    [Id] int  NOT NULL,
    [Team] int  NOT NULL,
    [Player] int  NOT NULL,
    [PlayerFunction] int  NOT NULL,
    [Season] int  NOT NULL
);
GO

-- Creating table 'Teams'
CREATE TABLE [dbo].[Teams] (
    [Id] int  NOT NULL,
    [TeamName] varchar(50)  NOT NULL
);
GO

-- Creating table 'TrainingExcersises'
CREATE TABLE [dbo].[TrainingExcersises] (
    [Id] int  NOT NULL,
    [Training] int  NOT NULL,
    [Excersise] int  NOT NULL,
    [TrainingSchemePartModel] int  NULL
);
GO

-- Creating table 'TrainingFocuses'
CREATE TABLE [dbo].[TrainingFocuses] (
    [Id] int  NOT NULL,
    [TrainingFocusName] varchar(50)  NOT NULL,
    [SeasonPart] int  NOT NULL
);
GO

-- Creating table 'TrainingLocations'
CREATE TABLE [dbo].[TrainingLocations] (
    [Id] int  NOT NULL,
    [TrainingLocationName] varchar(50)  NOT NULL,
    [PricePerHour] float  NOT NULL,
    [Description] varchar(max)  NULL,
    [Inner] bit  NOT NULL
);
GO

-- Creating table 'Trainings'
CREATE TABLE [dbo].[Trainings] (
    [Id] int  NOT NULL,
    [TrainingDate] datetime  NOT NULL,
    [MeetDate] datetime  NOT NULL,
    [SigningLimitDate] datetime  NOT NULL,
    [TrainingLocation] int  NOT NULL,
    [Team] int  NOT NULL,
    [Season] int  NOT NULL,
    [SeasonPart] int  NOT NULL,
    [TrainingFocus] int  NOT NULL,
    [TrainingSchemeModel] int  NULL,
    [TrainingLength] float  NOT NULL,
    [PublishTraining] bit  NOT NULL,
    [PublishExcersises] bit  NOT NULL
);
GO

-- Creating table 'TrainingSchemeModels'
CREATE TABLE [dbo].[TrainingSchemeModels] (
    [Id] int  NOT NULL,
    [TrainingSchemeName] varchar(50)  NOT NULL,
    [SeasonPart] int  NOT NULL
);
GO

-- Creating table 'TrainingSchemePartModels'
CREATE TABLE [dbo].[TrainingSchemePartModels] (
    [Id] int  NOT NULL,
    [TrainingSchemeModel] int  NOT NULL,
    [ExcersiseCategory] int  NOT NULL,
    [PartLength] varchar(50)  NOT NULL,
    [NumberOfExcersises] int  NULL,
    [Series] int  NULL,
    [SeriesLength] varchar(50)  NULL,
    [RestBetweenSeries] varchar(50)  NULL,
    [RestBetweenExcersises] varchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ExcersiseBelongsToCategory'
ALTER TABLE [dbo].[ExcersiseBelongsToCategory]
ADD CONSTRAINT [PK_ExcersiseBelongsToCategory]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ExcersiseBelongsToSeasonParts'
ALTER TABLE [dbo].[ExcersiseBelongsToSeasonParts]
ADD CONSTRAINT [PK_ExcersiseBelongsToSeasonParts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ExcersiseCategories'
ALTER TABLE [dbo].[ExcersiseCategories]
ADD CONSTRAINT [PK_ExcersiseCategories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Excersises'
ALTER TABLE [dbo].[Excersises]
ADD CONSTRAINT [PK_Excersises]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlayerFunctions'
ALTER TABLE [dbo].[PlayerFunctions]
ADD CONSTRAINT [PK_PlayerFunctions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Players'
ALTER TABLE [dbo].[Players]
ADD CONSTRAINT [PK_Players]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlayerSigningToTrainings'
ALTER TABLE [dbo].[PlayerSigningToTrainings]
ADD CONSTRAINT [PK_PlayerSigningToTrainings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SeasonParts'
ALTER TABLE [dbo].[SeasonParts]
ADD CONSTRAINT [PK_SeasonParts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Seasons'
ALTER TABLE [dbo].[Seasons]
ADD CONSTRAINT [PK_Seasons]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TeamPlayers'
ALTER TABLE [dbo].[TeamPlayers]
ADD CONSTRAINT [PK_TeamPlayers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [PK_Teams]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TrainingExcersises'
ALTER TABLE [dbo].[TrainingExcersises]
ADD CONSTRAINT [PK_TrainingExcersises]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TrainingFocuses'
ALTER TABLE [dbo].[TrainingFocuses]
ADD CONSTRAINT [PK_TrainingFocuses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TrainingLocations'
ALTER TABLE [dbo].[TrainingLocations]
ADD CONSTRAINT [PK_TrainingLocations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Trainings'
ALTER TABLE [dbo].[Trainings]
ADD CONSTRAINT [PK_Trainings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TrainingSchemeModels'
ALTER TABLE [dbo].[TrainingSchemeModels]
ADD CONSTRAINT [PK_TrainingSchemeModels]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TrainingSchemePartModels'
ALTER TABLE [dbo].[TrainingSchemePartModels]
ADD CONSTRAINT [PK_TrainingSchemePartModels]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User] in table 'Players'
ALTER TABLE [dbo].[Players]
ADD CONSTRAINT [FK_Players_ToUsers]
    FOREIGN KEY ([User])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Players_ToUsers'
CREATE INDEX [IX_FK_Players_ToUsers]
ON [dbo].[Players]
    ([User]);
GO

-- Creating foreign key on [ExcersiseCategory] in table 'ExcersiseBelongsToCategory'
ALTER TABLE [dbo].[ExcersiseBelongsToCategory]
ADD CONSTRAINT [FK_ExcersiseBelongsToCategory_ToExcersiseCategories]
    FOREIGN KEY ([ExcersiseCategory])
    REFERENCES [dbo].[ExcersiseCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExcersiseBelongsToCategory_ToExcersiseCategories'
CREATE INDEX [IX_FK_ExcersiseBelongsToCategory_ToExcersiseCategories]
ON [dbo].[ExcersiseBelongsToCategory]
    ([ExcersiseCategory]);
GO

-- Creating foreign key on [Excersise] in table 'ExcersiseBelongsToCategory'
ALTER TABLE [dbo].[ExcersiseBelongsToCategory]
ADD CONSTRAINT [FK_ExcersiseBelongsToCategory_ToExcersises]
    FOREIGN KEY ([Excersise])
    REFERENCES [dbo].[Excersises]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExcersiseBelongsToCategory_ToExcersises'
CREATE INDEX [IX_FK_ExcersiseBelongsToCategory_ToExcersises]
ON [dbo].[ExcersiseBelongsToCategory]
    ([Excersise]);
GO

-- Creating foreign key on [Excersise] in table 'ExcersiseBelongsToSeasonParts'
ALTER TABLE [dbo].[ExcersiseBelongsToSeasonParts]
ADD CONSTRAINT [FK_ExcersiseBelongsToSeasonParts_ToExcersises]
    FOREIGN KEY ([Excersise])
    REFERENCES [dbo].[Excersises]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExcersiseBelongsToSeasonParts_ToExcersises'
CREATE INDEX [IX_FK_ExcersiseBelongsToSeasonParts_ToExcersises]
ON [dbo].[ExcersiseBelongsToSeasonParts]
    ([Excersise]);
GO

-- Creating foreign key on [SeasonPart] in table 'ExcersiseBelongsToSeasonParts'
ALTER TABLE [dbo].[ExcersiseBelongsToSeasonParts]
ADD CONSTRAINT [FK_ExcersiseBelongsToSeasonParts_ToSeasonParts]
    FOREIGN KEY ([SeasonPart])
    REFERENCES [dbo].[SeasonParts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExcersiseBelongsToSeasonParts_ToSeasonParts'
CREATE INDEX [IX_FK_ExcersiseBelongsToSeasonParts_ToSeasonParts]
ON [dbo].[ExcersiseBelongsToSeasonParts]
    ([SeasonPart]);
GO

-- Creating foreign key on [ExcersiseCategory] in table 'TrainingSchemePartModels'
ALTER TABLE [dbo].[TrainingSchemePartModels]
ADD CONSTRAINT [FK_TrainingSchemePartModels_ToExcersiseCategories]
    FOREIGN KEY ([ExcersiseCategory])
    REFERENCES [dbo].[ExcersiseCategories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TrainingSchemePartModels_ToExcersiseCategories'
CREATE INDEX [IX_FK_TrainingSchemePartModels_ToExcersiseCategories]
ON [dbo].[TrainingSchemePartModels]
    ([ExcersiseCategory]);
GO

-- Creating foreign key on [Excersise] in table 'TrainingExcersises'
ALTER TABLE [dbo].[TrainingExcersises]
ADD CONSTRAINT [FK_TrainingExcersises_ToExcersises]
    FOREIGN KEY ([Excersise])
    REFERENCES [dbo].[Excersises]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TrainingExcersises_ToExcersises'
CREATE INDEX [IX_FK_TrainingExcersises_ToExcersises]
ON [dbo].[TrainingExcersises]
    ([Excersise]);
GO

-- Creating foreign key on [PlayerFunction] in table 'TeamPlayers'
ALTER TABLE [dbo].[TeamPlayers]
ADD CONSTRAINT [FK_TeamPlayers_ToPlayerFunctions]
    FOREIGN KEY ([PlayerFunction])
    REFERENCES [dbo].[PlayerFunctions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamPlayers_ToPlayerFunctions'
CREATE INDEX [IX_FK_TeamPlayers_ToPlayerFunctions]
ON [dbo].[TeamPlayers]
    ([PlayerFunction]);
GO

-- Creating foreign key on [Player] in table 'PlayerSigningToTrainings'
ALTER TABLE [dbo].[PlayerSigningToTrainings]
ADD CONSTRAINT [FK_PlayerSigningToTrainings_ToPlayers]
    FOREIGN KEY ([Player])
    REFERENCES [dbo].[Players]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerSigningToTrainings_ToPlayers'
CREATE INDEX [IX_FK_PlayerSigningToTrainings_ToPlayers]
ON [dbo].[PlayerSigningToTrainings]
    ([Player]);
GO

-- Creating foreign key on [Player] in table 'TeamPlayers'
ALTER TABLE [dbo].[TeamPlayers]
ADD CONSTRAINT [FK_TeamPlayers_ToPlayers]
    FOREIGN KEY ([Player])
    REFERENCES [dbo].[Players]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamPlayers_ToPlayers'
CREATE INDEX [IX_FK_TeamPlayers_ToPlayers]
ON [dbo].[TeamPlayers]
    ([Player]);
GO

-- Creating foreign key on [Training] in table 'PlayerSigningToTrainings'
ALTER TABLE [dbo].[PlayerSigningToTrainings]
ADD CONSTRAINT [FK_PlayerSigningToTrainings_ToTrainings]
    FOREIGN KEY ([Training])
    REFERENCES [dbo].[Trainings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayerSigningToTrainings_ToTrainings'
CREATE INDEX [IX_FK_PlayerSigningToTrainings_ToTrainings]
ON [dbo].[PlayerSigningToTrainings]
    ([Training]);
GO

-- Creating foreign key on [SeasonPart] in table 'TrainingFocuses'
ALTER TABLE [dbo].[TrainingFocuses]
ADD CONSTRAINT [FK_TrainingFocuses_ToSeasonParts]
    FOREIGN KEY ([SeasonPart])
    REFERENCES [dbo].[SeasonParts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TrainingFocuses_ToSeasonParts'
CREATE INDEX [IX_FK_TrainingFocuses_ToSeasonParts]
ON [dbo].[TrainingFocuses]
    ([SeasonPart]);
GO

-- Creating foreign key on [SeasonPart] in table 'Trainings'
ALTER TABLE [dbo].[Trainings]
ADD CONSTRAINT [FK_Trainings_ToSeasonParts]
    FOREIGN KEY ([SeasonPart])
    REFERENCES [dbo].[SeasonParts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Trainings_ToSeasonParts'
CREATE INDEX [IX_FK_Trainings_ToSeasonParts]
ON [dbo].[Trainings]
    ([SeasonPart]);
GO

-- Creating foreign key on [SeasonPart] in table 'TrainingSchemeModels'
ALTER TABLE [dbo].[TrainingSchemeModels]
ADD CONSTRAINT [FK_TrainingSchemeModels_ToSeasonParts]
    FOREIGN KEY ([SeasonPart])
    REFERENCES [dbo].[SeasonParts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TrainingSchemeModels_ToSeasonParts'
CREATE INDEX [IX_FK_TrainingSchemeModels_ToSeasonParts]
ON [dbo].[TrainingSchemeModels]
    ([SeasonPart]);
GO

-- Creating foreign key on [Season] in table 'TeamPlayers'
ALTER TABLE [dbo].[TeamPlayers]
ADD CONSTRAINT [FK_TeamPlayers_ToSeason]
    FOREIGN KEY ([Season])
    REFERENCES [dbo].[Seasons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamPlayers_ToSeason'
CREATE INDEX [IX_FK_TeamPlayers_ToSeason]
ON [dbo].[TeamPlayers]
    ([Season]);
GO

-- Creating foreign key on [Season] in table 'Trainings'
ALTER TABLE [dbo].[Trainings]
ADD CONSTRAINT [FK_Trainings_ToSeasons]
    FOREIGN KEY ([Season])
    REFERENCES [dbo].[Seasons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Trainings_ToSeasons'
CREATE INDEX [IX_FK_Trainings_ToSeasons]
ON [dbo].[Trainings]
    ([Season]);
GO

-- Creating foreign key on [Team] in table 'TeamPlayers'
ALTER TABLE [dbo].[TeamPlayers]
ADD CONSTRAINT [FK_TeamPlayers_ToTeams]
    FOREIGN KEY ([Team])
    REFERENCES [dbo].[Teams]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamPlayers_ToTeams'
CREATE INDEX [IX_FK_TeamPlayers_ToTeams]
ON [dbo].[TeamPlayers]
    ([Team]);
GO

-- Creating foreign key on [Team] in table 'Trainings'
ALTER TABLE [dbo].[Trainings]
ADD CONSTRAINT [FK_Trainings_ToTeams]
    FOREIGN KEY ([Team])
    REFERENCES [dbo].[Teams]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Trainings_ToTeams'
CREATE INDEX [IX_FK_Trainings_ToTeams]
ON [dbo].[Trainings]
    ([Team]);
GO

-- Creating foreign key on [Training] in table 'TrainingExcersises'
ALTER TABLE [dbo].[TrainingExcersises]
ADD CONSTRAINT [FK_TrainingExcersises_ToTrainings]
    FOREIGN KEY ([Training])
    REFERENCES [dbo].[Trainings]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TrainingExcersises_ToTrainings'
CREATE INDEX [IX_FK_TrainingExcersises_ToTrainings]
ON [dbo].[TrainingExcersises]
    ([Training]);
GO

-- Creating foreign key on [TrainingSchemePartModel] in table 'TrainingExcersises'
ALTER TABLE [dbo].[TrainingExcersises]
ADD CONSTRAINT [FK_TrainingExcersises_ToTrainingSchemePartModels]
    FOREIGN KEY ([TrainingSchemePartModel])
    REFERENCES [dbo].[TrainingSchemePartModels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TrainingExcersises_ToTrainingSchemePartModels'
CREATE INDEX [IX_FK_TrainingExcersises_ToTrainingSchemePartModels]
ON [dbo].[TrainingExcersises]
    ([TrainingSchemePartModel]);
GO

-- Creating foreign key on [TrainingFocus] in table 'Trainings'
ALTER TABLE [dbo].[Trainings]
ADD CONSTRAINT [FK_Trainings_ToTraningFocuses]
    FOREIGN KEY ([TrainingFocus])
    REFERENCES [dbo].[TrainingFocuses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Trainings_ToTraningFocuses'
CREATE INDEX [IX_FK_Trainings_ToTraningFocuses]
ON [dbo].[Trainings]
    ([TrainingFocus]);
GO

-- Creating foreign key on [TrainingLocation] in table 'Trainings'
ALTER TABLE [dbo].[Trainings]
ADD CONSTRAINT [FK_Trainings_ToTrainingLocations]
    FOREIGN KEY ([TrainingLocation])
    REFERENCES [dbo].[TrainingLocations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Trainings_ToTrainingLocations'
CREATE INDEX [IX_FK_Trainings_ToTrainingLocations]
ON [dbo].[Trainings]
    ([TrainingLocation]);
GO

-- Creating foreign key on [TrainingSchemeModel] in table 'Trainings'
ALTER TABLE [dbo].[Trainings]
ADD CONSTRAINT [FK_Trainings_ToTrainingSchemeModels]
    FOREIGN KEY ([TrainingSchemeModel])
    REFERENCES [dbo].[TrainingSchemeModels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Trainings_ToTrainingSchemeModels'
CREATE INDEX [IX_FK_Trainings_ToTrainingSchemeModels]
ON [dbo].[Trainings]
    ([TrainingSchemeModel]);
GO

-- Creating foreign key on [TrainingSchemeModel] in table 'TrainingSchemePartModels'
ALTER TABLE [dbo].[TrainingSchemePartModels]
ADD CONSTRAINT [FK_TrainingSchemePartModels_ToTrainingScheme]
    FOREIGN KEY ([TrainingSchemeModel])
    REFERENCES [dbo].[TrainingSchemeModels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TrainingSchemePartModels_ToTrainingScheme'
CREATE INDEX [IX_FK_TrainingSchemePartModels_ToTrainingScheme]
ON [dbo].[TrainingSchemePartModels]
    ([TrainingSchemeModel]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------