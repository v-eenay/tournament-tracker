using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess;

public class SqlConnector: IDataConnection
{
    private const string Db = "Tournaments";
    /// <summary>
    /// Saves a new prize to the database
    /// </summary>
    /// <param name="model">The prize information</param>
    /// <returns>The prize information, including the unique identifier</returns>
    public PrizeModel CreatePrize(PrizeModel model)
    {
        using (IDbConnection connection = new MySqlConnection(GlobalConfig.ConnectionString))
        {
            var p = new DynamicParameters();
            p.Add("@PlaceNumber", model.placeNumber);
            p.Add("@PlaceName", model.placeName);
            p.Add("@PrizeAmount", model.prizeAmount);
            p.Add("@PrizePercentage", model.prizePercentage);
            p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("spPrizes_Insert", p, commandType: CommandType.StoredProcedure);

            model.id = p.Get<int>("@id");

            return model;
        }
    }

    public PersonModel CreatePerson(PersonModel model)
    {
        using (IDbConnection connection = new MySqlConnection(GlobalConfig.ConnectionString))
        {
            var p = new DynamicParameters();
            p.Add("@FirstName", model.FirstName);
            p.Add("@LastName", model.LastName);
            p.Add("@EmailAddress", model.EmailAddress);
            p.Add("@CellphoneNumber", model.CellphoneNumber);
            p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("spPeople_Insert", p, commandType: CommandType.StoredProcedure);

            model.id = p.Get<int>("@id");

            return model;
        }
    }

    public TeamModel CreateTeam(TeamModel model)
    {
        using (IDbConnection connection = new MySqlConnection(GlobalConfig.ConnectionString))
        {
            var p = new DynamicParameters();
            p.Add("@TeamName", model.TeamName);
            p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("spTeams_Insert", p, commandType: CommandType.StoredProcedure);
            model.id = p.Get<int>("@id");

            foreach (PersonModel tm in model.TeamMembers)
            {
                p = new DynamicParameters();
                p.Add("@TeamId", model.id);
                p.Add("@PersonId", tm.id);
                connection.Execute("spTeamMembers_Insert", p, commandType: CommandType.StoredProcedure);
            }
            return model;
        }
    }

    public void CreateTournament(TournamentModel model)
    {
        using (IDbConnection connection = new MySqlConnection(GlobalConfig.ConnectionString))
        {
            SaveTournament(connection, model);
            SaveTournamentPrizes(connection, model);
            SaveTournamentEntries(connection, model);
            SaveTournamentRounds(connection, model);
        }
    }

    private void SaveTournament(IDbConnection connection, TournamentModel model)
    {
        var p = new DynamicParameters();
        p.Add("@TournamentName", model.TournamentName);
        p.Add("@EntryFee", model.EntryFee);
        p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

        connection.Execute("spTournaments_Insert", p, commandType: CommandType.StoredProcedure);
        model.id = p.Get<int>("@id");
    }

    private void SaveTournamentPrizes(IDbConnection connection, TournamentModel model)
    {
        foreach (PrizeModel pz in model.Prizes)
        {
            var p = new DynamicParameters();
            p.Add("@TournamentId", model.id);
            p.Add("@PrizeId", pz.id);
            p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
            connection.Execute("spTournamentPrizes_Insert", p, commandType: CommandType.StoredProcedure);
        }
    }

    private void SaveTournamentEntries(IDbConnection connection, TournamentModel model)
    {
        foreach (TeamModel tm in model.EnteredTeams)
        {
            var p = new DynamicParameters();
            p.Add("@TournamentId", model.id);
            p.Add("@TeamId", tm.id);
            p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
            connection.Execute("spTournamentEntries_Insert", p, commandType: CommandType.StoredProcedure);
        }
    }

    private void SaveTournamentRounds(IDbConnection connection, TournamentModel model)
    {
        // List<List<MatchupModel>> Rounds
        // List<MatchupEntryModel> Entries

        // Loop through the Rounds
        // Loop through the Matchups
        // Save the matchup
        // Loop through the entries and save them
        foreach (List<MatchupModel> round in model.Rounds)
        {
            foreach (MatchupModel matchup in round)
            {
                var p = new DynamicParameters();
                p.Add("@TournamentId", model.id);
                p.Add("@MatchupRound", matchup.MatchupRound);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                
                connection.Execute("spMatchups_Insert", p, commandType: CommandType.StoredProcedure);
                matchup.Id = p.Get<int>("@id");

                foreach (MatchupEntryModel entry in matchup.Entries)
                {
                    p = new DynamicParameters();
                    p.Add("@MatchupId", matchup.Id);
                    
                    if (entry.ParentMatchup == null)
                    {
                        p.Add("@ParentMatchupId", null);
                    }
                    else
                    {
                        p.Add("@ParentMatchupId", entry.ParentMatchup.Id);
                    }

                    if (entry.TeamCompeting == null)
                    {
                        p.Add("@TeamCompetingId", null);
                    }
                    else
                    {
                        p.Add("@TeamCompetingId", entry.TeamCompeting.id);
                    }
                    p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                    connection.Execute("spMatchupEntries_Insert", p, commandType: CommandType.StoredProcedure);
                }
            }
        }
    }

    public List<PersonModel> GetPerson_All()
    {
        List<PersonModel> output;
        using (IDbConnection connection = new MySqlConnection(GlobalConfig.ConnectionString))
        {
            output = connection.Query<PersonModel>("spPeople_GetAll").ToList();
        }
        return output;
    }

    public List<TeamModel> GetTeam_All()
    {
        List<TeamModel> output;
        using (IDbConnection connection = new MySqlConnection(GlobalConfig.ConnectionString))
        {
            output = connection.Query<TeamModel>("spTeams_GetAll").ToList();
            foreach (TeamModel team in output)
            {
                var p = new DynamicParameters();
                p.Add("@TeamId", team.id);
                team.TeamMembers = connection.Query<PersonModel>("spTeamMembers_GetByTeam", p, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        return output;
    }
}