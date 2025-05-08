using TrackerLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace TrackerLibrary.DataAccess;

public class TextConnector : IDataConnection
{
    private const string PrizesFile = "PrizeModels.csv";
    private const string PeopleFile = "PersonModels.csv";
    private const string TeamsFile = "TeamModels.csv";
    private const string TournamentsFile = "TournamentModels.csv";
    private const string MatchupsFile = "MatchupModels.csv";
    private const string MatchupEntriesFile = "MatchupEntryModels.csv";

    public PrizeModel CreatePrize(PrizeModel model)
    {
        List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();
        int currentId = 1;
        if (prizes.Count > 0)
        {
            currentId = prizes.OrderByDescending(x => x.id).First().id + 1;
        }
        model.id = currentId;
        prizes.Add(model);
        prizes.SaveToPrizeFile(PrizesFile);
        return model;
    }

    public PersonModel CreatePerson(PersonModel model)
    {
        List<PersonModel> people = PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
        int currentId = 1;
        if (people.Count > 0)
        {
            currentId = people.OrderByDescending(x => x.id).First().id + 1;
        }
        model.id = currentId;
        people.Add(model);
        people.SaveToPeopleFile(PeopleFile);
        return model;
    }

    public TeamModel CreateTeam(TeamModel model)
    {
        List<TeamModel> teams = TeamsFile.FullFilePath().LoadFile().ConvertToTeamModels(PeopleFile);
        int currentId = 1;
        if (teams.Count > 0)
        {
            currentId = teams.OrderByDescending(x => x.id).First().id + 1;
        }
        model.id = currentId;
        teams.Add(model);
        teams.SaveToTeamFile(TeamsFile);
        return model;
    }

    public void CreateTournament(TournamentModel model)
    {
        List<TournamentModel> tournaments = TournamentsFile.FullFilePath().LoadFile().ConvertToTournamentModels(TeamsFile, PrizesFile, PeopleFile);
        int currentId = 1;
        if (tournaments.Count > 0)
        {
            currentId = tournaments.OrderByDescending(x => x.id).First().id + 1;
        }
        model.id = currentId;
        model.SaveRoundsToFile(MatchupsFile, MatchupEntriesFile);
        tournaments.Add(model);
        tournaments.SaveToTournamentFile(TournamentsFile);
    }

    public List<PersonModel> GetPerson_All()
    {
        return PeopleFile.FullFilePath().LoadFile().ConvertToPersonModels();
    }

    public List<TeamModel> GetTeam_All()
    {
        return TeamsFile.FullFilePath().LoadFile().ConvertToTeamModels(PeopleFile);
    }
}

public static class TextConnectorProcessor
{
    public static string FullFilePath(this string fileName)
    {
        return $"{GlobalConfig.AppKeyLookup("filePath")}/{fileName}";
    }

    public static List<string> LoadFile(this string file)
    {
        if (!File.Exists(file))
        {
            return new List<string>();
        }
        return File.ReadAllLines(file).ToList();
    }

    public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
    {
        List<PrizeModel> output = new List<PrizeModel>();
        foreach (string line in lines)
        {
            string[] cols = line.Split(',');
            PrizeModel p = new PrizeModel();
            p.id = int.Parse(cols[0]);
            p.placeNumber = int.Parse(cols[1]);
            p.placeName = cols[2];
            p.prizeAmount = decimal.Parse(cols[3]);
            p.prizePercentage = double.Parse(cols[4]);
            output.Add(p);
        }
        return output;
    }
    
    public static List<PersonModel> ConvertToPersonModels(this List<string> lines)
    {
        List<PersonModel> output = new List<PersonModel>();
        foreach (string line in lines)
        {
            string[] cols = line.Split(',');
            PersonModel p = new PersonModel();
            p.id = int.Parse(cols[0]);
            p.FirstName = cols[1];
            p.LastName = cols[2];
            p.EmailAddress = cols[3];
            p.CellphoneNumber = cols[4];
            output.Add(p);
        }
        return output;
    }

