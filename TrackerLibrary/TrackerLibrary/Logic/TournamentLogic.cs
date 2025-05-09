using System;
using System.Collections.Generic;
using System.Linq;
using TrackerLibrary.Models;

namespace TrackerLibrary.Logic
{
    public static class TournamentLogic
    {
        // Order our list randomly of teams
        // Check if it is big enough - if not, add in byes - 2^n
        // Create our first round of matchups
        // Create every round after that - 8 matchups - 4 matchups - 2 matchups - 1 matchup

        public static void CreateRounds(TournamentModel model)
        {
            if (model.EnteredTeams == null || model.EnteredTeams.Count < 2)
            {
                throw new ArgumentException("A tournament must have at least two entered teams.", nameof(model.EnteredTeams));
            }
            List<TeamModel> randomizedTeams = RandomizeTeamOrder(model.EnteredTeams);
            int rounds = FindNumberOfRounds(randomizedTeams.Count);
            int byes = NumberOfByes(rounds, randomizedTeams.Count);

            model.Rounds.Add(CreateFirstRound(byes, randomizedTeams));

            CreateOtherRounds(model, rounds);
        }

        private static void CreateOtherRounds(TournamentModel model, int rounds)
        {
            int round = 2;
            List<MatchupModel> previousRound = model.Rounds[0];
            List<MatchupModel> currRound = new List<MatchupModel>();
            MatchupModel currMatchup = new MatchupModel();

            while (round <= rounds)
            {
                foreach (MatchupModel match in previousRound)
                {
                    currMatchup.Entries.Add(new MatchupEntryModel { ParentMatchup = match });

                    if (currMatchup.Entries.Count > 1)
                    {
                        currMatchup.MatchupRound = round;
                        currRound.Add(currMatchup);
                        currMatchup = new MatchupModel();
                    }
                }
                
                model.Rounds.Add(currRound);
                previousRound = currRound;
                
                currRound = new List<MatchupModel>();
                round += 1;
            }
        }

        private static List<MatchupModel> CreateFirstRound(int byes, List<TeamModel> teams)
        {
            List<MatchupModel> output = new List<MatchupModel>();
            MatchupModel curr = new MatchupModel();

            foreach (TeamModel team in teams)
            {
                curr.Entries.Add(new MatchupEntryModel { TeamCompeting = team });

                if (byes > 0 || curr.Entries.Count > 1)
                {
                    curr.MatchupRound = 1;
                    output.Add(curr);
                    curr = new MatchupModel();

                    if (byes > 0)
                    {
                        byes -= 1;
                    }
                }
            }

            return output;
        }

        private static int NumberOfByes(int rounds, int numberOfTeams)
        {
            int output = 0;
            int totalTeams = 1;

            for (int i = 1; i <= rounds; i++)
            {
                totalTeams *= 2;
            }

            output = totalTeams - numberOfTeams;
            
            return output;
        }

        private static int FindNumberOfRounds(int teamCount)
        {
            int output = 1;
            int val = 2;

            while (val < teamCount)
            {
                output += 1;
                val *= 2;
            }

            return output;
        }

        private static List<TeamModel> RandomizeTeamOrder(List<TeamModel> teams)
        {
            // cards.OrderBy(a => Guid.NewGuid()).ToList();
            return teams.OrderBy(x => Guid.NewGuid()).ToList();
        }

        public static void UpdateTournamentResults(TournamentModel model)
        {
            int startingRound = model.CheckCurrentRound();
            List<MatchupModel> toScore = new List<MatchupModel>();

            foreach (List<MatchupModel> round in model.Rounds)
            {
                foreach (MatchupModel rm in round)
                {
                    if (rm.Winner == null && (rm.Entries.Any(x => x.Score != 0) || rm.Entries.Count == 1))
                    {
                        toScore.Add(rm);
                    }
                }
            }

            MarkWinnerInMatchups(toScore);
            AdvanceWinners(toScore, model);
            
            toScore.ForEach(x => GlobalConfig.Connection.UpdateMatchup(x));
            
            // TODO - Add Email sending logic for tournament alerts
        }

