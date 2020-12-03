using System.Collections.Generic;

public interface IBaraja
{
    List<ICarta> Cartas { get; set; }
    List<IGenero> Generos { get; set; }
    bool SePuedeRepetirCarta { get; set; }
    ICarta TomarCarta();
}