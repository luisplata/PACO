using System;
using System.Collections.Generic;

public class LogicaDelSeleccionadorDeCarta
{
    private IBaraja baraja;
    private ISeleccionadorDeCartasMono seleccionadorDeCartasMono;

    public LogicaDelSeleccionadorDeCarta(ISeleccionadorDeCartasMono seleccionadorDeCartasMono)
    {
        this.seleccionadorDeCartasMono = seleccionadorDeCartasMono;
        var generosGuardados = ServiceLocator.Instance.GetService<IGuardadoDeGeneros>().GenerosGuardados;
        var cartasPorGenero = ServiceLocator.Instance.GetService<ICreadorDeBaraja>().CrearCartasPorGenero(generosGuardados);
        baraja = new Baraja(cartasPorGenero);
    }

    public void SeleccionaUnaCarta()
    {
        ICarta cartaTomada;
        try
        {
            cartaTomada = baraja.TomarCarta();
            seleccionadorDeCartasMono.ColocarTextoDeLaCartaSeleccionada(cartaTomada);
        }
        catch(NoHayCartasException e)
        {
            var generosGuardados = ServiceLocator.Instance.GetService<IGuardadoDeGeneros>().GenerosGuardados;
            var cartasPorGenero = ServiceLocator.Instance.GetService<ICreadorDeBaraja>().CrearCartasPorGenero(generosGuardados);
            baraja = new Baraja(cartasPorGenero);
        }
    }
}