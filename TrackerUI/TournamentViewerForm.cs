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
    // Remove the duplicated namespace TrackerUI if it exists in the actual file
    // Assuming the structure is: namespace TrackerUI { public partial class TournamentViewerForm ... }
    public partial class TournamentViewerForm : Form
    {
        private TournamentModel tournament;
        BindingList<int> rounds = new BindingList<int>();
        BindingList<MatchupModel> selectedMatchups = new BindingList<MatchupModel>();

        public TournamentViewerForm(TournamentModel tournamentModel)
        {   
            InitializeComponent();
            this.tournament = tournamentModel;
            // Ensure TournamentName is updated in LoadFormData
            LoadFormData();
            WireUpLists();
            LoadRounds();
        }

        private void LoadFormData()
        {
            TournamentName.Text = tournament.TournamentName;
        }

        private void WireUpLists()
        {
            RoundDropDown.DataSource = rounds;
            // roundDropDown.DisplayMember = default, no need to set for int list

            MatchupListbox.DataSource = selectedMatchups;
            MatchupListbox.DisplayMember = "DisplayName"; 
        }

        private void LoadRounds()
        {
            rounds.Clear();
            rounds.Add(1); // Default first round
            int currentRound = 1;

            foreach (List<MatchupModel> roundMatchups in tournament.Rounds)
            {
                if (roundMatchups.Any() && roundMatchups.First().MatchupRound > currentRound)
                {
                    currentRound = roundMatchups.First().MatchupRound;
                    rounds.Add(currentRound);
                }
            }
            LoadMatchups(1); // Load matchups for the first round by default
        }

        private void roundDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RoundDropDown.SelectedItem != null)
            {
                LoadMatchups((int)RoundDropDown.SelectedItem);
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
                        if (matchup.Winner == null || !UnplayedOnlyCheckbox.Checked)
                        {
                           selectedMatchups.Add(matchup);
                        }
                    }
                }
            }

            if (selectedMatchups.Count > 0)
            {
               LoadMatchup(selectedMatchups.First());
            }
            else
            {
                ClearMatchupInfo(); // Clear details if no matchups are shown
            }
            DisplayMatchupInfo(); 
        }
        
        private void DisplayMatchupInfo()
        {
            bool visible = (selectedMatchups.Count > 0);
            TeamOneName.Visible = visible;
            TeamOneScore.Visible = visible; // Label "Score" for team one
            TeamOneScoreValue.Visible = visible;
            TeamTwoName.Visible = visible;
            TeamTwoScore.Visible = visible; // Label "Score" for team two
            TeamTwoScoreValue.Visible = visible;
            VsLabel.Visible = visible;
            ScoreButton.Visible = visible;
        }

        private void LoadMatchup(MatchupModel m)
        {
            if (m == null) 
            {
                ClearMatchupInfo();
                return;
            }

            // Team One
            if (m.Entries.Count > 0)
            {
                if (m.Entries[0].TeamCompeting != null)
                {
                    TeamOneName.Text = m.Entries[0].TeamCompeting.TeamName;
                    TeamOneScoreValue.Text = m.Entries[0].Score.ToString();
                }
                else
                {
                    TeamOneName.Text = "Not Yet Set";
                    TeamOneScoreValue.Text = "";
                }
            }
            else // Should ideally not happen with valid MatchupModel
            {
                TeamOneName.Text = "Error: No Entry";
                TeamOneScoreValue.Text = "";
            }

            // Team Two
            if (m.Entries.Count > 1)
            {
                if (m.Entries[1].TeamCompeting != null)
                {
                    TeamTwoName.Text = m.Entries[1].TeamCompeting.TeamName;
                    TeamTwoScoreValue.Text = m.Entries[1].Score.ToString();
                }
                else // Second entry exists, but no team competing (treat as bye or TBD)
                {
                    TeamTwoName.Text = "<bye>"; 
                    TeamTwoScoreValue.Text = ""; // Score for a bye/unset team is empty
                }
            }
            else // Only one entry, implies Team Two is a bye
            {
                TeamTwoName.Text = "<bye>";
                TeamTwoScoreValue.Text = ""; // Score for a bye is empty
            }
        }

        private void ClearMatchupInfo()
        {
            TeamOneName.Text = "";
            TeamOneScoreValue.Text = "";
            TeamTwoName.Text = "";
            TeamTwoScoreValue.Text = "";
        }

        private void matchupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MatchupListbox.SelectedItem != null)
            {
                LoadMatchup((MatchupModel)MatchupListbox.SelectedItem);
            }
        }

        private void unplayedOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RoundDropDown.SelectedItem != null)
            {
               LoadMatchups((int)RoundDropDown.SelectedItem);
            }
        }

        private void scoreButton_Click(object sender, EventArgs e)
        {
            MatchupModel m = (MatchupModel)MatchupListbox.SelectedItem;
            double teamOneScore = 0;
            double teamTwoScore = 0;

            if (m == null)
            {
                MessageBox.Show("Please select a matchup first.", "No Matchup Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Validate scores
            bool scoreOneValid = double.TryParse(TeamOneScoreValue.Text, out teamOneScore);
            bool scoreTwoValid = double.TryParse(TeamTwoScoreValue.Text, out teamTwoScore);

            if (!scoreOneValid || !scoreTwoValid)
            {
                MessageBox.Show("Please enter valid scores for both teams.", "Invalid Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (m.Entries.Count > 0 && m.Entries[0].TeamCompeting != null) m.Entries[0].Score = teamOneScore;
            // Only set teamTwoScore if there is a second team (not a bye)
            if (m.Entries.Count > 1 && m.Entries[1].TeamCompeting != null) m.Entries[1].Score = teamTwoScore;
            // No need for the 'else if' for bye score setting here, as byes don't have input scores

            try
            {
                TournamentLogic.UpdateTournamentResults(tournament);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating tournament results: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            LoadMatchups((int)RoundDropDown.SelectedItem); // Refresh the list
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
}
