using System;
using System.Collections.Generic;
using TMPro;

public class LogicaParaGirarLaRuleta
{

    private IBaraja baraja;
    private ISeleccionadorDeCartasMono seleccionadorDeCartasMono;
    private TextMeshProUGUI texto;

    public LogicaParaGirarLaRuleta(ISeleccionadorDeCartasMono seleccionadorDeCartasMono, TextMeshProUGUI texto)
    {
        this.seleccionadorDeCartasMono = seleccionadorDeCartasMono;
        //Esta forma de acceder a los generos es para cuando tengamos mas de una. de momento solo tenemos un genero "Normal"
        //var generosGuardados = ServiceLocator.Instance.GetService<IGuardadoDeGeneros>().GenerosGuardados;
        var generosGuardados = new List<IGenero>
        {
            new Genero("Normal")
        };
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