using System.Collections.Generic;

public class GuardadoDeGeneroService : IGuardadoDeGeneros, ICreadorDeBaraja
{
    public List<IGenero> GenerosGuardados { get; private set; }

    public void GuardarGeneros(List<IGenero> generos)
    {
        if(generos.Count <= 0)
        {
            throw new ListaDeGenerosVaciaException("La lista de Generos esta vacia, debe seleccionar alguno para cargar el juego");
        }
        GenerosGuardados = new List<IGenero>();
        foreach(IGenero genero in generos)
        {
            GenerosGuardados.Add(genero);
        }
    }

    public List<ICarta> CrearCartasPorGenero(List<IGenero> generos)
    {
        List<ICarta> listaDeCartas = new List<ICarta>();
        foreach(IGenero genero in generos)
        {
            foreach(ICarta carta in new Baraja(ServiceLocator.Instance.GetService<IBuscadorDeCartasGuardadas>().BuscarCartasPorGenero(genero)).Cartas)
            {
                listaDeCartas.Add(carta);
            }
        }
        return listaDeCartas;
    }
}
