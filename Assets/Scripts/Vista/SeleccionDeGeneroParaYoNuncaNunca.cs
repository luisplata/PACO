using UnityEngine.SceneManagement;

public class SeleccionDeGeneroParaYoNuncaNunca : SeleccionDeGenero
{
    private LogicaDeSeleccionadorDeGenero logica;

    public override void CambiarDeEscena()
    {
        SceneManager.LoadScene(2);
    }

    public override void IrseHaciaLaEscenaDelJuego()
    {
        ServiceLocator.Instance.GetService<ITransicionEscenaMono>().OnTransicion(2);
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