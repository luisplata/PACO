using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeleccionadorDeCartas : MonoBehaviour, ISeleccionadorDeCartasMono, ITransicionEscenaMono
{
    [SerializeField] private Button seleccionDeCarta, irHaciaPantallaDeEleccionDeGenero;
    [SerializeField] private TextMeshProUGUI texto;
    private LogicaDelSeleccionadorDeCarta logica;
    private TransicionEscenaLogica logicaTransicion;
    [SerializeField] bool hasEnter;
    [SerializeField] Image cortina;

    public void CambiarDeEscena()
    {
        
    }

    public void ColocarTextoDeLaCartaSeleccionada(ICarta carta)
    {
        texto.text = carta.Texto;
    }

    // Start is called before the first frame update
    void Start()
    {
        logica = new LogicaDelSeleccionadorDeCarta(this);
        logicaTransicion = new TransicionEscenaLogica(this, hasEnter, cortina);
        logicaTransicion.OnTransicion();
        seleccionDeCarta.onClick.AddListener(() =>
        {
            logica.SeleccionaUnaCarta();
        });
        irHaciaPantallaDeEleccionDeGenero.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(1);
        });
    }
}
