using UnityEngine.SceneManagement;

public class SeleccionDeGeneroParaRuleta : SeleccionDeGenero
{
    private LogicaDeSeleccionadorDeGenero logica;

    public override void CambiarDeEscena()
    {
        SceneManager.LoadScene(1);
    }

    public override void IrseHaciaLaEscenaDelJuego()
    {
        ServiceLocator.Instance.GetService<ITransicionEscenaMono>().OnTransicion(4);
    }

    protected override void Awake()
    {
        logica = new LogicaDeSeleccionadorDeGenero(this, listaDeGenerosSeleccionables);
        base.Awake();

    }

    protected override void LoQueDebeHacerElBotonCuandoTerminenDeSeleccionarLosGeneros()
    {
        logica.ListaDeGenerosSeleccionados();
    }

    internal override void LoQueDebeHacerElBotonCuandoQueremosIrHaciaAtras()
    {
        ServiceLocator.Instance.GetService<ITransicionEscenaMono>().OnTransicion(0);
    }
}