﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaDeLaSeleccionDeJuego : MonoBehaviour, ILogicaParaSeleccionarJuegoMono
{
    [SerializeField] private List<Juego> listaDeJuegos;
    [SerializeField] private string endPoint;
    private ILogicaParaSeleccionarJuego seleccionadorDeJuego;


    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void Start()
    {
        seleccionadorDeJuego = new LogicaParaSeleccionarJuego(this);
        ServiceLocator.Instance.GetService<ITransicionEscenaMono>().OnTransicion();
        //Debemos buscar el boton de cada uno y colocarle la logica
        foreach (Juego j in listaDeJuegos)
        {
            j.gameObject.GetComponent<Button>().onClick.AddListener(() => {
                seleccionadorDeJuego.LoQueDebeHacerElBotonCuandoEsPrecionado(j.Escena);
            });
        }
    }
    private void Update()
    {
        seleccionadorDeJuego.DeseoSalirDelJuego(Input.GetKeyDown(KeyCode.Escape));
    }
}