namespace TrackerLibrary;

public class TextConnector : IDataConnection
{
    public PrizeModel CreatePrize(PrizeModel model)
    {
       model.id = 1;
        return model;
    }
}