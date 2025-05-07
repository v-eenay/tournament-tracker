using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess;

public class SqlConnector: IDataConnection
{
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
}