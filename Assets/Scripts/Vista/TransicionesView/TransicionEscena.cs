using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransicionEscena : ITransicionEscenaMono
{

    private TransicionEscenaLogica logicaTransicion;
    private Image cortina;

    public void CambiarDeEscena(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }

    public void OnTransicion(int indexScene)
    {
        logicaTransicion.OnTransicionExit(indexScene);
    }


    public void OnTransicion()
    {
        logicaTransicion.OnTransicionEnter();
    }

    public void SalirDelJuego()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

#if UNITY_ANDROID
        Application.Quit();
#endif
    }

    public TransicionEscena(Image _cortina)
    {
        cortina = _cortina;
        logicaTransicion = new TransicionEscenaLogica(this, cortina);
    }
}