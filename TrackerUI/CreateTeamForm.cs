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
using TrackerLibrary.Models; // Required for PersonModel and TeamModel

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {
        private List<PersonModel> availableTeamMembers = GlobalConfig.Connections[0].GetPerson_All();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();

        public CreateTeamForm()
        {
            InitializeComponent();
            WireUpLists();
        }

        private void WireUpLists()
        {
            selectTeamMemberDropDown.DataSource = null;
            selectTeamMemberDropDown.DataSource = availableTeamMembers;
            selectTeamMemberDropDown.DisplayMember = "FullName";

            teamMembersListBox.DataSource = null;
            teamMembersListBox.DataSource = selectedTeamMembers;
            teamMembersListBox.DisplayMember = "FullName";
        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            // TODO - Implement logic to open a form to create a new person/member
            // For now, we assume members are pre-existing or handled elsewhere.
            // After creating a member, you might want to refresh availableTeamMembers and WireUpLists()
            MessageBox.Show("Functionality to create a new member is not yet implemented.");
        }

        private void addMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)selectTeamMemberDropDown.SelectedItem;
            if (p != null)
            {
                availableTeamMembers.Remove(p);
                selectedTeamMembers.Add(p);
                WireUpLists();
            }
        }

        private void removeSelectedMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel p = (PersonModel)teamMembersListBox.SelectedItem;
            if (p != null)
            {
                selectedTeamMembers.Remove(p);
                availableTeamMembers.Add(p);
                WireUpLists();
            }
        }

        private void createTeamButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                TeamModel t = new TeamModel();
                t.TeamName = teamNameValue.Text; // Assuming teamNameValue is the TextBox for team name
                t.TeamMembers = selectedTeamMembers;

                GlobalConfig.Connections[0].CreateTeam(t);

                MessageBox.Show("Team Created Successfully!");
                ClearForm();
                // Optionally, close the form or provide other feedback
                // this.Close(); 
            }
            else
            {
                MessageBox.Show("Invalid form data. Please check your input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(teamNameValue.Text)) // Assuming teamNameValue is the TextBox for team name
            {
                 MessageBox.Show("Team name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return false;
            }
            if (selectedTeamMembers.Count == 0)
            {
                 MessageBox.Show("You must add at least one member to the team.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return false;
            }
            return true; 
        }

        private void ClearForm()
        {
            teamNameValue.Text = "";
            // Re-initialize availableTeamMembers and selectedTeamMembers to clear selections and refresh data
            availableTeamMembers = GlobalConfig.Connection.GetPerson_All();
            selectedTeamMembers.Clear(); 
            WireUpLists();
        }
    }
}
