public class Carta : ICarta
{
    public IGenero Genero { get; set; }
    public string Texto { get; set; }
    public bool FueElegido { get; set; }

    public Carta(IGenero genero, string texto)
    {
        Genero = genero;
        Texto = texto;
    }
}