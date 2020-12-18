using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class SeleccionDeGenero : MonoBehaviour, ISeleccionadorDeGeneroMono
{
    [SerializeField] protected List<Toggle> listaDeGenerosSeleccionables;
    [SerializeField] protected Button botonDeContinuar, botonAtras;

    public void MostrarErrorDeListaDeGeneros(string mensajeDeError)
    {
        Debug.LogError(mensajeDeError);
    }
    protected virtual void Awake()
    {
        ServiceLocator.Instance.GetService<ITransicionEscenaMono>().OnTransicion();
    }

    private void Start()
    {
        botonDeContinuar.onClick.AddListener(() => {
            LoQueDebeHacerElBotonCuandoTerminenDeSeleccionarLosGeneros();
        });
        botonAtras.onClick.AddListener(() => {
            LoQueDebeHacerElBotonCuandoQueremosIrHaciaAtras();
        });
    }

    internal abstract void LoQueDebeHacerElBotonCuandoQueremosIrHaciaAtras();
    protected abstract void LoQueDebeHacerElBotonCuandoTerminenDeSeleccionarLosGeneros();

    public abstract void IrseHaciaLaEscenaDelJuego();

    public abstract void CambiarDeEscena();
}