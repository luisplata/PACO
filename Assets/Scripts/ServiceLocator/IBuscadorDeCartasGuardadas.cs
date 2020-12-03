using System.Collections.Generic;

public interface IBuscadorDeCartasGuardadas
{
    List<ICarta> BuscarCartasPorGenero(IGenero genero);
}