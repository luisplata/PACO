using System;
using TMPro;

public class LogicaParaGirarLaRuleta
{

    private IBaraja baraja;
    private ISeleccionadorDeCartasMono seleccionadorDeCartasMono;
    private TextMeshProUGUI texto;

    public LogicaParaGirarLaRuleta(ISeleccionadorDeCartasMono seleccionadorDeCartasMono, TextMeshProUGUI texto)
    {
        this.seleccionadorDeCartasMono = seleccionadorDeCartasMono;
        var generosGuardados = ServiceLocator.Instance.GetService<IGuardadoDeGeneros>().GenerosGuardados;
        var cartasPorGenero = ServiceLocator.Instance.GetService<ICreadorDeBaraja>().CrearOpcionesDeRuletaPorGenero(generosGuardados);
        baraja = new Baraja(cartasPorGenero);
        this.texto = texto;
    }

    internal void SeleccionaUnaOpcion()
    {
        ColocarTextoDeLaCartaSeleccionada(baraja.TomarCarta());
    }


    public void ColocarTextoDeLaCartaSeleccionada(ICarta carta)
    {
        texto.text = carta.Texto;
    }

    public void DeboIrHaciaAtras(bool deboIrmeHAciaAtras)
    {
        if(deboIrmeHAciaAtras)
            ServiceLocator.Instance.GetService<ITransicionEscenaMono>().OnTransicion(3);
    }
}