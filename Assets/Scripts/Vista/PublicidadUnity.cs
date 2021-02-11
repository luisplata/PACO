using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class PublicidadUnity : IPublicidad
{
    List<string> listaDepublicidades;
    public PublicidadUnity(string playStoreid, List<string> listaDepublicidades, bool isTestMode)
    {
        this.listaDepublicidades = listaDepublicidades;

        Advertisement.Initialize(playStoreid, isTestMode);
    }

    public void ShowAdd()
    {
        var addId = GetAddId();
        if (Advertisement.IsReady(addId))
        {
            if(Random.Range(0, 100) < ServiceLocator.Instance.GetService<IServerData>().GetIntDataFromServer("advertising"))
            {
                Advertisement.Show(addId);
            }
        }
    }

    private string GetAddId()
    {
        return listaDepublicidades[Random.Range(0, listaDepublicidades.Count)];
    }
}