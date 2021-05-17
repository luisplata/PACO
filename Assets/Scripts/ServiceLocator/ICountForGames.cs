namespace Vista
{
    public interface ICountForGames
    {
        void SaveCountForGame(string game, int count);
        int GetCountForGame(string game);
    }
}