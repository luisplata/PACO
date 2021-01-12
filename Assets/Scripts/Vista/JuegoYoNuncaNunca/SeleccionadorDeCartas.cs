using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeleccionadorDeCartas : MonoBehaviour, ISeleccionadorDeCartasMono
{
    [SerializeField] private Button seleccionDeCarta;
    [SerializeField] private TextMeshProUGUI texto;
    [SerializeField] private List<Sprite> cartasPorGenero;
    [SerializeField] private List<Sprite> revezCartasPorGenero;
    [SerializeField] private Image panelDondeSeMuestraElTexto;
    private LogicaDelSeleccionadorDeCarta logica;
    

    private void Awake()
    {
        ServiceLocator.Instance.GetService<ITransicionEscenaMono>().OnTransicion();
    }
    // Start is called before the first frame update
    void Start()
    {
        //
        logica = new LogicaDelSeleccionadorDeCarta(this, texto, panelDondeSeMuestraElTexto, cartasPorGenero, revezCartasPorGenero, gameObject.GetComponent<Animator>());
        seleccionDeCarta.onClick.AddListener(() =>
        {
            logica.SeleccionaUnaCarta();
        });
    }

    private void Update()
    {
        logica.DeboIrHaciaAtras(Input.GetKeyDown(KeyCode.Escape));
    }

    public void MostrarTexto() => logica.ColocarTextoDeLaCartaSeleccionada();
    public void MostrarTextoRevesDeCarta() => logica.ColocandoElRevezDeLaCarta();

    public void ColocarTextoDeLaCartaSeleccionada(ICarta carta, IBaraja baraja)
    {
        throw new System.NotImplementedException();
    }
}
