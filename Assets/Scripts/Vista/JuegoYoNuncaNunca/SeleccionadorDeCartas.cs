using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeleccionadorDeCartas : MonoBehaviour, ISeleccionadorDeCartasMono
{
    [SerializeField] private Button seleccionDeCarta, irHaciaPantallaDeEleccionDeGenero;
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
        irHaciaPantallaDeEleccionDeGenero.onClick.AddListener(() =>
        {
            ServiceLocator.Instance.GetService<ITransicionEscenaMono>().OnTransicion(1);
        });
    }

    public void MostrarTexto() => logica.ColocarTextoDeLaCartaSeleccionada();
    public void MostrarTextoRevesDeCarta() => logica.ColocandoElRevezDeLaCarta();
}
