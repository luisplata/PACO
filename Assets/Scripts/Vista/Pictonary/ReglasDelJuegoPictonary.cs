using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UI;

public class ReglasDelJuegoPictonary : MonoBehaviour, IReglasDelJuegoPictonary
{
    [SerializeField] private TextMeshProUGUI cantidadDeTragos, cronometro, loQueTieneQueDibujar;
    [SerializeField] private SVGImage iconoCerveza;
    [SerializeField] private Animator animaciones;
    [SerializeField] private Button botonDeControl;
    [SerializeField] private float tiempoMaximoPorPartida, tiempoPorCadaAumento;
    private LogicaDelJuegoPictonary logica;
    [SerializeField]private List<GameObject> listOfGo;

    private void Start()
    {
        logica = new LogicaDelJuegoPictonary(this, cantidadDeTragos, cronometro, loQueTieneQueDibujar, iconoCerveza, animaciones, tiempoMaximoPorPartida, tiempoPorCadaAumento);
        botonDeControl.onClick.AddListener(() =>
        {
            logica.BotonPresionado();
        });
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Update()
    {
        logica.CalculoDelTiempo(Time.deltaTime);
        logica.IrHaciaAtras(Input.GetKeyDown(KeyCode.Escape));
    }

    private void Awake()
    {
        ServiceLocator.Instance.GetService<ITransicionEscenaMono>().OnTransicion();
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void Ready() => logica.Ready();

    public void Go() => logica.Go();

    public void FinGo() => logica.EndGo();

    public void FinDelJuego() => logica.FinDelJuego();

    public void VolverEmpezar() => logica.VolverEmpezar();

    public void EjecutarSonidoDePictonary() => logica.SonarCarton();

    public void StartAgain() => logica.StartAgain();

    public void IncrementCase() => logica.IncrementCase();
    public void ShowGo()
    {
        SetActiveFromGo(true);
    }
    
    public void HiddenGo()
    {
        SetActiveFromGo(false);
    }

    private void SetActiveFromGo(bool actived)
    {
        foreach (var go in listOfGo)
        {
            go.SetActive(actived);
        }
    }
}
