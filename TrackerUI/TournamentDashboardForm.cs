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
    public partial class TournamentDashboardForm : Form
    {
        List<TournamentModel> tournaments = GlobalConfig.Connection.GetTournament_All();

        public TournamentDashboardForm()
        {
            InitializeComponent();
            WireUpLists();
        }

        private void WireUpLists()
        {
            // TODO - Connect to the actual UI control
            // loadExistingTournamentDropDown.DataSource = tournaments;
            // loadExistingTournamentDropDown.DisplayMember = "TournamentName";
            MessageBox.Show("WireUpLists needs UI element 'loadExistingTournamentDropDown' to be connected.");
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            // CreateTournamentForm frm = new CreateTournamentForm();
            // frm.Show();
            MessageBox.Show("Create Tournament button needs to open CreateTournamentForm.");
        }

        private void loadTournamentButton_Click(object sender, EventArgs e)
        {
            // TournamentModel tm = (TournamentModel)loadExistingTournamentDropDown.SelectedItem;
            // if (tm != null)
            // {
            //     TournamentViewerForm frm = new TournamentViewerForm(tm);
            //     frm.Show();
            // }
            // else
            // {
            //     MessageBox.Show("Please select a tournament to load.");
            // }
            MessageBox.Show("Load Tournament button needs UI element 'loadExistingTournamentDropDown' to be connected and open TournamentViewerForm.");
        }
    }
}
}
