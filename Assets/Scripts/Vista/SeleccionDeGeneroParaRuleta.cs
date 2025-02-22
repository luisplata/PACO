﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class SeleccionDeGeneroParaRuleta : SeleccionDeGenero
{
    private LogicaDeSeleccionadorDeGenero logica;

    public override void IrseHaciaLaEscenaDelJuego()
    {
        ServiceLocator.Instance.GetService<ITransicionEscenaMono>().OnTransicion(4);
    }

    protected override void Awake()
    {
        logica = new LogicaDeSeleccionadorDeGenero(this, listaDeGenerosSeleccionables);
        base.Awake();
    }

    private void Update()
    {
        logica.DeboIrHaciaAtras(Input.GetKeyDown(KeyCode.Escape));
    }

    protected override void LoQueDebeHacerElBotonCuandoTerminenDeSeleccionarLosGeneros()
    {
        logica.ListaDeGenerosSeleccionados();
    }

    internal override void LoQueDebeHacerElBotonCuandoQueremosIrHaciaAtras()
    {
        ServiceLocator.Instance.GetService<ITransicionEscenaMono>().OnTransicion(0);
    }
}