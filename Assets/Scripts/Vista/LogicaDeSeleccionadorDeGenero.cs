using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine.UI;

internal class LogicaDeSeleccionadorDeGenero
{
    private ISeleccionadorDeGeneroMono seleccionadorDeGeneroMono;
    private List<Toggle> listaDeGenerosSeleccionables;

    public LogicaDeSeleccionadorDeGenero(ISeleccionadorDeGeneroMono seleccionadorDeGeneroMono, List<Toggle> listaDeGenerosSeleccionables)
    {
        this.seleccionadorDeGeneroMono = seleccionadorDeGeneroMono;
        this.listaDeGenerosSeleccionables = listaDeGenerosSeleccionables;
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
            seleccionadorDeGeneroMono.MostrarErrorDeListaDeGeneros("Cantidad de generos seleccionados "+lista.Count);
            return;
        }

        ServiceLocator.Instance.GetService<IGuardadoDeGeneros>().GuardarGeneros(lista);
        
        seleccionadorDeGeneroMono.IrseHaciaLaEscenaDelJuego();
    }
}