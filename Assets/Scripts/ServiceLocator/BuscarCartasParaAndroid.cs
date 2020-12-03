using System.Collections.Generic;

public class BuscarCartasParaAndroid : IBuscadorDeCartasGuardadas
{
    public List<ICarta> BuscarCartasPorGenero(IGenero genero)
    {
        List<ICarta> listaCartas = new List<ICarta>();

        for(var i = 0; i < 100; i++)
        {
            listaCartas.Add(new Carta(new Genero(genero.Nombre), $"Genero {genero.Nombre} nunca {i}"));
        }

        return listaCartas;
    }
}