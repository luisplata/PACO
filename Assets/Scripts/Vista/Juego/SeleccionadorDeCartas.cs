using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeleccionadorDeCartas : MonoBehaviour, ISeleccionadorDeCartasMono
{
    [SerializeField] private Button seleccionDeCarta, irHaciaPantallaDeEleccionDeGenero;
    [SerializeField] private TextMeshProUGUI texto;
    private LogicaDelSeleccionadorDeCarta logica;

    public void ColocarTextoDeLaCartaSeleccionada(ICarta carta)
    {
        texto.text = carta.Texto;
    }

    private void Awake()
    {
        ServiceLocator.Instance.GetService<ITransicionEscenaMono>().OnTransicion();
    }
    // Start is called before the first frame update
    void Start()
    {
        //
        logica = new LogicaDelSeleccionadorDeCarta(this);
        seleccionDeCarta.onClick.AddListener(() =>
        {
            logica.SeleccionaUnaCarta();
        });
        irHaciaPantallaDeEleccionDeGenero.onClick.AddListener(() =>
        {
            ServiceLocator.Instance.GetService<ITransicionEscenaMono>().OnTransicion(1);
        });
    }
}
