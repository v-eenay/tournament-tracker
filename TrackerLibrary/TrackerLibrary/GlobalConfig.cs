using Microsoft.Extensions.Configuration;
using System.IO;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary;

public static class GlobalConfig
{
    public static IConfiguration Configuration { get; private set; }
    public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();
    public static string ConnectionString { get; private set; } = "";

    public static void InitializeConnections(bool database, bool textFiles)
    {
        // Set up the configuration
        InitializeConfiguration();

        if (database)
        {
            // Set up the SQL Connector properly
            SqlConnector sql = new SqlConnector();
            Connections.Add(sql);
        }

        if (textFiles)
        {
            // Set up the Text Connector properly
            TextConnector text = new TextConnector();
            Connections.Add(text);
        }
    }

    private static void InitializeConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        Configuration = builder.Build();

        // Get the connection string from the configuration
        ConnectionString = Configuration.GetConnectionString("Tournaments");
    }
}