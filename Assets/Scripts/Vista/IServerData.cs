public interface IServerData
{
    string GetStringDataFromServer(string name);
    int GetIntDataFromServer(string name);
    object GetDataFromServer(string name);
}