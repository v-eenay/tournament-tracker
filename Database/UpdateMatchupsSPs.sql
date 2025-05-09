-- Stored Procedure to update a matchup's winner
DROP PROCEDURE IF EXISTS dbo.spMatchups_Update;
GO
CREATE PROCEDURE dbo.spMatchups_Update
    @Id INT,
    @WinnerId INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Matchups
    SET WinnerId = @WinnerId
    WHERE id = @Id;
END
GO

-- Stored Procedure to update a matchup entry's score and potentially team
-- Note: TeamCompetingId is usually set during matchup creation or advancement, 
-- but including it here for flexibility if direct updates are ever needed.
DROP PROCEDURE IF EXISTS dbo.spMatchupEntries_Update;
GO
CREATE PROCEDURE dbo.spMatchupEntries_Update
    @Id INT,
    @TeamCompetingId INT = NULL, -- Retain existing if NULL is passed and column allows NULL, or handle as per DB schema
    @Score FLOAT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.MatchupEntries
    SET 
        -- Only update TeamCompetingId if a non-NULL value is provided for it.
        -- This assumes TeamCompetingId might already be set and we don't want to overwrite with NULL unless intended.
        -- If the intention is to clear TeamCompetingId, the procedure or calling logic needs to handle it.
        TeamCompetingId = COALESCE(@TeamCompetingId, TeamCompetingId), 
        Score = @Score
    WHERE id = @Id;
END
GO