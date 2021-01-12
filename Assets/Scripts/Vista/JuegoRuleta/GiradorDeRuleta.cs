using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GiradorDeRuleta : MonoBehaviour, ISeleccionadorDeCartasMono
{
    [SerializeField] private Button seleccionDeCarta;
    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private AnimacionesDeLaRuleta animacionesDeRuleta;
    private LogicaParaGirarLaRuleta logica;

    private void Awake()
    {
        ServiceLocator.Instance.GetService<ITransicionEscenaMono>().OnTransicion();
    }
    // Start is called before the first frame update
    void Start()
    {
        logica = new LogicaParaGirarLaRuleta(this);
        seleccionDeCarta.onClick.AddListener(() =>
        {
            logica.SeleccionaUnaOpcion();
        });
    }

    private void Update()
    {
        logica.DeboIrHaciaAtras(Input.GetKeyDown(KeyCode.Escape));
    }

    public void ColocarTextoDeLaCartaSeleccionada(ICarta carta, IBaraja baraja)
    {
        animacionesDeRuleta.Init(baraja, carta);
    }

}