    public static List<TeamModel> ConvertToTeamModels(this List<string> lines, string peopleFileName)
    {
        List<TeamModel> output = new List<TeamModel>();
        List<PersonModel> people = peopleFileName.FullFilePath().LoadFile().ConvertToPersonModels();

        foreach (string line in lines)
        {
            string[] cols = line.Split(',');
            TeamModel t = new TeamModel();
            t.id = int.Parse(cols[0]);
            t.TeamName = cols[1];

            string[] personIds = cols[2].Split('|');
            foreach (string id in personIds)
            {
                t.TeamMembers.Add(people.Where(x => x.id == int.Parse(id)).First());
            }
            output.Add(t);
        }
        return output;
    }
    
    public static List<TournamentModel> ConvertToTournamentModels(
        this List<string> lines, 
        string teamFileName, 
        string prizeFileName,
        string peopleFileName)
    {
        //id,TournamentName,EntryFee,(id|id|id - Entered Teams),(id|id|id - Prizes),(id^id^id|id^id^id|id^id^id - Rounds)
        List<TournamentModel> output = new List<TournamentModel>();
        List<TeamModel> teams = teamFileName.FullFilePath().LoadFile().ConvertToTeamModels(peopleFileName);
        List<PrizeModel> prizes = prizeFileName.FullFilePath().LoadFile().ConvertToPrizeModels();
        List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();

        foreach (string line in lines)
        {
            string[] cols = line.Split(',');
            TournamentModel tm = new TournamentModel();    
            tm.id = int.Parse(cols[0]);
            tm.TournamentName = cols[1];
            tm.EntryFee = decimal.Parse(cols[2]);

            string[] teamIds = cols[3].Split('|');
            foreach (string id in teamIds)
            {
                tm.EnteredTeams.Add(teams.Where(x => x.id == int.Parse(id)).First());
            }

            if (cols[4].Length > 0)
            {
                string[] prizeIds = cols[4].Split('|');
                foreach (string id in prizeIds)
                {
                    tm.Prizes.Add(prizes.Where(x => x.id == int.Parse(id)).First());
                }
            }
            
            // Capture all matchups for this tournament
            // Capture all matchup entries for each matchup
            string[] roundIds = cols[5].Split('|');
            foreach (string roundId in roundIds)
            {
                string[] matchupTextIds = roundId.Split('^');
                List<MatchupModel> currRound = new List<MatchupModel>();

                foreach (string matchupTextId in matchupTextIds)
                {
                    currRound.Add(matchups.Where(x => x.Id == int.Parse(matchupTextId)).First());
                }
                tm.Rounds.Add(currRound);
            }
            output.Add(tm);
        }
        return output;
    }

    public static void SaveToPrizeFile(this List<PrizeModel> models, string fileName)
    {
        List<string> lines = new List<string>();
        foreach (PrizeModel p in models)
        {
            lines.Add($"{p.id},{p.placeNumber},{p.placeName},{p.prizeAmount},{p.prizePercentage}");
        }
        File.WriteAllLines(fileName.FullFilePath(), lines);
    }

    public static void SaveToPeopleFile(this List<PersonModel> models, string fileName)
    {
        List<string> lines = new List<string>();
        foreach (PersonModel p in models)
        {
            lines.Add($"{p.id},{p.FirstName},{p.LastName},{p.EmailAddress},{p.CellphoneNumber}");
        }
        File.WriteAllLines(fileName.FullFilePath(), lines);
    }

    public static void SaveToTeamFile(this List<TeamModel> models, string fileName)
    {
        List<string> lines = new List<string>();
        foreach (TeamModel t in models)
        {
            lines.Add($"{t.id},{t.TeamName},{ConvertPeopleListToString(t.TeamMembers)}");
        }
        File.WriteAllLines(fileName.FullFilePath(), lines);
    }

