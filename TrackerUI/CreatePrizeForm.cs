using System;
using System.Windows.Forms;
using TrackerLibrary;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        public CreatePrizeForm()
        {
            InitializeComponent();
        }

        private void CreatePrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel model = new PrizeModel
                {
                    placeNumber = int.Parse(PlaceNumberValue.Text),
                    placeName = PlaceNameValue.Text,
                    prizeAmount = decimal.Parse(PrizeAmountValue.Text),
                    prizePercentage = double.Parse(PrizePercentageValue.Text)
                };

                //Save to the database
                foreach (IDataConnection db in GlobalConfig.Connections)
                {
                    db.CreatePrize(model);
                }
                // TODO: Save the prize model to a database or list.

                MessageBox.Show("Prize Created Successfully!");
            }
            else
            {
                MessageBox.Show("Invalid form data. Please check your input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            bool output = true;

            // Validate Place Number
            bool placeNumberValid = int.TryParse(PlaceNumberValue.Text, out int placeNumber);
            if (!placeNumberValid || placeNumber < 1)
            {
                output = false;
            }

            // Validate Place Name
            if (string.IsNullOrWhiteSpace(PlaceNameValue.Text))
            {
                output = false;
            }

            // Validate Prize Amount and Percentage
            bool prizeAmountValid = decimal.TryParse(PrizeAmountValue.Text, out decimal prizeAmount);
            bool prizePercentageValid = double.TryParse(PrizePercentageValue.Text, out double prizePercentage);

            if (!prizeAmountValid || !prizePercentageValid)
            {
                output = false;
            }

            // At least one value (Amount or Percentage) should be valid and non-negative
            if (prizeAmount <= 0 && prizePercentage <= 0)
            {
                output = false;
            }

            // Prize Percentage should be between 0 and 100
            if (prizePercentage < 0 || prizePercentage > 100)
            {
                output = false;
            }

            return output;
        }
    }
}
