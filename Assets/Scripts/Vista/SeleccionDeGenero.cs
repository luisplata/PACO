using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SeleccionDeGenero : MonoBehaviour, ISeleccionadorDeGeneroMono
{
    [SerializeField] private List<Toggle> listaDeGenerosSeleccionables;
    [SerializeField] private Button botonDeContinuar;
    private LogicaDeSeleccionadorDeGenero logica;

    public void MostrarErrorDeListaDeGeneros(string mensajeDeError)
    {
        Debug.LogError(mensajeDeError);
    }

    private void Start()
    {
        logica = new LogicaDeSeleccionadorDeGenero(this, listaDeGenerosSeleccionables);
        botonDeContinuar.onClick.AddListener(() => {
            logica.ListaDeGenerosSeleccionados();
        });
    }

    public void IrseHaciaLaEscenaDelJuego()
    {
        SceneManager.LoadScene(2);
    }
}