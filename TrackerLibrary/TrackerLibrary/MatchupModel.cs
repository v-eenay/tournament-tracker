namespace TrackerLibrary;

public class MatchupModel
{
    public List<MatchupEntryModel> Entries { get; set; } = new();

    public TeamModel Winner { get; set; }

    public int MatchupRound { get; set; }
}