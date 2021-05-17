using UnityEngine;

public class DataSave: IDataSave
{
    public void SaveData(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }

    public string GetData(string key)
    {
        return PlayerPrefs.GetString(key);
    }
}