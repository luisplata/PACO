using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vista;

public class InstallerServiceLocator : MonoBehaviour
{
    [SerializeField] private Image cortina;
    [SerializeField] private AudioPacoConfiguration audioPacoConfiguration;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private string playstoreId;
    [SerializeField] private List<string> listaDepublicidades;
    [SerializeField] private string endpoint;
    private bool isTestMode;

    private void Awake()
    {
        if(FindObjectsOfType<InstallerServiceLocator>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

#if UNITY_EDITOR
        isTestMode = true;
#else
        isTestMode = false;
#endif
        DontDestroyOnLoad(gameObject);
        
        
        StartCoroutine(ConectionRestBellseboss.GetRequest($"{endpoint}YoNuncaNunca.json", (yoNuncaNunca) =>
        {
            StartCoroutine(ConectionRestBellseboss.GetRequest($"{endpoint}Pictonary.json", (pictonary) =>
            {
                StartCoroutine(ConectionRestBellseboss.GetRequest($"{endpoint}Ruleta.json", (ruleta) =>
                {
                    var buscador = new BusquedaDeCartasDesdeWebService(yoNuncaNunca,ruleta,pictonary);
                    ServiceLocator.Instance.RegisterService<IBuscadorDeCartasGuardadas>(buscador);
                    ServiceLocator.Instance.RegisterService<IBuscadorDeTextosParaRuleta>(buscador);
                    ServiceLocator.Instance.RegisterService<IBuscadorDeTextosPorJuego>(buscador);
                }));
            }));
        }));
        
        
        var generos = new GuardadoDeGeneroService();
        ServiceLocator.Instance.RegisterService<IGuardadoDeGeneros>(generos);
        ServiceLocator.Instance.RegisterService<ICreadorDeBaraja>(generos);
        var transiciones = new TransicionEscena(cortina);
        ServiceLocator.Instance.RegisterService<ITransicionEscenaMono>(transiciones);
        var systemOfAudio = new SonidosUnity(Instantiate(audioPacoConfiguration), audioSource);
        ServiceLocator.Instance.RegisterService<IPlaySoundEfect>(systemOfAudio);
        var publicidad = new PublicidadUnity(playstoreId, listaDepublicidades, isTestMode);
        ServiceLocator.Instance.RegisterService<IPublicidad>(publicidad);
        var servidor = new BuscarDatosDeServidor();
        ServiceLocator.Instance.RegisterService<IServerData>(servidor);
        var countForGames = new CountsForGames();
        ServiceLocator.Instance.RegisterService<ICountForGames>(countForGames);
        var dataSave = new DataSave();
        ServiceLocator.Instance.RegisterService<IDataSave>(dataSave);
    }
}