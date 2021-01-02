using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InstallerServiceLocator : MonoBehaviour
{
    [SerializeField] private Image cortina;
    private void Awake()
    {
        if(FindObjectsOfType<InstallerServiceLocator>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        var generos = new GuardadoDeGeneroService();
        ServiceLocator.Instance.RegisterService<IGuardadoDeGeneros>(generos);
        ServiceLocator.Instance.RegisterService<ICreadorDeBaraja>(generos);
        var buscador = new BusquedaDeCartasDesdeWebService();
        ServiceLocator.Instance.RegisterService<IBuscadorDeCartasGuardadas>(buscador);
        ServiceLocator.Instance.RegisterService<IBuscadorDeTextosParaRuleta>(buscador);
        ServiceLocator.Instance.RegisterService<IBuscadorDeTextosPorJuego>(buscador);
        var transiciones = new TransicionEscena(cortina);
        ServiceLocator.Instance.RegisterService<ITransicionEscenaMono>(transiciones);
    }
}
