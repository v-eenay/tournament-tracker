-- Create the Tournaments database if it doesn't exist
CREATE DATABASE IF NOT EXISTS Tournaments;

USE Tournaments;

-- Create the Prizes table if it doesn't exist
CREATE TABLE IF NOT EXISTS Prizes(
    id INT AUTO_INCREMENT NOT NULL,
    PlaceNumber INT NOT NULL,
    PlaceName VARCHAR(50) NOT NULL,
    PrizeAmount DECIMAL(19,4) NOT NULL,
    PrizePercentage DOUBLE NOT NULL,
    PRIMARY KEY (id)
);

-- Create the stored procedure for inserting prizes
DROP PROCEDURE IF EXISTS spPrizes_Insert;
DELIMITER $$
CREATE PROCEDURE spPrizes_Insert(
    IN p_PlaceNumber INT,
    IN p_PlaceName VARCHAR(50),
    IN p_PrizeAmount DECIMAL(19,4),
    IN p_PrizePercentage DOUBLE,
    OUT p_id INT
)
BEGIN
    INSERT INTO Prizes (PlaceNumber, PlaceName, PrizeAmount, PrizePercentage)
    VALUES (p_PlaceNumber, p_PlaceName, p_PrizeAmount, p_PrizePercentage);
    
    SET p_id = LAST_INSERT_ID();
END$$
DELIMITER ;

-- Create the People table if it doesn't exist
CREATE TABLE IF NOT EXISTS People(
    id INT AUTO_INCREMENT NOT NULL,
    FirstName VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
    EmailAddress VARCHAR(200) NOT NULL,
    CellphoneNumber VARCHAR(20) NULL,
    PRIMARY KEY (id)
);

-- Create the Teams table if it doesn't exist
CREATE TABLE IF NOT EXISTS Teams(
    id INT AUTO_INCREMENT NOT NULL,
    TeamName VARCHAR(100) NOT NULL,
    PRIMARY KEY (id)
);

-- Create the TeamMembers table if it doesn't exist
CREATE TABLE IF NOT EXISTS TeamMembers(
    id INT AUTO_INCREMENT NOT NULL,
    TeamId INT NOT NULL,
    PersonId INT NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (PersonId) REFERENCES People (id),
    FOREIGN KEY (TeamId) REFERENCES Teams (id)
);

-- Create the Tournaments table if it doesn't exist
CREATE TABLE IF NOT EXISTS Tournaments(
    id INT AUTO_INCREMENT NOT NULL,
    TournamentName VARCHAR(200) NOT NULL,
    EntryFee DECIMAL(19,4) NOT NULL,
    Active BOOLEAN NOT NULL DEFAULT TRUE, -- Changed from bit to BOOLEAN, added default
    PRIMARY KEY (id)
);

-- Create the TournamentPrizes table if it doesn't exist
CREATE TABLE IF NOT EXISTS TournamentPrizes(
    id INT AUTO_INCREMENT NOT NULL,
    TournamentId INT NOT NULL,
    PrizeId INT NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (PrizeId) REFERENCES Prizes (id),
    FOREIGN KEY (TournamentId) REFERENCES Tournaments (id)
);

-- Create the TournamentEntries table if it doesn't exist
CREATE TABLE IF NOT EXISTS TournamentEntries(
    id INT AUTO_INCREMENT NOT NULL,
    TournamentId INT NOT NULL,
    TeamId INT NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (TeamId) REFERENCES Teams (id),
    FOREIGN KEY (TournamentId) REFERENCES Tournaments (id)
);

-- Create the MatchupRounds table (assuming this was intended, T-SQL had MatchupRounds)
-- If MatchupRounds was a typo and meant Rounds, adjust accordingly.
-- For now, keeping it as MatchupRounds as per original T-SQL structure.
CREATE TABLE IF NOT EXISTS MatchupRounds(
    id INT AUTO_INCREMENT NOT NULL,
    TournamentId INT NOT NULL,
    RoundNumber INT NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (TournamentId) REFERENCES Tournaments (id)
);

-- Create the Matchups table if it doesn't exist
CREATE TABLE IF NOT EXISTS Matchups(
    id INT AUTO_INCREMENT NOT NULL,
    RoundId INT NOT NULL, -- Assuming this refers to MatchupRounds.id
    WinnerId INT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (RoundId) REFERENCES MatchupRounds (id),
    FOREIGN KEY (WinnerId) REFERENCES Teams (id)
);

