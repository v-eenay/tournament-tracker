using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    public partial class CreateTournamentForm : Form
    {
        List<TeamModel> availableTeams = GlobalConfig.Connection.GetTeam_All();
        List<TeamModel> selectedTeams = new List<TeamModel>();
        List<PrizeModel> selectedPrizes = new List<PrizeModel>();

        public CreateTournamentForm()
        {
            InitializeComponent();
            WireUpLists();
        }

        private void WireUpLists()
        {
            // TODO - Connect these to the actual UI controls
            // selectTeamDropDown.DataSource = null;
            // selectTeamDropDown.DataSource = availableTeams;
            // selectTeamDropDown.DisplayMember = "TeamName";

            // tournamentTeamsListBox.DataSource = null;
            // tournamentTeamsListBox.DataSource = selectedTeams;
            // tournamentTeamsListBox.DisplayMember = "TeamName";

            // prizesListBox.DataSource = null;
            // prizesListBox.DataSource = selectedPrizes;
            // prizesListBox.DisplayMember = "PlaceName";
        }

        private void addTeamButton_Click(object sender, EventArgs e)
        {
            // TeamModel t = (TeamModel)selectTeamDropDown.SelectedItem;
            // if (t != null)
            // {
            //     availableTeams.Remove(t);
            //     selectedTeams.Add(t);
            //     WireUpLists();
            // }
            MessageBox.Show("Add Team functionality needs UI elements to be connected.");
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            // Call CreatePrizeForm
            // CreatePrizeForm frm = new CreatePrizeForm(this); // Assuming a constructor that takes IPriceRequester
            // frm.Show();
            MessageBox.Show("Create Prize functionality needs to open CreatePrizeForm.");
        }

        // This method would be called by CreatePrizeForm when a prize is created
        public void PrizeComplete(PrizeModel model)
        {
            selectedPrizes.Add(model);
            WireUpLists();
        }

        private void createTeamLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Call CreateTeamForm
            // CreateTeamForm frm = new CreateTeamForm(this); // Assuming a constructor that takes ITeamRequester
            // frm.Show();
            MessageBox.Show("Create Team functionality needs to open CreateTeamForm.");
        }

        // This method would be called by CreateTeamForm when a team is created
        public void TeamComplete(TeamModel model)
        {
            selectedTeams.Add(model);
            WireUpLists();
        }

        private void removeSelectedPlayerButton_Click(object sender, EventArgs e)
        {
            // TeamModel t = (TeamModel)tournamentTeamsListBox.SelectedItem;
            // if (t != null)
            // {
            //     selectedTeams.Remove(t);
            //     availableTeams.Add(t);
            //     WireUpLists();
            // }
            MessageBox.Show("Remove Selected Player/Team functionality needs UI elements to be connected.");
        }

        private void removeSelectedPrizeButton_Click(object sender, EventArgs e)
        {
            // PrizeModel p = (PrizeModel)prizesListBox.SelectedItem;
            // if (p != null)
            // {
            //     selectedPrizes.Remove(p);
            //     WireUpLists();
            // }
            MessageBox.Show("Remove Selected Prize functionality needs UI elements to be connected.");
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                TournamentModel tm = new TournamentModel();

                // tm.TournamentName = tournamentNameValue.Text;
                // tm.EntryFee = decimal.Parse(entryFeeValue.Text);
                tm.Prizes = selectedPrizes;
                tm.EnteredTeams = selectedTeams;

                // Wire up matchups
                // TournamentLogic.CreateRounds(tm);

                GlobalConfig.Connection.CreateTournament(tm);

                MessageBox.Show("Tournament Created Successfully!");
                // TODO - Reset form or close
            }
            else
            {
                MessageBox.Show("Invalid form data. Please check your input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            bool output = true;
            // decimal fee = 0;
            // bool feeAcceptable = decimal.TryParse(entryFeeValue.Text, out fee);

            // if (!feeAcceptable)
            // {
            //     output = false;
            //     MessageBox.Show("You need to enter a valid Entry Fee.", "Invalid Fee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //     return output;
            // }

            // if (string.IsNullOrWhiteSpace(tournamentNameValue.Text))
            // {
            //     output = false;
            // }

            if (selectedTeams.Count < 2)
            {
                output = false;
                MessageBox.Show("You need at least two teams selected for the tournament.");
            }
            
            // Add more validation as needed for tournament name, entry fee etc.
            // For now, returning true if UI elements for name and fee are not connected.
            // if (string.IsNullOrWhiteSpace(tournamentNameValue.Text)) // Assuming tournamentNameValue is a TextBox
            // {
            //      MessageBox.Show("Tournament name cannot be empty.");
            //      return false;
            // }
            // if (!decimal.TryParse(entryFeeValue.Text, out _)) // Assuming entryFeeValue is a TextBox
            // {
            //      MessageBox.Show("Entry fee must be a valid number.");
            //      return false;
            // }

            return output;
        }
    }
}
}
