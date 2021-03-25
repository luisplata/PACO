using System;
using System.Collections.Generic;
using UnityEngine;

public class BusquedaDeCartasDesdeWebService : IBuscadorDeCartasGuardadas, IBuscadorDeTextosParaRuleta, IBuscadorDeTextosPorJuego
{
    
    public List<ICarta> BuscarCartasPorGenero(IGenero genero)
    {
        return Buscar(genero, "yoNuncaNunca");
    }

    public List<ICarta> BuscarTextosPorGenero(IGenero genero)
    {
        return Buscar(genero, "ruleta");
    }

    public List<ICarta> Buscar(IGenero genero, string juego)
    {
        List<ICarta> listaCartas = new List<ICarta>();

        ListaDeYoNuncaNunca lista = FactoriaDeListasDeCartas(juego);
        foreach (YoNuncaNunca yoNunca in lista.generos)
        {
            if (genero.Nombre == yoNunca.nombre)
            {
                foreach (TextoDeCarta textoDeCarta in yoNunca.listaTextoCarta)
                {
                    listaCartas.Add(new Carta(genero, textoDeCarta.value));
                }
            }
        }

        return listaCartas;
    }
    private Dictionary<string,ListaDeYoNuncaNunca> bodega;
    private ListaDeYoNuncaNunca FactoriaDeListasDeCartas(string cartaJuego)
    {
        bodega.TryGetValue(cartaJuego,  out var valor);
        return valor;
    }

    public BusquedaDeCartasDesdeWebService(string jsonDeCartasNuncaNunca,string jsonDeTextosParaRuleta,string jsonDeTextosParaPictonary)
    {
        bodega = new Dictionary<string, ListaDeYoNuncaNunca>
        {
            {
                "ruleta",
                new ListaDeYoNuncaNunca
                {
                    generos = JsonUtility.FromJson<ListaDeYoNuncaNunca>(jsonDeTextosParaRuleta).generos
                }
            },
            {
                "yoNuncaNunca",
                new ListaDeYoNuncaNunca
                {
                    generos = JsonUtility.FromJson<ListaDeYoNuncaNunca>(jsonDeCartasNuncaNunca).generos
                }
            },
            {
                "pictonary",
                new ListaDeYoNuncaNunca
                {
                    generos = JsonUtility.FromJson<ListaDeYoNuncaNunca>(jsonDeTextosParaPictonary).generos
                }
            }
        };
    }
}