    public static void SaveRoundsToFile(this TournamentModel model, string matchupFile, string matchupEntryFile)
    {
        foreach (List<MatchupModel> round in model.Rounds)
        {
            foreach (MatchupModel matchup in round)
            {
                matchup.SaveMatchupToFile(matchupFile, matchupEntryFile);
            }
        }
    }

    public static void SaveMatchupToFile(this MatchupModel matchup, string matchupFile, string matchupEntryFile)
    {
        List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();

        int currentId = 1;
        if (matchups.Count > 0)
        {
            currentId = matchups.OrderByDescending(x => x.Id).First().Id + 1;
        }
        matchup.Id = currentId;
        matchups.Add(matchup);

        // Save to file
        // List<string> lines = new List<string>();
        // foreach (MatchupModel m in matchups)
        // {
        //     string winner = "";
        //     if (m.Winner != null)
        //     {
        //         winner = m.Winner.id.ToString();
        //     }
        //     lines.Add($"{m.Id},{ConvertMatchupEntryListToString(m.Entries)},{winner},{m.MatchupRound}");
        // }
        // File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);

        foreach (MatchupEntryModel entry in matchup.Entries)
        {
            entry.SaveEntryToFile(matchupEntryFile);
        }
        
        // Save to file - moved to the main SaveMatchupsToFile method
        List<string> lines = new List<string>();
        foreach (MatchupModel m in matchups)
        {
            string winner = "";
            if (m.Winner != null)
            {
                winner = m.Winner.id.ToString();
            }
            lines.Add($"{m.Id},{ConvertMatchupEntryListToString(m.Entries)},{winner},{m.MatchupRound}");
        }
        File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), lines);
    }
    
    public static void SaveEntryToFile(this MatchupEntryModel entry, string matchupEntryFile)
    {
        List<MatchupEntryModel> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();
        int currentId = 1;
        if (entries.Count > 0)
        {
            currentId = entries.OrderByDescending(x => x.Id).First().Id + 1;
        }
        entry.Id = currentId;
        entries.Add(entry);

        List<string> lines = new List<string>();
        foreach (MatchupEntryModel e in entries)
        {
            string parent = "";
            if (e.ParentMatchup != null)
            {
                parent = e.ParentMatchup.Id.ToString();
            }
            string competing = "";
            if (e.TeamCompeting != null)
            {
                competing = e.TeamCompeting.id.ToString();
            }
            lines.Add($"{e.Id},{competing},{e.Score},{parent}");
        }
        File.WriteAllLines(GlobalConfig.MatchupEntryFile.FullFilePath(), lines);
    }

    public static void SaveToTournamentFile(this List<TournamentModel> models, string fileName)
    {
        List<string> lines = new List<string>();
        foreach (TournamentModel tm in models)
        {
            lines.Add($"{tm.id},{tm.TournamentName},{tm.EntryFee},{ConvertTeamListToString(tm.EnteredTeams)},{ConvertPrizeListToString(tm.Prizes)},{ConvertRoundListToString(tm.Rounds)}");
        }
        File.WriteAllLines(fileName.FullFilePath(), lines);
    }

    private static string ConvertPeopleListToString(List<PersonModel> people)
    {
        string output = "";
        if (people.Count == 0)
        {
            return "";
        }
        foreach (PersonModel p in people)
        {
            output += $"{p.id}|";
        }
        output = output.Substring(0, output.Length - 1);
        return output;
    }

    private static string ConvertTeamListToString(List<TeamModel> teams)
    {
        string output = "";
        if (teams.Count == 0)
        {
            return "";
        }
        foreach (TeamModel t in teams)
        {
            output += $"{t.id}|";
        }
        output = output.Substring(0, output.Length - 1);
        return output;
    }

    private static string ConvertPrizeListToString(List<PrizeModel> prizes)
    {
        string output = "";
        if (prizes.Count == 0)
        {
            return "";
        }
        foreach (PrizeModel p in prizes)
        {
            output += $"{p.id}|";
        }
        output = output.Substring(0, output.Length - 1);
        return output;
    }

    private static string ConvertRoundListToString(List<List<MatchupModel>> rounds)
    {
        // (id^id^id|id^id^id|id^id^id - Rounds)
        string output = "";
        if (rounds.Count == 0)
        {
            return "";
        }
        foreach (List<MatchupModel> r in rounds)
        {
            output += $"{ConvertMatchupListToString(r)}|";
        }
        output = output.Substring(0, output.Length - 1);
        return output;
    }

    private static string ConvertMatchupListToString(List<MatchupModel> matchups)
    {
        string output = "";
        if (matchups.Count == 0)
        {
            return "";
        }
        foreach (MatchupModel m in matchups)
        {
            output += $"{m.Id}^";
        }
        output = output.Substring(0, output.Length - 1);
        return output;
    }
    
    private static string ConvertMatchupEntryListToString(List<MatchupEntryModel> entries)
    {
        string output = "";
        if (entries.Count == 0)
        {
            return "";
        }
        foreach (MatchupEntryModel e in entries)
        {
            output += $"{e.Id}|";
        }
        output = output.Substring(0, output.Length - 1);
        return output;
    }
    
    public static List<MatchupEntryModel> ConvertToMatchupEntryModels(this List<string> lines)
    {
        //id,TeamCompeting,Score,ParentMatchup
        List<MatchupEntryModel> output = new List<MatchupEntryModel>();
        foreach (string line in lines)
        {
            string[] cols = line.Split(',');
            MatchupEntryModel me = new MatchupEntryModel();
            me.Id = int.Parse(cols[0]);
            
            if (cols[1].Length == 0)
            {
                me.TeamCompeting = null;
            }
            else
            {
                me.TeamCompeting = LookupTeamById(int.Parse(cols[1]));
            }
            
            me.Score = double.Parse(cols[2]);
            
            int parentId = 0;
            if (int.TryParse(cols[3], out parentId))
            {
                me.ParentMatchup = LookupMatchupById(parentId);
            }
            else
            {
                me.ParentMatchup = null;
            }
            output.Add(me);
        }
        return output;
    }

    public static List<MatchupModel> ConvertToMatchupModels(this List<string> lines)
    {
        //id=0,Entries=1,Winner=2,MatchupRound=3
        List<MatchupModel> output = new List<MatchupModel>();
        foreach (string line in lines)
        {
            string[] cols = line.Split(',');
            MatchupModel m = new MatchupModel();
            m.Id = int.Parse(cols[0]);
            m.Entries = ConvertStringToMatchupEntryModels(cols[1]);
            if (cols[2].Length == 0)
            {
                m.Winner = null;
            }
            else
            {
                m.Winner = LookupTeamById(int.Parse(cols[2]));
            }
            m.MatchupRound = int.Parse(cols[3]);
            output.Add(m);
        }
        return output;
    }

    private static List<MatchupEntryModel> ConvertStringToMatchupEntryModels(string input)
    {
        string[] ids = input.Split('|');
        List<MatchupEntryModel> output = new List<MatchupEntryModel>();
        List<MatchupEntryModel> entries = GlobalConfig.MatchupEntryFile.FullFilePath().LoadFile().ConvertToMatchupEntryModels();

        foreach (string id in ids)
        {
            output.Add(entries.Where(x => x.Id == int.Parse(id)).First());
        }
        return output;
    }

    private static TeamModel LookupTeamById(int id)
    {
        List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModels(GlobalConfig.PeopleFile);
        return teams.Where(x => x.id == id).First();
    }

    private static MatchupModel LookupMatchupById(int id)
    {
        List<MatchupModel> matchups = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModels();
        return matchups.Where(x => x.Id == id).First();
    }
}