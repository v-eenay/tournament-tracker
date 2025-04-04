﻿namespace TrackerLibrary.Models;

public class TournamentModel
{
    public string TournamentName { get; set; }
    public decimal EntryFee { get; set; }
    public List<TeamModel> EnteredTeams { get; set; } = new List<TeamModel>();
    public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();
    public List<MatchupModel> Rounds { get; set; } = new List<MatchupModel>();
}