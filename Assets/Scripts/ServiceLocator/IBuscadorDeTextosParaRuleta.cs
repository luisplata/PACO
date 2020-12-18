using System.Collections.Generic;

public interface IBuscadorDeTextosParaRuleta
{
    List<ICarta> BuscarTextosPorGenero(IGenero genero);
}