using System.Collections.Generic;
using UnityEngine;

public class Baraja : IBaraja
{
    public List<ICarta> Cartas { get; set; }
    public bool SePuedeRepetirCarta { get; set; }

    public Baraja(List<ICarta> listaDeCartas)
    {
        Cartas = listaDeCartas;
    }

    public ICarta TomarCarta()
    {
        if (Cartas.Count <= 0)
        {
            throw new NoHayCartasException("No hay mas cartas que elegir");
        }
        int index = RandomLocal(0, Cartas.Count);
        ICarta cartaElejida = Cartas[index];
        Cartas.RemoveAt(index);
        return cartaElejida;
    }        

    private int RandomLocal(int min, int max)
    {
        return Random.Range(min, max);
    }
}