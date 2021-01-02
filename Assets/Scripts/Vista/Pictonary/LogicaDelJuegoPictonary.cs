using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogicaDelJuegoPictonary
{
    private TextMeshProUGUI cantidadDeTragos;
    private TextMeshProUGUI cronometro;
    private TextMeshProUGUI loQueTieneQueDibujar;
    private Image iconoCerveza;
    private Animator animaciones;
    private IReglasDelJuegoPictonary reglasDelJuegoPictonary;
    private bool clickDisponible;
    private float tiempoTranscurrido;
    private int controlDePasos;
    private float tiempoMaximoPorPartida;
    private IBaraja baraja;
    private int maxDeTragos;
    private float intervalos;
    private int cantidadDeTragosAcumulados;

    public LogicaDelJuegoPictonary(IReglasDelJuegoPictonary reglasDelJuegoPictonary, TextMeshProUGUI cantidadDeTragos, TextMeshProUGUI cronometro, TextMeshProUGUI loQueTieneQueDibujar, Image iconoCerveza, Animator animaciones, float tiempoMaximoPorPartida, int maxDeTragos)
    {
        this.reglasDelJuegoPictonary = reglasDelJuegoPictonary;
        this.cantidadDeTragos = cantidadDeTragos;
        this.cronometro = cronometro;
        this.loQueTieneQueDibujar = loQueTieneQueDibujar;
        this.iconoCerveza = iconoCerveza;
        this.animaciones = animaciones;
        this.tiempoMaximoPorPartida = tiempoMaximoPorPartida;
        this.maxDeTragos = maxDeTragos;
        intervalos = tiempoMaximoPorPartida / maxDeTragos;

        SetearTextoDeInicio();

        SeteandoActividadDeCamposVisibles(false);

        clickDisponible = true;
        List<ICarta> cartas = ServiceLocator.Instance.GetService<IBuscadorDeTextosPorJuego>().Buscar(new Genero("Normal"), "pictonary");
        baraja = new Baraja(cartas);
    }

    public void IrHaciaAtras(bool isAtras)
    {
        if (isAtras)
        {
            ServiceLocator.Instance.GetService<ITransicionEscenaMono>().OnTransicion(0);
        }
    }

    private void SetearTextoDeInicio()
    {
        loQueTieneQueDibujar.text = "Presiona la pantalla para empezar";
    }

    public void CalculoDelTiempo(float deltaTime)
    {
        if (controlDePasos == 1 && clickDisponible)
        {
            tiempoTranscurrido += deltaTime;
            cronometro.text = SeteandoTextoParaCronometro();
            if(tiempoTranscurrido >= tiempoMaximoPorPartida)
            {
                clickDisponible = false;
                animaciones.SetTrigger("finDelTiempo");
            }
            else
            {
                cantidadDeTragosAcumulados = (int)(tiempoTranscurrido / intervalos) + 1;
                cantidadDeTragos.text = SeteandoCantidadDeTragosAcumulados();
            }
        }
    }

    private string SeteandoCantidadDeTragosAcumulados()
    {
        return $"X {cantidadDeTragosAcumulados}";
    }

    public void FinDelJuego()
    {
        controlDePasos = 2;
        SetearTextoDeInicio();
    }

    public void VolverEmpezar()
    {
        controlDePasos = 0;
        clickDisponible = true;
        SeteandoActividadDeCamposVisibles(false);
    }

    private string SeteandoTextoParaCronometro()
    {
        var segundos = (int)tiempoTranscurrido % 60;
        var Ssegundos  = segundos < 10 ? "0" + segundos.ToString(): segundos.ToString();
        var minutos = (int) tiempoTranscurrido / 60;
        var Sminutos = minutos < 10 ? "0" + minutos.ToString() : minutos.ToString();
        return $"{Sminutos}:{Ssegundos}";
    }

    public void BotonPresionado()
    {
        switch (controlDePasos)
        {
            case 0:
                animaciones.SetTrigger("ready");
                break;
            case 2:
                animaciones.SetTrigger("volverEmpezar");
                controlDePasos = 0;
                break;
        }
    }

    public void Ready()
    {
        loQueTieneQueDibujar.text = "Ready";
    }

    public void Go()
    {
        loQueTieneQueDibujar.text = "Go";
    }

    public void EndGo()
    {
        //TODO buscar lo que tiene que dibujar
        loQueTieneQueDibujar.text = baraja.TomarCarta().Texto;
        loQueTieneQueDibujar.fontSize = 50;
        tiempoTranscurrido = 0;
        controlDePasos = 1;
        cronometro.text = SeteandoTextoParaCronometro();
        cantidadDeTragos.text = SeteandoCantidadDeTragosAcumulados();
        SeteandoActividadDeCamposVisibles(true);
    }

    private void SeteandoActividadDeCamposVisibles(bool i)
    {
        iconoCerveza.gameObject.SetActive(i);
        cantidadDeTragos.gameObject.SetActive(i);
        cronometro.gameObject.SetActive(i);
    }
}