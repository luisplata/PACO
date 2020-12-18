using System;

public class LogicaParaGirarLaRuleta
{

    private IBaraja baraja;
    private ISeleccionadorDeCartasMono seleccionadorDeCartasMono;

    public LogicaParaGirarLaRuleta(ISeleccionadorDeCartasMono seleccionadorDeCartasMono)
    {
        this.seleccionadorDeCartasMono = seleccionadorDeCartasMono;
        var generosGuardados = ServiceLocator.Instance.GetService<IGuardadoDeGeneros>().GenerosGuardados;
        var cartasPorGenero = ServiceLocator.Instance.GetService<ICreadorDeBaraja>().CrearOpcionesDeRuletaPorGenero(generosGuardados);
        baraja = new Baraja(cartasPorGenero);
    }

    internal void SeleccionaUnaOpcion()
    {
        seleccionadorDeCartasMono.ColocarTextoDeLaCartaSeleccionada(baraja.TomarCarta());
    }
}