-- Create the MatchupEntries table if it doesn't exist
CREATE TABLE IF NOT EXISTS MatchupEntries(
    id INT AUTO_INCREMENT NOT NULL,
    MatchupId INT NOT NULL,
    TeamId INT NOT NULL,
    Score DOUBLE NULL,
    ParentMatchupId INT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (MatchupId) REFERENCES Matchups (id),
    FOREIGN KEY (TeamId) REFERENCES Teams (id),
    FOREIGN KEY (ParentMatchupId) REFERENCES Matchups (id)
);

-- Stored Procedures for People
DROP PROCEDURE IF EXISTS spPeople_Insert;
DELIMITER $$
CREATE PROCEDURE spPeople_Insert(
    IN p_FirstName VARCHAR(100),
    IN p_LastName VARCHAR(100),
    IN p_EmailAddress VARCHAR(200),
    IN p_CellphoneNumber VARCHAR(20),
    OUT p_id INT
)
BEGIN
    INSERT INTO People (FirstName, LastName, EmailAddress, CellphoneNumber)
    VALUES (p_FirstName, p_LastName, p_EmailAddress, p_CellphoneNumber);
    SET p_id = LAST_INSERT_ID();
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS spPeople_GetAll;
DELIMITER $$
CREATE PROCEDURE spPeople_GetAll()
BEGIN
    SELECT * FROM People;
END$$
DELIMITER ;

-- Stored Procedures for Teams
DROP PROCEDURE IF EXISTS spTeams_Insert;
DELIMITER $$
CREATE PROCEDURE spTeams_Insert(
    IN p_TeamName VARCHAR(100),
    OUT p_id INT
)
BEGIN
    INSERT INTO Teams (TeamName)
    VALUES (p_TeamName);
    SET p_id = LAST_INSERT_ID();
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS spTeamMembers_Insert;
DELIMITER $$
CREATE PROCEDURE spTeamMembers_Insert(
    IN p_TeamId INT,
    IN p_PersonId INT,
    OUT p_id INT
)
BEGIN
    INSERT INTO TeamMembers (TeamId, PersonId)
    VALUES (p_TeamId, p_PersonId);
    SET p_id = LAST_INSERT_ID();
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS spTeams_GetAll;
DELIMITER $$
CREATE PROCEDURE spTeams_GetAll()
BEGIN
    SELECT * FROM Teams;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS spTeamMembers_GetByTeam;
DELIMITER $$
CREATE PROCEDURE spTeamMembers_GetByTeam(
    IN p_TeamId INT
)
BEGIN
    SELECT p.*
    FROM TeamMembers tm
    INNER JOIN People p ON tm.PersonId = p.id
    WHERE tm.TeamId = p_TeamId;
END$$
DELIMITER ;

-- Stored Procedures for Tournaments
DROP PROCEDURE IF EXISTS spTournaments_Insert;
DELIMITER $$
CREATE PROCEDURE spTournaments_Insert(
    IN p_TournamentName VARCHAR(200),
    IN p_EntryFee DECIMAL(19,4),
    OUT p_id INT
)
BEGIN
    INSERT INTO Tournaments (TournamentName, EntryFee, Active)
    VALUES (p_TournamentName, p_EntryFee, TRUE);
    SET p_id = LAST_INSERT_ID();
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS spTournamentPrizes_Insert;
DELIMITER $$
CREATE PROCEDURE spTournamentPrizes_Insert(
    IN p_TournamentId INT,
    IN p_PrizeId INT
)
BEGIN
    INSERT INTO TournamentPrizes (TournamentId, PrizeId)
    VALUES (p_TournamentId, p_PrizeId);
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS spTournamentEntries_Insert;
DELIMITER $$
CREATE PROCEDURE spTournamentEntries_Insert(
    IN p_TournamentId INT,
    IN p_TeamId INT
)
BEGIN
    INSERT INTO TournamentEntries (TournamentId, TeamId)
    VALUES (p_TournamentId, p_TeamId);
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS spTournaments_GetAll;
DELIMITER $$
CREATE PROCEDURE spTournaments_GetAll()
BEGIN
    SELECT * FROM Tournaments WHERE Active = TRUE;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS spPrizes_GetByTournament;
