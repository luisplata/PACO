using System.Collections.Generic;
using System.IO;

public class BuscarCartasDesdeUnArchivoDeTexto : IBuscadorDeCartasGuardadas
{

    public List<ICarta> BuscarCartasPorGenero(IGenero genero)
    {
        //Posiblemte aqui es donde busque desde Playfab o alguna base de datos externa
        List<ICarta> listaCartas = new List<ICarta>();

        var reader = new StreamReader(File.OpenRead(@"./nuncanunca.csv"));
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(';');
            if (genero.Nombre.Equals(values[0]))
            {
                listaCartas.Add(new Carta(new Genero(values[0]), values[1]));
            }
        }

        return listaCartas;
    }
}