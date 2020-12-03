using System.Collections.Generic;
using UnityEngine;

public class Baraja : IBaraja
{
    public List<ICarta> Cartas { get; set; }
    public List<IGenero> Generos { get; set; }
    public bool SePuedeRepetirCarta { get; set; }

    public Baraja(List<ICarta> listaDeCartas)
    {
        Cartas = listaDeCartas;

        Generos = new List<IGenero>();
        foreach(ICarta carta in listaDeCartas)
        {
            if (!Generos.Contains(carta.Genero))
            {
                Generos.Add(carta.Genero);
            }
        }
    }

    public ICarta TomarCarta()
    {
        return Cartas[RandomLocal(0, Cartas.Count)];
    }

    private int RandomLocal(int min, int max)
    {
        return Random.Range(min, max);
    }
}