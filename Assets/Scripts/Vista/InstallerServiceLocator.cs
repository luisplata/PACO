using UnityEngine;
using UnityEngine.SceneManagement;

public class InstallerServiceLocator : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        var generos = new GuardadoDeGeneroService();
        ServiceLocator.Instance.RegisterService<IGuardadoDeGeneros>(generos);
        ServiceLocator.Instance.RegisterService<ICreadorDeBaraja>(generos);
        var buscador = new BuscarCartasDesdeUnArchivoDeTexto();
        ServiceLocator.Instance.RegisterService<IBuscadorDeCartasGuardadas>(buscador);
        SceneManager.LoadScene(1);
    }
}
