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
    public partial class CreateTeamForm : Form
    {
        private List<PersonModel> availableTeamMembers = GlobalConfig.Connection.GetPerson_All();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();

        public CreateTeamForm()
        {
            InitializeComponent();
            // InitializeDataSource(); // Call this if you have a method to populate dropdowns/listboxes
            WireUpLists();
        }

        private void WireUpLists()
        {
            // TODO - Refresh the data source for the dropdown/listbox
            // selectTeamMemberDropDown.DataSource = null;
            // selectTeamMemberDropDown.DataSource = availableTeamMembers;
            // selectTeamMemberDropDown.DisplayMember = "FullName"; // Assuming PersonModel has a FullName property

            // teamMembersListBox.DataSource = null;
            // teamMembersListBox.DataSource = selectedTeamMembers;
            // teamMembersListBox.DisplayMember = "FullName";
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
            // PersonModel p = (PersonModel)selectTeamMemberDropDown.SelectedItem;
            // if (p != null)
            // {
            //     availableTeamMembers.Remove(p);
            //     selectedTeamMembers.Add(p);
            //     WireUpLists();
            // }
            MessageBox.Show("Add member functionality needs UI elements to be connected.");
        }

        private void removeSelectedMemberButton_Click(object sender, EventArgs e)
        {
            // PersonModel p = (PersonModel)teamMembersListBox.SelectedItem;
            // if (p != null)
            // {
            //     selectedTeamMembers.Remove(p);
            //     availableTeamMembers.Add(p);
            //     WireUpLists();
            // }
            MessageBox.Show("Remove member functionality needs UI elements to be connected.");
        }

        private void createTeamButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                TeamModel t = new TeamModel();
                // t.TeamName = teamNameValue.Text;
                t.TeamMembers = selectedTeamMembers;

                GlobalConfig.Connection.CreateTeam(t);

                // TODO - Reset the form or close it
                MessageBox.Show("Team Created Successfully!");
                // ClearForm();
            }
            else
            {
                MessageBox.Show("Invalid form data. Please check your input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            // bool output = true;
            // if (string.IsNullOrWhiteSpace(teamNameValue.Text))
            // {
            //     output = false;
            // }
            // if (selectedTeamMembers.Count == 0)
            // {
            //     output = false;
            // }
            // return output;
            // For now, returning true as UI elements are not connected for full validation
            if (selectedTeamMembers.Count == 0)
            {
                 MessageBox.Show("You must add at least one member to the team.");
                 return false;
            }
            // if (string.IsNullOrWhiteSpace(teamNameValue.Text)) // Assuming teamNameValue is the TextBox for team name
            // {
            //      MessageBox.Show("Team name cannot be empty.");
            //      return false;
            // }
            return true; 
        }

        // private void ClearForm()
        // {
        //     teamNameValue.Text = "";
        //     selectedTeamMembers.Clear();
        //     availableTeamMembers = GlobalConfig.Connection.GetPerson_All(); // Refresh available members
        //     WireUpLists();
        // }
    }
}
