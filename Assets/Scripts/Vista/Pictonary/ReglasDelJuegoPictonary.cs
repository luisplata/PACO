using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReglasDelJuegoPictonary : MonoBehaviour, IReglasDelJuegoPictonary
{
    [SerializeField] private TextMeshProUGUI cantidadDeTragos, cronometro, loQueTieneQueDibujar;
    [SerializeField] private Image iconoCerveza;
    [SerializeField] private Animator animaciones;
    [SerializeField] private Button botonDeControl;
    [SerializeField] private float tiempoMaximoPorPartida, tiempoPorCadaAumento;
    private LogicaDelJuegoPictonary logica;

    private void Start()
    {
        logica = new LogicaDelJuegoPictonary(this, cantidadDeTragos, cronometro, loQueTieneQueDibujar, iconoCerveza, animaciones, tiempoMaximoPorPartida, tiempoPorCadaAumento);
        botonDeControl.onClick.AddListener(() =>
        {
            logica.BotonPresionado();
        });
    }

    private void Update()
    {
        logica.CalculoDelTiempo(Time.deltaTime);
        logica.IrHaciaAtras(Input.GetKeyDown(KeyCode.Escape));
    }

    private void Awake()
    {
        ServiceLocator.Instance.GetService<ITransicionEscenaMono>().OnTransicion();
        Screen.orientation = ScreenOrientation.Landscape;
    }

    public void Ready() => logica.Ready();

    public void Go() => logica.Go();

    public void FinGo() => logica.EndGo();

    public void FinDelJuego() => logica.FinDelJuego();

    public void VolverEmpezar() => logica.VolverEmpezar();

    public void EjecutarSonidoDePictonary() => logica.SonarCarton();

}
