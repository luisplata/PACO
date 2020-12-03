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
#if UNITY_WEBGL
        var buscador = new BuscarCartasDesdeUnArchivoDeTexto();
#elif UNITY_ANDROID
        var buscador = new BuscarCartasParaAndroid();
#else
        var buscador = new BuscarCartasDesdeUnArchivoDeTexto();
#endif
        ServiceLocator.Instance.RegisterService<IBuscadorDeCartasGuardadas>(buscador);
        SceneManager.LoadScene(1);
    }
}
