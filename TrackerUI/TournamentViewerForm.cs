namespace TrackerUI
{
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class TournamentViewerForm : Form
    {
        private TournamentModel tournament;
        BindingList<int> rounds = new BindingList<int>();
        BindingList<MatchupModel> selectedMatchups = new BindingList<MatchupModel>();

        public TournamentViewerForm(TournamentModel tournamentModel)
        {
            InitializeComponent();
            this.tournament = tournamentModel;
            WireUpLists();
            LoadFormData();
            LoadRounds();
        }

        private void LoadFormData()
        {
            tournamentName.Text = tournament.TournamentName;
        }

        private void WireUpLists()
        {
            roundDropDown.DataSource = rounds;
            // roundDropDown.DisplayMember = default, no need to set for int list

            matchupListBox.DataSource = selectedMatchups;
            matchupListBox.DisplayMember = "DisplayName"; 
        }

        private void LoadRounds()
        {
            rounds.Clear();
            rounds.Add(1); // Default first round
            int currentRound = 1;

            foreach (List<MatchupModel> roundMatchups in tournament.Rounds)
            {
                if (roundMatchups.First().MatchupRound > currentRound)
                {
                    currentRound = roundMatchups.First().MatchupRound;
                    rounds.Add(currentRound);
                }
            }
            LoadMatchups(1); // Load matchups for the first round by default
        }

        private void roundDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (roundDropDown.SelectedItem != null)
            {
                LoadMatchups((int)roundDropDown.SelectedItem);
            }
        }

        private void LoadMatchups(int round)
        {
            selectedMatchups.Clear();
            foreach (List<MatchupModel> roundMatchups in tournament.Rounds)
            {
                // Ensure there are matchups in the list before accessing First()
                if (roundMatchups.Any() && roundMatchups.First().MatchupRound == round)
                {
                    foreach (MatchupModel matchup in roundMatchups)
                    {
                        if (matchup.Winner == null || !unplayedOnlyCheckBox.Checked)
                        {
                           selectedMatchups.Add(matchup);
                        }
                    }
                }
            }
            // if (selectedMatchups.Count > 0)
            // {
            //    LoadMatchup(selectedMatchups.First());
            // }
            if (selectedMatchups.Count > 0)
            {
               LoadMatchup(selectedMatchups.First());
            }
            DisplayMatchupInfo(); 
        }
        
        private void DisplayMatchupInfo()
        {
            bool visible = (selectedMatchups.Count > 0);
            teamOneNameLabel.Visible = visible;
            teamOneScoreLabel.Visible = visible;
            teamOneScoreValue.Visible = visible;
            teamTwoNameLabel.Visible = visible;
            teamTwoScoreLabel.Visible = visible;
            teamTwoScoreValue.Visible = visible;
            versusLabel.Visible = visible;
            scoreButton.Visible = visible;
        }

        private void LoadMatchup(MatchupModel m)
        {
            if (m == null) 
            {
                ClearMatchupInfo();
                return;
            }

            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        teamOneNameLabel.Text = m.Entries[0].TeamCompeting.TeamName;
                        teamOneScoreValue.Text = m.Entries[0].Score.ToString();
                        teamTwoNameLabel.Text = "<bye>";
                        teamTwoScoreValue.Text = "0"; // Default for bye
                    }
                    else
                    {
                        teamOneNameLabel.Text = "Not Yet Set";
                        teamOneScoreValue.Text = "";
                    }
                }

                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        teamTwoNameLabel.Text = m.Entries[1].TeamCompeting.TeamName;
                        teamTwoScoreValue.Text = m.Entries[1].Score.ToString();
                    }
                    else
                    {
                        teamTwoNameLabel.Text = "Not Yet Set";
                        teamTwoScoreValue.Text = "";
                    }
                }
            }
        }

        private void ClearMatchupInfo()
        {
            teamOneNameLabel.Text = "";
            teamOneScoreValue.Text = "";
            teamTwoNameLabel.Text = "";
            teamTwoScoreValue.Text = "";
        }

        private void matchupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (matchupListBox.SelectedItem != null)
            {
                LoadMatchup((MatchupModel)matchupListBox.SelectedItem);
            }
        }

        private void unplayedOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (roundDropDown.SelectedItem != null)
            {
               LoadMatchups((int)roundDropDown.SelectedItem);
            }
        }

        private void scoreButton_Click(object sender, EventArgs e)
        {
            MatchupModel m = (MatchupModel)matchupListBox.SelectedItem;
            double teamOneScore = 0;
            double teamTwoScore = 0;

            if (m == null)
            {
                MessageBox.Show("Please select a matchup first.", "No Matchup Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Validate scores
            bool scoreOneValid = double.TryParse(teamOneScoreValue.Text, out teamOneScore);
            bool scoreTwoValid = double.TryParse(teamTwoScoreValue.Text, out teamTwoScore);

            if (!scoreOneValid || !scoreTwoValid)
            {
                MessageBox.Show("Please enter valid scores for both teams.", "Invalid Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (m.Entries.Count > 0 && m.Entries[0].TeamCompeting != null) m.Entries[0].Score = teamOneScore;
            // Only set teamTwoScore if there is a second team (not a bye)
            if (m.Entries.Count > 1 && m.Entries[1].TeamCompeting != null) m.Entries[1].Score = teamTwoScore;
            else if (m.Entries.Count > 1 && m.Entries[1].TeamCompeting == null) // Handle bye for team two
            {
                // If team one wins against a bye, team two score remains 0 or irrelevant
            }

            try
            {
                TournamentLogic.UpdateTournamentResults(tournament);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating tournament results: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // GlobalConfig.Connection.UpdateMatchup(m); // This is handled by UpdateTournamentResults which calls UpdateMatchup
            LoadMatchups((int)roundDropDown.SelectedItem); // Refresh the list
            // Check if the tournament is complete
            if (tournament.Rounds.Last().All(matchup => matchup.Winner != null))
            {
                TournamentLogic.CompleteTournament(tournament);
                MessageBox.Show($"{tournament.TournamentName} is complete! Winner: {tournament.Rounds.Last().First().Winner.TeamName}", "Tournament Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Optionally, close the form or disable further score entries
                // this.Close();
            }
        }

        private void TournamentViewerForm_Load(object sender, EventArgs e){}
        private void label1_Click(object sender, EventArgs e){}
    }
}}
