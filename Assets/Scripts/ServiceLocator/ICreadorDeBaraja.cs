using System.Collections.Generic;

public interface ICreadorDeBaraja
{
    List<ICarta> CrearCartasPorGenero(List<IGenero> generos);
    List<ICarta> CrearOpcionesDeRuletaPorGenero(List<IGenero> generosGuardados);
}