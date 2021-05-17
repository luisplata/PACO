using Vista;

public class CountsForGames : ICountForGames
{
    public void SaveCountForGame(string game, int count)
    {
        ServiceLocator.Instance.GetService<IDataSave>().SaveData(game, $"{count}");
    }

    public int GetCountForGame(string game)
    {
        return int.Parse(ServiceLocator.Instance.GetService<IDataSave>().GetData(game));
    }
}