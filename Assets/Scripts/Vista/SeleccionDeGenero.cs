using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeleccionDeGenero : MonoBehaviour, ISeleccionadorDeGeneroMono, ITransicionEscenaMono
{
    [SerializeField] private List<Toggle> listaDeGenerosSeleccionables;
    [SerializeField] private Button botonDeContinuar;
    private LogicaDeSeleccionadorDeGenero logica;
    private TransicionEscenaLogica logicaTransicion;
    [SerializeField] bool hasEnter;
    [SerializeField] Image cortina;

    public void MostrarErrorDeListaDeGeneros(string mensajeDeError)
    {
        Debug.LogError(mensajeDeError);
    }

    private void Start()
    {
        logica = new LogicaDeSeleccionadorDeGenero(this, listaDeGenerosSeleccionables);
        logicaTransicion = new TransicionEscenaLogica(this, hasEnter, cortina);
        botonDeContinuar.onClick.AddListener(() => {
            logica.ListaDeGenerosSeleccionados();
        });
    }

    public void IrseHaciaLaEscenaDelJuego()
    {
        logicaTransicion.OnTransicion();
    }

    public void CambiarDeEscena()
    {
        SceneManager.LoadScene(2);
    }
}