        private static void AdvanceWinners(List<MatchupModel> models, TournamentModel tournament)
        {
            foreach (MatchupModel m in models)
            {
                foreach (List<MatchupModel> round in tournament.Rounds)
                {
                    foreach (MatchupModel rm in round)
                    {
                        foreach (MatchupEntryModel me in rm.Entries)
                        {
                            if (me.ParentMatchup != null)
                            {
                                if (me.ParentMatchup.Id == m.Id)
                                {
                                    me.TeamCompeting = m.Winner;
                                    GlobalConfig.Connection.UpdateMatchup(rm); 
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void MarkWinnerInMatchups(List<MatchupModel> models)
        {
            // greater or lesser
            string greaterWins = GlobalConfig.AppKeyLookup("greaterWins");

            foreach (MatchupModel m in models)
            {
                // Bye week entry
                if (m.Entries.Count == 1)
                {
                    m.Winner = m.Entries[0].TeamCompeting;
                    continue;
                }

                // 0 means false, or low score wins
                if (greaterWins == "0")
                {
                    if (m.Entries[0].Score < m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[0].TeamCompeting;
                    }
                    else if (m.Entries[1].Score < m.Entries[0].Score)
                    {
                        m.Winner = m.Entries[1].TeamCompeting;
                    }
                    else
                    {
                        throw new Exception("We do not allow ties in this application.");
                    }
                }
                else
                {
                    // 1 means true, or high score wins
                    if (m.Entries[0].Score > m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[0].TeamCompeting;
                    }
                    else if (m.Entries[1].Score > m.Entries[0].Score)
                    {
                        m.Winner = m.Entries[1].TeamCompeting;
                    }
                    else
                    {
                        throw new Exception("We do not allow ties in this application.");
                    }
                }
            }
        }
        
        private static int CheckCurrentRound(this TournamentModel model)
        {
            int output = 1;

            foreach (List<MatchupModel> round in model.Rounds)
            {
                if (round.All(x => x.Winner != null))
                {
                    output += 1;
                }
                else
                {
                    return output;
                }
            }
            
            // Tournament is complete
            CompleteTournament(model);
            return output -1;
        }

        private static void CompleteTournament(TournamentModel model)
        {
            // Get winner
            TeamModel winner = model.Rounds.Last().First().Winner;
            TeamModel runnerUp = null;
            // Ensure there was a final match with two competitors to determine a runner-up
            if (model.Rounds.Last().First().Entries.Count == 2)
            {
                runnerUp = model.Rounds.Last().First().Entries.FirstOrDefault(x => x.TeamCompeting != winner)?.TeamCompeting;
            }

            decimal totalIncome = model.EnteredTeams.Count * model.EntryFee;

            foreach (PrizeModel prize in model.Prizes)
            {
                TeamModel recipient = null;
                if (prize.placeNumber == 1)
                {
                    recipient = winner;
                }
                else if (prize.placeNumber == 2 && runnerUp != null)
                {
                    recipient = runnerUp;
                }
                // Extend here for other placeNumbers if necessary (e.g., 3rd place from a consolation bracket)

                if (recipient != null)
                {
                    decimal prizeValue = 0;
                    if (prize.prizeAmount > 0)
                    {
                        prizeValue = prize.prizeAmount;
                        // TODO: Logic to formally award prizeAmount to recipient.TeamMembers
                        // For now, we can imagine this logs or prepares for notification:
                        // Console.WriteLine($"{recipient.TeamName} wins {prize.placeName} receiving ${prizeValue}");
                    }
                    else if (prize.prizePercentage > 0)
                    {
                        prizeValue = totalIncome * (decimal)(prize.prizePercentage / 100);
                        // TODO: Logic to formally award prizeValue to recipient.TeamMembers
                        // Console.WriteLine($"{recipient.TeamName} wins {prize.placeName} receiving ${prizeValue} ({prize.prizePercentage}% of pool)");
                    }
                }
            }
            
            // TODO - Send email to all tournament members that the tournament is over and who won.
            // TODO - Potentially save the tournament completion status to the database.
        }
    }
}