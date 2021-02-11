using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine.UI;

internal class LogicaDeSeleccionadorDeGenero
{
    private List<Toggle> listaDeGenerosSeleccionables;
    private SeleccionDeGenero seleccionDeGenero;

    public LogicaDeSeleccionadorDeGenero(SeleccionDeGenero seleccionDeGenero, List<Toggle> listaDeGenerosSeleccionables)
    {
        this.listaDeGenerosSeleccionables = listaDeGenerosSeleccionables;
        this.seleccionDeGenero = seleccionDeGenero;
        foreach (Toggle toggle in listaDeGenerosSeleccionables)
        {
            toggle.onValueChanged.AddListener(delegate { ServiceLocator.Instance.GetService<IPlaySoundEfect>().PlayOneShot("Click"); });
        }
    }

    public void ListaDeGenerosSeleccionados()
    {
        List<IGenero> lista = new List<IGenero>();

        Assert.IsTrue(listaDeGenerosSeleccionables.Count > 0,"No haz colocado en la lista publica los generos para la ruleta de la vista");

        foreach (Toggle toggle in listaDeGenerosSeleccionables)
        {
            if (toggle.isOn)
            {
                Assert.IsNotNull(toggle.gameObject.GetComponent<IVistaGenero>(), "Te falta colocar el genero al toggle");
                lista.Add(toggle.gameObject.GetComponent<IVistaGenero>().Genero);
            }
        }

        if (lista.Count <= 0)
        {
            seleccionDeGenero.MostrarErrorDeListaDeGeneros("Cantidad de generos seleccionados "+lista.Count);
            return;
        }

        ServiceLocator.Instance.GetService<IGuardadoDeGeneros>().GuardarGeneros(lista);

        seleccionDeGenero.IrseHaciaLaEscenaDelJuego();
    }

    public void DeboIrHaciaAtras(bool deboIrmeHAciaAtras)
    {
        if (deboIrmeHAciaAtras)
            seleccionDeGenero.LoQueDebeHacerElBotonCuandoQueremosIrHaciaAtras();
    }
}