using System.Collections.Generic;
using System.IO;

public class BuscarCartasDesdeUnArchivoDeTexto : IBuscadorDeCartasGuardadas
{

    public List<ICarta> BuscarCartasPorGenero(IGenero genero)
    {
        //Posiblemte aqui es donde busque desde Playfab o alguna base de datos externa
        List<ICarta> listaCartas = new List<ICarta>();
        string _rutaArchivo = @"./nuncanunca.csv";
        //creando el archivo si es necesario
        if (!File.Exists(_rutaArchivo))
        {
            File.Create(_rutaArchivo);
        }
        var reader = new StreamReader(File.OpenRead(_rutaArchivo));
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
