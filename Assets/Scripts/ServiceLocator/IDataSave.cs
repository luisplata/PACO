public interface IDataSave
{
    void SaveData(string key, string value);
    string GetData(string key);
}