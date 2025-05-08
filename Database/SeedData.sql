-- Sample Data for Tournament Tracker Database

-- Ensure you are using the Tournaments database
USE Tournaments;

-- Clear existing data (optional, use with caution in production)
-- DELETE FROM MatchupEntries;
-- DELETE FROM Matchups;
-- DELETE FROM TournamentEntries;
-- DELETE FROM TournamentPrizes;
-- DELETE FROM TeamMembers;
-- DELETE FROM Prizes;
-- DELETE FROM People;
-- DELETE FROM Teams;
-- DELETE FROM Tournaments;

-- Seed Prizes Table
INSERT INTO Prizes (PlaceNumber, PlaceName, PrizeAmount, PrizePercentage)
VALUES 
(1, 'First Place', 1000.00, 0),
(2, 'Second Place', 500.00, 0),
(3, 'Third Place', 250.00, 0),
(1, 'Champion', 0, 0.50),
(2, 'Runner-up', 0, 0.25);

-- Seed People Table
INSERT INTO People (FirstName, LastName, EmailAddress, CellphoneNumber)
VALUES
('John', 'Doe', 'john.doe@example.com', '555-0101'),
('Jane', 'Smith', 'jane.smith@example.com', '555-0102'),
('Robert', 'Brown', 'robert.brown@example.com', '555-0103'),
('Emily', 'Davis', 'emily.davis@example.com', '555-0104'),
('Michael', 'Wilson', 'michael.wilson@example.com', '555-0105'),
('Sarah', 'Miller', 'sarah.miller@example.com', '555-0106'),
('David', 'Garcia', 'david.garcia@example.com', '555-0107'),
('Linda', 'Rodriguez', 'linda.rodriguez@example.com', '555-0108');

-- Seed Teams Table
INSERT INTO Teams (TeamName)
VALUES
('The Titans'),
('The Avengers'),
('Justice League'),
('Guardians');

-- Seed TeamMembers Table (Assuming People and Teams IDs are auto-incremented starting from 1)
-- Team: The Titans (John Doe, Jane Smith)
INSERT INTO TeamMembers (TeamId, PersonId)
VALUES
(1, 1),
(1, 2);

-- Team: The Avengers (Robert Brown, Emily Davis)
INSERT INTO TeamMembers (TeamId, PersonId)
VALUES
(2, 3),
(2, 4);

-- Team: Justice League (Michael Wilson, Sarah Miller)
INSERT INTO TeamMembers (TeamId, PersonId)
VALUES
(3, 5),
(3, 6);

-- Team: Guardians (David Garcia, Linda Rodriguez)
INSERT INTO TeamMembers (TeamId, PersonId)
VALUES
(4, 7),
(4, 8);

-- Seed Tournaments Table
INSERT INTO Tournaments (TournamentName, EntryFee, Active)
VALUES
('Spring Open Championship', 50.00, 1),
('Summer Invitational', 75.00, 1),
('Annual Charity Cup', 25.00, 0); -- Assuming this one is not active yet

-- Seed TournamentPrizes Table (Assuming Tournament and Prize IDs)
-- Spring Open Championship Prizes (First Place, Second Place)
INSERT INTO TournamentPrizes (TournamentId, PrizeId)
VALUES
(1, 1),
(1, 2);

-- Summer Invitational Prizes (Champion, Runner-up)
INSERT INTO TournamentPrizes (TournamentId, PrizeId)
VALUES
(2, 4),
(2, 5);

-- Seed TournamentEntries Table
-- Spring Open Championship Entries (The Titans, The Avengers)
INSERT INTO TournamentEntries (TournamentId, TeamId)
VALUES
(1, 1),
(1, 2);

-- Summer Invitational Entries (Justice League, Guardians)
INSERT INTO TournamentEntries (TournamentId, TeamId)
VALUES
(2, 3),
(2, 4);

-- Seed Matchups Table (Example for Spring Open Championship - 2 teams, 1 round)
-- Assuming TournamentId 1 for Spring Open, TeamId 1 (Titans) vs TeamId 2 (Avengers)
-- WinnerId can be NULL initially or set if a match is completed
INSERT INTO Matchups (TournamentId, WinnerId, MatchupRound)
VALUES
(1, NULL, 1); -- Round 1 matchup

-- Seed MatchupEntries Table (Example for the above matchup)
-- Assuming MatchupId is 1 (auto-incremented)
-- ParentMatchupId is NULL for first-round matchups
-- TeamCompetingId refers to the teams in the matchup
INSERT INTO MatchupEntries (MatchupId, ParentMatchupId, TeamCompetingId, Score)
VALUES
(1, NULL, 1, 0), -- Titans in Matchup 1
(1, NULL, 2, 0); -- Avengers in Matchup 1


-- Example for a tournament with 4 teams (Summer Invitational - TournamentId 2)
-- Round 1, Match 1: Justice League (TeamId 3) vs Guardians (TeamId 4)
INSERT INTO Matchups (TournamentId, WinnerId, MatchupRound)
VALUES
(2, NULL, 1); -- MatchupId will be 2
INSERT INTO MatchupEntries (MatchupId, ParentMatchupId, TeamCompetingId, Score)
VALUES
(2, NULL, 3, 0),
(2, NULL, 4, 0);

-- Round 1, Match 2: (Assuming two other teams, e.g., TeamId 5 and TeamId 6 if they existed and were entered)
-- For this example, let's assume only 2 teams entered this tournament for simplicity of seeding.
-- If there were 4 teams, you'd have another matchup for round 1.

-- Round 2 (Finals): Winner of Matchup 2 vs (Winner of another hypothetical Round 1 Match)
-- For this example, we'll assume the winner of Matchup 2 (Justice League vs Guardians) proceeds.
-- If Matchup 2 (ID 2) winner was Team 3 (Justice League)
-- UPDATE Matchups SET WinnerId = 3 WHERE id = 2;

-- Then a new matchup for Round 2 would be created, potentially with a ParentMatchupId linking back.
-- INSERT INTO Matchups (TournamentId, WinnerId, MatchupRound)
-- VALUES
-- (2, NULL, 2); -- MatchupId will be 3 (for the final)

-- INSERT INTO MatchupEntries (MatchupId, ParentMatchupId, TeamCompetingId, Score)
-- VALUES
-- (3, 2, 3, 0); -- Winner of Matchup 2 (Justice League)
-- (3, X, Y, 0); -- Winner of the other Round 1 match

SELECT 'Sample data seeding complete.' AS Status;