public class Genero : IGenero
{
    public Genero()
    {

    }

    public Genero(string nombre)
    {
        Nombre = nombre;
    }
    public string Nombre { get; set; }
    public bool IsDisponible { get; set; }
}