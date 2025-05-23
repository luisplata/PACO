﻿using System;
using UnityEngine;

public class BuscarDatosDeServidor : IServerData
{
    public BuscarDatosDeServidor()
    {
    }

    public object GetDataFromServer(string name)
    {
        return PlayerPrefs.GetString(name);
    }

    public int GetIntDataFromServer(string name)
    {
        try { 
            return (int)GetDataFromServer(name);
        }
        catch (Exception)
        {
            return default;
        }
    }

    public string GetStringDataFromServer(string name)
    {
        try
        {
            return (string)GetDataFromServer(name);
        }
        catch (Exception)
        {
            return default;
        }
    }

}