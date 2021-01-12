using System.Collections.Generic;

public class LogicaParaGirarLaRuleta
{

    private IBaraja baraja;
    private ISeleccionadorDeCartasMono seleccionadorDeCartasMono;

    public LogicaParaGirarLaRuleta(ISeleccionadorDeCartasMono seleccionadorDeCartasMono)
    {
        this.seleccionadorDeCartasMono = seleccionadorDeCartasMono;
        //Esta forma de acceder a los generos es para cuando tengamos mas de una. de momento solo tenemos un genero "Normal"
        //var generosGuardados = ServiceLocator.Instance.GetService<IGuardadoDeGeneros>().GenerosGuardados;
        var generosGuardados = new List<IGenero>
        {
            new Genero("Normal")
        };
        var cartasPorGenero = ServiceLocator.Instance.GetService<ICreadorDeBaraja>().CrearOpcionesDeRuletaPorGenero(generosGuardados);
        baraja = new BarajaRuleta(cartasPorGenero);
    }

    public void SeleccionaUnaOpcion()
    {
        ICarta cartaWin = baraja.TomarCarta();
        seleccionadorDeCartasMono.ColocarTextoDeLaCartaSeleccionada(cartaWin, baraja);
    }

    public void DeboIrHaciaAtras(bool deboIrmeHAciaAtras)
    {
        if(deboIrmeHAciaAtras)
            ServiceLocator.Instance.GetService<ITransicionEscenaMono>().OnTransicion(0);
    }
}