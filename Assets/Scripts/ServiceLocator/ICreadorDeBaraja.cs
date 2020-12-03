using System.Collections.Generic;

public interface ICreadorDeBaraja
{
    List<ICarta> CrearCartasPorGenero(List<IGenero> generos);
}