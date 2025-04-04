namespace TrackerLibrary;

public class SqlConnector: IDataConnection
{
    public PrizeModel CreatePrize(PrizeModel model)
    {
        model.id = 1;
        return model;
    }
}