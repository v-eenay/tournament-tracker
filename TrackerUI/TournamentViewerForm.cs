namespace TrackerUI
{
    using System;
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
            // tournamentName.Text = tournament.TournamentName;
             MessageBox.Show("LoadFormData needs UI element 'tournamentName' to be connected.");
        }

        private void WireUpLists()
        {
            // roundDropDown.DataSource = rounds;
            // matchupListBox.DataSource = selectedMatchups;
            // matchupListBox.DisplayMember = "DisplayName"; // Assuming MatchupModel has a DisplayName property
            MessageBox.Show("WireUpLists needs UI elements 'roundDropDown' and 'matchupListBox' to be connected.");
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
            // if (roundDropDown.SelectedItem != null)
            // {
            //     LoadMatchups((int)roundDropDown.SelectedItem);
            // }
             MessageBox.Show("roundDropDown_SelectedIndexChanged needs UI element 'roundDropDown' to be connected.");
        }

        private void LoadMatchups(int round)
        {
            selectedMatchups.Clear();
            foreach (List<MatchupModel> roundMatchups in tournament.Rounds)
            {
                if (roundMatchups.First().MatchupRound == round)
                {
                    foreach (MatchupModel matchup in roundMatchups)
                    {
                        // if (matchup.Winner == null || !unplayedOnlyCheckBox.Checked)
                        // {
                        //    selectedMatchups.Add(matchup);
                        // }
                        selectedMatchups.Add(matchup); // Simplified for now
                    }
                }
            }
            // if (selectedMatchups.Count > 0)
            // {
            //    LoadMatchup(selectedMatchups.First());
            // }
            // DisplayMatchupInfo(); // Call this to update labels if a matchup is auto-selected
            MessageBox.Show("LoadMatchups might need UI element 'unplayedOnlyCheckBox' and a method 'LoadMatchup' and 'DisplayMatchupInfo'.");
        }
        
        private void DisplayMatchupInfo(MatchupModel m)
        {
            // bool visible = (m != null);
            // teamOneNameLabel.Visible = visible;
            // teamOneScoreLabel.Visible = visible;
            // teamOneScoreValue.Visible = visible;
            // teamTwoNameLabel.Visible = visible;
            // teamTwoScoreLabel.Visible = visible;
            // teamTwoScoreValue.Visible = visible;
            // versusLabel.Visible = visible;
            // scoreButton.Visible = visible;
            MessageBox.Show("DisplayMatchupInfo needs various UI label/textbox elements to be connected.");
        }

        private void LoadMatchup(MatchupModel m)
        {
            // if (m == null) return;
            // for (int i = 0; i < m.Entries.Count; i++)
            // {
            //     if (i == 0)
            //     {
            //         if (m.Entries[0].TeamCompeting != null)
            //         {
            //             teamOneNameLabel.Text = m.Entries[0].TeamCompeting.TeamName;
            //             teamOneScoreValue.Text = m.Entries[0].Score.ToString();

            //             teamTwoNameLabel.Text = "<bye>";
            //             teamTwoScoreValue.Text = "0";
            //         }
            //         else
            //         {
            //             teamOneNameLabel.Text = "Not Yet Set";
            //             teamOneScoreValue.Text = "";
            //         }
            //     }

            //     if (i == 1)
            //     {
            //         if (m.Entries[1].TeamCompeting != null)
            //         {
            //             teamTwoNameLabel.Text = m.Entries[1].TeamCompeting.TeamName;
            //             teamTwoScoreValue.Text = m.Entries[1].Score.ToString();
            //         }
            //         else
            //         {
            //             teamTwoNameLabel.Text = "Not Yet Set";
            //             teamTwoScoreValue.Text = "";
            //         }
            //     }
            // }
            MessageBox.Show("LoadMatchup needs UI elements like 'teamOneNameLabel', 'teamOneScoreValue', etc. to be connected.");
        }

        private void matchupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if (matchupListBox.SelectedItem != null)
            // {
            //     LoadMatchup((MatchupModel)matchupListBox.SelectedItem);
            // }
            MessageBox.Show("matchupListBox_SelectedIndexChanged needs UI element 'matchupListBox' to be connected.");
        }

        private void unplayedOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // if (roundDropDown.SelectedItem != null)
            // {
            //    LoadMatchups((int)roundDropDown.SelectedItem);
            // }
            MessageBox.Show("unplayedOnlyCheckBox_CheckedChanged needs UI element 'roundDropDown' to be connected.");
        }

        private void scoreButton_Click(object sender, EventArgs e)
        {
            // MatchupModel m = (MatchupModel)matchupListBox.SelectedItem;
            // double teamOneScore = 0;
            // double teamTwoScore = 0;

            // // Validate scores
            // bool scoreOneValid = double.TryParse(teamOneScoreValue.Text, out teamOneScore);
            // bool scoreTwoValid = double.TryParse(teamTwoScoreValue.Text, out teamTwoScore);

            // if (!scoreOneValid || !scoreTwoValid)
            // {
            //     MessageBox.Show("Please enter valid scores for both teams.");
            //     return;
            // }
            
            // if (m != null) 
            // {
            //     if (m.Entries.Count > 0 && m.Entries[0].TeamCompeting != null) m.Entries[0].Score = teamOneScore;
            //     if (m.Entries.Count > 1 && m.Entries[1].TeamCompeting != null) m.Entries[1].Score = teamTwoScore;

            //     // Determine winner
            //     // TODO - Implement TournamentLogic.UpdateTournamentResults(tournament);
            //     // For now, simple winner determination
            //     if (teamOneScore > teamTwoScore) m.Winner = m.Entries[0].TeamCompeting;
            //     else if (teamTwoScore > teamOneScore) m.Winner = m.Entries[1].TeamCompeting;
            //     else MessageBox.Show("Tie games are not handled yet.");

            //     // GlobalConfig.Connection.UpdateMatchup(m);
            //     LoadMatchups((int)roundDropDown.SelectedItem); // Refresh
            // }
            MessageBox.Show("scoreButton_Click needs UI elements and potentially TournamentLogic to be fully implemented.");
        }

        private void TournamentViewerForm_Load(object sender, EventArgs e){}
        private void label1_Click(object sender, EventArgs e){}
    }
}
}
