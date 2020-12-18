using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaDeLaSeleccionDeJuego : MonoBehaviour, ILogicaParaSeleccionarJuegoMono
{
    [SerializeField] private List<Juego> listaDeJuegos;
    private ILogicaParaSeleccionarJuego seleccionadorDeJuego;

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
}
