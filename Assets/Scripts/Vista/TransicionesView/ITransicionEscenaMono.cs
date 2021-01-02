public interface ITransicionEscenaMono
{
    void CambiarDeEscena(int indexScene);
    void OnTransicion(int indexScene);
    void OnTransicion();
    void SalirDelJuego();
}