using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;
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
                PrizeModel model = new()
                {
                    PlaceNumber = int.Parse(PlaceNumberValue.Text),
                    PlaceName = PlaceNameValue.Text,
                    PrizeAmount = decimal.Parse(PrizeAmountValue.Text),
                    PrizePercentage = double.Parse(PrizePercentageValue.Text)
                };

                //Save to the database
                foreach (IDataConnection db in TrackerLibrary.GlobalConfig.Connections)
                {
                    db.CreatePrize(model);
                }
                // TODO: Save the prize model to a database or list.

                MessageBox.Show("Prize Created Successfully!");
                ClearForm();
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

            // Ensure prizePercentageValue.Text is not empty before parsing
            double prizePercentage = 0;
            bool prizePercentageValid = true;
            if (!string.IsNullOrWhiteSpace(PrizePercentageValue.Text))
            {
                prizePercentageValid = double.TryParse(PrizePercentageValue.Text, out prizePercentage);
            }
            else
            {
                // If prize percentage is empty, it's valid if prize amount is > 0
                // If both are empty/zero, it will be caught later
                PrizePercentageValue.Text = "0"; // Set to 0 for the model
            }

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

        private void ClearForm()
        {
            PlaceNumberValue.Text = "";
            PlaceNameValue.Text = "";
            PrizeAmountValue.Text = "0";
            PrizePercentageValue.Text = "0";
        }
    }
}