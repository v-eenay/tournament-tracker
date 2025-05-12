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

    // Removed the duplicated namespace TrackerUI
    public partial class TournamentViewerForm : Form
    {
        private TournamentModel tournament;
        BindingList<int> rounds = new BindingList<int>();
        BindingList<MatchupModel> selectedMatchups = new BindingList<MatchupModel>();

        public TournamentViewerForm(TournamentModel tournamentModel)
        {
            InitializeComponent();
            this.tournament = tournamentModel;
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
            MatchupListbox.DataSource = selectedMatchups;
            MatchupListbox.DisplayMember = "DisplayName";
        }

        private void LoadRounds()
        {
            rounds.Clear();
            rounds.Add(1); // Assuming at least one round
            int currRound = 1;

            foreach (List<MatchupModel> matchups in tournament.Rounds)
            {
                if (matchups.First().MatchupRound > currRound)
                {
                    currRound = matchups.First().MatchupRound;
                    rounds.Add(currRound);
                }
            }
            LoadMatchups(1); // Load matchups for the first round by default
        }

        private void RoundDropDown_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            LoadMatchups((int)RoundDropDown.SelectedItem);
        }

        private void LoadMatchups(int round)
        {
            selectedMatchups.Clear();
            foreach (List<MatchupModel> roundMatchups in tournament.Rounds)
            {
                if (roundMatchups.FirstOrDefault()?.MatchupRound == round)
                {
                    foreach (MatchupModel m in roundMatchups)
                    {
                        if (m.Winner == null || !UnplayedOnlyCheckbox.Checked)
                        {
                           selectedMatchups.Add(m);
                        }
                    }
                }
            }
            if (selectedMatchups.Count > 0)
            {
                LoadMatchup(selectedMatchups.First());
            }
            DisplayMatchupInfo();
        }

        private void DisplayMatchupInfo()
        {
            bool isVisible = (selectedMatchups.Count > 0);

            TeamOneName.Visible = isVisible;
            TeamOneScoreLabel.Visible = isVisible;
            TeamTwoName.Visible = isVisible;
            TeamTwoScoreLabel.Visible = isVisible;
            VersusLabel.Visible = isVisible;
            ScoreButton.Visible = isVisible;
        }

        private void LoadMatchup(MatchupModel m)
        {
            if (m == null) return;

            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        TeamOneName.Text = m.Entries[0].TeamCompeting.TeamName;
                        TeamOneScoreValue.Text = m.Entries[0].Score.ToString();
                        TeamTwoName.Text = "<bye>";
                        TeamTwoScoreValue.Text = "0";
                    }
                    else
                    {
                        TeamOneName.Text = "Not Yet Set";
                        TeamOneScoreValue.Text = "";
                    }
                }

                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        TeamTwoName.Text = m.Entries[1].TeamCompeting.TeamName;
                        TeamTwoScoreValue.Text = m.Entries[1].Score.ToString();
                    }
                    else
                    {
                        TeamTwoName.Text = "Not Yet Set";
                        TeamTwoScoreValue.Text = "";
                    }
                }
            }
        }

        private void MatchupListbox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            LoadMatchup((MatchupModel)MatchupListbox.SelectedItem);
        }

        private void UnplayedOnlyCheckbox_CheckedChanged(object sender, System.EventArgs e)
        {
            if (RoundDropDown.SelectedItem != null)
            {
                LoadMatchups((int)RoundDropDown.SelectedItem);
            }
        }

        private void ScoreButton_Click(object sender, System.EventArgs e)
        {
            MatchupModel m = (MatchupModel)MatchupListbox.SelectedItem;
            double teamOneScore = 0;
            double teamTwoScore = 0;

            if (m == null)
            {
                MessageBox.Show("Please select a matchup.");
                return;
            }

            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        bool scoreValid = double.TryParse(TeamOneScoreValue.Text, out teamOneScore);
                        if (scoreValid)
                        {
                            m.Entries[0].Score = teamOneScore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for Team 1.");
                            return;
                        }
                    }
                }

                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        bool scoreValid = double.TryParse(TeamTwoScoreValue.Text, out teamTwoScore);
                        if (scoreValid)
                        {
                            m.Entries[1].Score = teamTwoScore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid score for Team 2.");
                            return;
                        }
                    }
                }
            }

            try
            {
                TournamentLogic.UpdateTournamentResults(tournament);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Application Error: {ex.Message}");
                return;
            }
            
            LoadMatchups((int)RoundDropDown.SelectedItem);
        }
    }
}
