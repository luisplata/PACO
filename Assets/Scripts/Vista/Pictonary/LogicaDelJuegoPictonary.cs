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
    public int controlDePasos;
    private float tiempoMaximoPorPartida;
    private IBaraja baraja;
    private float tiempoDeAumentoDeTrago, tiempoParametrizadoParaCadaAumento;
    private int cantidadDeTragosAcumulados;

    public LogicaDelJuegoPictonary(IReglasDelJuegoPictonary reglasDelJuegoPictonary, TextMeshProUGUI cantidadDeTragos, TextMeshProUGUI cronometro, TextMeshProUGUI loQueTieneQueDibujar, Image iconoCerveza, Animator animaciones, float tiempoMaximoPorPartida, float tiempoParametrizado)
    {
        this.reglasDelJuegoPictonary = reglasDelJuegoPictonary;
        this.cantidadDeTragos = cantidadDeTragos;
        this.cronometro = cronometro;
        this.loQueTieneQueDibujar = loQueTieneQueDibujar;
        this.iconoCerveza = iconoCerveza;
        this.animaciones = animaciones;
        this.tiempoMaximoPorPartida = tiempoMaximoPorPartida;
        this.tiempoParametrizadoParaCadaAumento = tiempoParametrizado;

        SetearTextoDeInicio();

        SeteandoActividadDeCamposVisibles(false);

        clickDisponible = true;
        List<ICarta> cartas = ServiceLocator.Instance.GetService<IBuscadorDeTextosPorJuego>().Buscar(new Genero("Normal"), "pictonary");
        baraja = new Baraja(cartas);
    }

    internal void SonarCarton()
    {
        ServiceLocator.Instance.GetService<IPlaySoundEfect>().PlayOneShot("cartonPictonary");
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
    int tiempoDelSegundo = 1;
    float deltaDelSegundo = 0;
    public void CalculoDelTiempo(float deltaTime)
    {
        if (controlDePasos == 1 && clickDisponible)
        {
            tiempoTranscurrido += deltaTime;
            tiempoDeAumentoDeTrago += deltaTime;
            deltaDelSegundo += deltaTime;
            if (tiempoTranscurrido >= tiempoMaximoPorPartida)
            {
                clickDisponible = false;
                animaciones.SetTrigger("finDelTiempo");
                return;
            }
            if(deltaDelSegundo >= tiempoDelSegundo)
            {
                deltaDelSegundo = 0;
                cronometro.text = SeteandoTextoParaCronometro();
                //Aqui va el sonido
                ServiceLocator.Instance.GetService<IPlaySoundEfect>().PlayOneShot("Reloj");
            }
            if(tiempoDeAumentoDeTrago >= tiempoParametrizadoParaCadaAumento)
            {
                tiempoDeAumentoDeTrago = 0;
                cantidadDeTragosAcumulados++;
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
        SetearTextoDeInicio();
    }

    public void VolverEmpezar()
    {
        clickDisponible = true;
        SeteandoActividadDeCamposVisibles(false);
        tiempoTranscurrido = 0;
        deltaDelSegundo = 0;
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
            case 1:
                animaciones.SetTrigger("finDelTiempo");
                break;
            case 2:
                animaciones.SetTrigger("volverEmpezar");
                controlDePasos = 0;
                break;
        }
    }

    public void IncrementCase()
    {
        controlDePasos++;
    }

    public void StartAgain()
    {
        controlDePasos = 0;
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
        cronometro.text = SeteandoTextoParaCronometro();
        cantidadDeTragosAcumulados = 0; 
        tiempoDeAumentoDeTrago = 0;
        tiempoParametrizadoParaCadaAumento = 0;
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