using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogicaDelSeleccionadorDeCarta
{
    private IBaraja baraja;
    private ISeleccionadorDeCartasMono seleccionadorDeCartasMono;
    private bool debeMostrarElRevez;
    ICarta cartaTomada;
    private Image panelDondeSeMuestraElTexto;
    private TextMeshProUGUI texto;
    private List<Sprite> revezCartasPorGenero;
    private List<Sprite> cartasPorGenero;
    private Animator animator;

    public LogicaDelSeleccionadorDeCarta(ISeleccionadorDeCartasMono seleccionadorDeCartasMono, TextMeshProUGUI texto, Image panelDondeSeMuestraElTexto, List<Sprite> cartasPorGenero, List<Sprite> revezCartasPorGenero, Animator animator)
    {
        this.seleccionadorDeCartasMono = seleccionadorDeCartasMono;
        var generosGuardadosSl = ServiceLocator.Instance.GetService<IGuardadoDeGeneros>().GenerosGuardados;
        var cartasPorGeneroSl = ServiceLocator.Instance.GetService<ICreadorDeBaraja>().CrearCartasPorGenero(generosGuardadosSl);
        baraja = new Baraja(cartasPorGeneroSl);
        debeMostrarElRevez = true;
        this.revezCartasPorGenero = revezCartasPorGenero;
        this.cartasPorGenero = cartasPorGenero;
        this.texto = texto;
        this.panelDondeSeMuestraElTexto = panelDondeSeMuestraElTexto;
        this.animator = animator;
    }

    public void SeleccionaUnaCarta()
    {

        if (debeMostrarElRevez)
        {
            try
            {
                cartaTomada = baraja.TomarCarta();
            }
            catch(NoHayCartasException e)
            {
                var generosGuardados = ServiceLocator.Instance.GetService<IGuardadoDeGeneros>().GenerosGuardados;
                var cartasPorGenero = ServiceLocator.Instance.GetService<ICreadorDeBaraja>().CrearCartasPorGenero(generosGuardados);
                baraja = new Baraja(cartasPorGenero);
                cartaTomada = baraja.TomarCarta();
            }
            animator.SetTrigger("mostrarReves");
        }
        else
        {
            animator.SetTrigger("mostrarCara");
        }
        debeMostrarElRevez = !debeMostrarElRevez;
    }

    public void ColocandoElRevezDeLaCarta()
    {
        foreach (Sprite s in revezCartasPorGenero)
        {
            if (s.name.Equals(cartaTomada.Genero.Nombre))
            {
                panelDondeSeMuestraElTexto.sprite = s;
            }
        }
        texto.text = "";
    }

    public void ColocarTextoDeLaCartaSeleccionada()
    {
        foreach (Sprite s in cartasPorGenero)
        {
            if (s.name.Equals(cartaTomada.Genero.Nombre))
            {
                panelDondeSeMuestraElTexto.sprite = s;
            }
        }
        texto.text = cartaTomada.Texto;
    }
}