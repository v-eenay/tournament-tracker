USE [master]
GO

-- Create the Tournaments database if it doesn't exist
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Tournaments')
BEGIN
    CREATE DATABASE [Tournaments]
END
GO

USE [Tournaments]
GO

-- Create the Prizes table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Prizes]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Prizes](
        [id] [int] IDENTITY(1,1) NOT NULL,
        [PlaceNumber] [int] NOT NULL,
        [PlaceName] [nvarchar](50) NOT NULL,
        [PrizeAmount] [money] NOT NULL,
        [PrizePercentage] [float] NOT NULL,
        CONSTRAINT [PK_Prizes] PRIMARY KEY CLUSTERED 
        (
            [id] ASC
        )
    )
END
GO

-- Create the stored procedure for inserting prizes
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spPrizes_Insert]') AND type in (N'P'))
BEGIN
    EXEC dbo.sp_executesql @statement = N'
    CREATE PROCEDURE [dbo].[spPrizes_Insert]
        @PlaceNumber int,
        @PlaceName nvarchar(50),
        @PrizeAmount money,
        @PrizePercentage float,
        @id int = 0 output
    AS
    BEGIN
        SET NOCOUNT ON;
        
        INSERT INTO dbo.Prizes (PlaceNumber, PlaceName, PrizeAmount, PrizePercentage)
        VALUES (@PlaceNumber, @PlaceName, @PrizeAmount, @PrizePercentage);
        
        SELECT @id = SCOPE_IDENTITY();
    END
    '
END
GO

-- Create the People table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[People]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[People](
        [id] [int] IDENTITY(1,1) NOT NULL,
        [FirstName] [nvarchar](100) NOT NULL,
        [LastName] [nvarchar](100) NOT NULL,
        [EmailAddress] [nvarchar](200) NOT NULL,
        [CellphoneNumber] [nvarchar](20) NULL,
        CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
        (
            [id] ASC
        )
    )
END
GO

-- Create the Teams table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Teams]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Teams](
        [id] [int] IDENTITY(1,1) NOT NULL,
        [TeamName] [nvarchar](100) NOT NULL,
        CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
        (
            [id] ASC
        )
    )
END
GO

-- Create the TeamMembers table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TeamMembers]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[TeamMembers](
        [id] [int] IDENTITY(1,1) NOT NULL,
        [TeamId] [int] NOT NULL,
        [PersonId] [int] NOT NULL,
        CONSTRAINT [PK_TeamMembers] PRIMARY KEY CLUSTERED 
        (
            [id] ASC
        ),
        CONSTRAINT [FK_TeamMembers_People] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[People] ([id]),
        CONSTRAINT [FK_TeamMembers_Teams] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Teams] ([id])
    )
END
GO

-- Create the Tournaments table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tournaments]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Tournaments](
        [id] [int] IDENTITY(1,1) NOT NULL,
        [TournamentName] [nvarchar](200) NOT NULL,
        [EntryFee] [money] NOT NULL,
        [Active] [bit] NOT NULL,
        CONSTRAINT [PK_Tournaments] PRIMARY KEY CLUSTERED 
        (
            [id] ASC
        )
    )
END
GO

-- Create the TournamentPrizes table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TournamentPrizes]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[TournamentPrizes](
        [id] [int] IDENTITY(1,1) NOT NULL,
        [TournamentId] [int] NOT NULL,
        [PrizeId] [int] NOT NULL,
        CONSTRAINT [PK_TournamentPrizes] PRIMARY KEY CLUSTERED 
        (
            [id] ASC
        ),
        CONSTRAINT [FK_TournamentPrizes_Prizes] FOREIGN KEY ([PrizeId]) REFERENCES [dbo].[Prizes] ([id]),
        CONSTRAINT [FK_TournamentPrizes_Tournaments] FOREIGN KEY ([TournamentId]) REFERENCES [dbo].[Tournaments] ([id])
    )
END
GO

-- Create the TournamentEntries table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TournamentEntries]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[TournamentEntries](
        [id] [int] IDENTITY(1,1) NOT NULL,
        [TournamentId] [int] NOT NULL,
        [TeamId] [int] NOT NULL,
        CONSTRAINT [PK_TournamentEntries] PRIMARY KEY CLUSTERED 
        (
            [id] ASC
        ),
        CONSTRAINT [FK_TournamentEntries_Teams] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Teams] ([id]),
        CONSTRAINT [FK_TournamentEntries_Tournaments] FOREIGN KEY ([TournamentId]) REFERENCES [dbo].[Tournaments] ([id])
    )
END
GO

-- Create the MatchupRounds table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MatchupRounds]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[MatchupRounds](
        [id] [int] IDENTITY(1,1) NOT NULL,
        [TournamentId] [int] NOT NULL,
        [RoundNumber] [int] NOT NULL,
        CONSTRAINT [PK_MatchupRounds] PRIMARY KEY CLUSTERED 
        (
            [id] ASC
        ),
        CONSTRAINT [FK_MatchupRounds_Tournaments] FOREIGN KEY ([TournamentId]) REFERENCES [dbo].[Tournaments] ([id])
    )
END
GO

-- Create the Matchups table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Matchups]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Matchups](
        [id] [int] IDENTITY(1,1) NOT NULL,
        [RoundId] [int] NOT NULL,
        [WinnerId] [int] NULL,
        CONSTRAINT [PK_Matchups] PRIMARY KEY CLUSTERED 
        (
            [id] ASC
        ),
        CONSTRAINT [FK_Matchups_MatchupRounds] FOREIGN KEY ([RoundId]) REFERENCES [dbo].[MatchupRounds] ([id]),
        CONSTRAINT [FK_Matchups_Teams] FOREIGN KEY ([WinnerId]) REFERENCES [dbo].[Teams] ([id])
    )
END
GO

-- Create the MatchupEntries table if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MatchupEntries]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[MatchupEntries](
        [id] [int] IDENTITY(1,1) NOT NULL,
        [MatchupId] [int] NOT NULL,
        [TeamId] [int] NOT NULL,
        [Score] [float] NULL,
        [ParentMatchupId] [int] NULL,
        CONSTRAINT [PK_MatchupEntries] PRIMARY KEY CLUSTERED 
        (
            [id] ASC
        ),
        CONSTRAINT [FK_MatchupEntries_Matchups] FOREIGN KEY ([MatchupId]) REFERENCES [dbo].[Matchups] ([id]),
        CONSTRAINT [FK_MatchupEntries_Teams] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Teams] ([id]),
        CONSTRAINT [FK_MatchupEntries_ParentMatchups] FOREIGN KEY ([ParentMatchupId]) REFERENCES [dbo].[Matchups] ([id])
    )
END
GO

PRINT 'Database setup completed successfully.'
