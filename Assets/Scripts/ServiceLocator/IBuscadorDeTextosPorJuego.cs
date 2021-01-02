using System.Collections.Generic;

public interface IBuscadorDeTextosPorJuego
{
    List<ICarta> Buscar(IGenero genero, string juego);
}