DELIMITER $$
CREATE PROCEDURE spPrizes_GetByTournament(
    IN p_TournamentId INT
)
BEGIN
    SELECT p.*
    FROM TournamentPrizes tp
    INNER JOIN Prizes p ON tp.PrizeId = p.id
    WHERE tp.TournamentId = p_TournamentId;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS spTeams_GetByTournament;
DELIMITER $$
CREATE PROCEDURE spTeams_GetByTournament(
    IN p_TournamentId INT
)
BEGIN
    SELECT t.*
    FROM TournamentEntries te
    INNER JOIN Teams t ON te.TeamId = t.id
    WHERE te.TournamentId = p_TournamentId;
END$$
DELIMITER ;

-- Stored Procedures for Matchups and MatchupEntries
DROP PROCEDURE IF EXISTS spMatchups_Insert;
DELIMITER $$
CREATE PROCEDURE spMatchups_Insert(
    IN p_RoundId INT,
    IN p_WinnerId INT,
    OUT p_id INT
)
BEGIN
    INSERT INTO Matchups (RoundId, WinnerId)
    VALUES (p_RoundId, p_WinnerId);
    SET p_id = LAST_INSERT_ID();
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS spMatchupEntries_Insert;
DELIMITER $$
CREATE PROCEDURE spMatchupEntries_Insert(
    IN p_MatchupId INT,
    IN p_TeamId INT,
    IN p_Score DOUBLE,
    IN p_ParentMatchupId INT,
    OUT p_id INT
)
BEGIN
    INSERT INTO MatchupEntries (MatchupId, TeamId, Score, ParentMatchupId)
    VALUES (p_MatchupId, p_TeamId, p_Score, p_ParentMatchupId);
    SET p_id = LAST_INSERT_ID();
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS spMatchups_GetByTournament;
DELIMITER $$
CREATE PROCEDURE spMatchups_GetByTournament(
    IN p_TournamentId INT
)
BEGIN
    SELECT m.* 
    FROM Matchups m
    INNER JOIN MatchupRounds mr ON m.RoundId = mr.id
    WHERE mr.TournamentId = p_TournamentId
    ORDER BY m.id;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS spMatchupEntries_GetByMatchup;
DELIMITER $$
CREATE PROCEDURE spMatchupEntries_GetByMatchup(
    IN p_MatchupId INT
)
BEGIN
    SELECT * 
    FROM MatchupEntries 
    WHERE MatchupId = p_MatchupId;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS spMatchupEntries_Update;
DELIMITER $$
CREATE PROCEDURE spMatchupEntries_Update(
    IN p_id INT,
    IN p_Score DOUBLE
)
BEGIN
    UPDATE MatchupEntries
    SET Score = p_Score
    WHERE id = p_id;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS spMatchups_Update;
DELIMITER $$
CREATE PROCEDURE spMatchups_Update(
    IN p_id INT,
    IN p_WinnerId INT
)
BEGIN
    UPDATE Matchups
    SET WinnerId = p_WinnerId
    WHERE id = p_id;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS spTournament_Complete;
DELIMITER $$
CREATE PROCEDURE spTournament_Complete(
    IN p_TournamentId INT
)
BEGIN
    UPDATE Tournaments
    SET Active = FALSE
    WHERE id = p_TournamentId;
END$$
DELIMITER ;

-- Create MatchupRounds (this was missing from original T-SQL but seems implied by Matchups table)
DROP PROCEDURE IF EXISTS spMatchupRounds_Insert;
DELIMITER $$
CREATE PROCEDURE spMatchupRounds_Insert(
    IN p_TournamentId INT,
    IN p_RoundNumber INT,
    OUT p_id INT
)
BEGIN
    INSERT INTO MatchupRounds (TournamentId, RoundNumber)
    VALUES (p_TournamentId, p_RoundNumber);
    SET p_id = LAST_INSERT_ID();
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS spMatchupRounds_GetByTournament;
DELIMITER $$
CREATE PROCEDURE spMatchupRounds_GetByTournament(
    IN p_TournamentId INT
)
BEGIN
    SELECT * 
    FROM MatchupRounds 
    WHERE TournamentId = p_TournamentId
    ORDER BY RoundNumber;
END$$
DELIMITER ;
