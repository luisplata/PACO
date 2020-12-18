public class LogicaParaSeleccionarJuego : ILogicaParaSeleccionarJuego
{
    private ILogicaParaSeleccionarJuegoMono logicaParaSeleccionarJuegoMono;

    public LogicaParaSeleccionarJuego(ILogicaParaSeleccionarJuegoMono logicaParaSeleccionarJuegoMono)
    {
        this.logicaParaSeleccionarJuegoMono = logicaParaSeleccionarJuegoMono;
    }

    public void CuandoCargaLaEscena()
    {
        ServiceLocator.Instance.GetService<ITransicionEscenaMono>().OnTransicion();
    }

    public void LoQueDebeHacerElBotonCuandoEsPrecionado(int escena)
    {
        ServiceLocator.Instance.GetService<ITransicionEscenaMono>().OnTransicion(escena);
    }
}