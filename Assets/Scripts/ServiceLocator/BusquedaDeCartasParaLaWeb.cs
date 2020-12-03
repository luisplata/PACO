using System.Collections.Generic;

public class BusquedaDeCartasParaLaWeb : IBuscadorDeCartasGuardadas
{
    public List<ICarta> BuscarCartasPorGenero(IGenero genero)
    {
        //Posiblemte aqui es donde busque desde Playfab o alguna base de datos externa
        List<ICarta> listaCartas = new List<ICarta>();
        
        for(var i = 0; i < 100; i++)
        {
            listaCartas.Add(new Carta(genero, $"nunca nunca... {i}"));
        }

        return listaCartas;
    }
}