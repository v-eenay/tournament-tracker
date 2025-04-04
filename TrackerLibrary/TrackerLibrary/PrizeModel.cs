namespace TrackerLibrary;

public class PrizeModel
{
    public int id { get; set; }
    public int placeNumber { get; set; }
    public string placeName { get; set; }
    public decimal prizeAmount { get; set; }
    public double prizePercentage { get; set; }

    public PrizeModel()
    {
    }

    public PrizeModel(int placeNumber, string placeName, decimal prizeAmount, double prizePercentage)
    {
        this.placeNumber = placeNumber;
        this.placeName = placeName;
        this.prizeAmount = prizeAmount;
        this.prizePercentage = prizePercentage;
    }
}