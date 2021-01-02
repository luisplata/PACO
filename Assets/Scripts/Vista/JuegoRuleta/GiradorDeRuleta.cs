﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GiradorDeRuleta : MonoBehaviour, ISeleccionadorDeCartasMono
{
    [SerializeField] private Button seleccionDeCarta, irHaciaPantallaDeEleccionDeGenero;
    [SerializeField] private TextMeshProUGUI texto;
    private LogicaParaGirarLaRuleta logica;

    private void Awake()
    {
        ServiceLocator.Instance.GetService<ITransicionEscenaMono>().OnTransicion();
    }
    // Start is called before the first frame update
    void Start()
    {
        logica = new LogicaParaGirarLaRuleta(this, texto);
        seleccionDeCarta.onClick.AddListener(() =>
        {
            logica.SeleccionaUnaOpcion();
        });
        irHaciaPantallaDeEleccionDeGenero.onClick.AddListener(() =>
        {
            ServiceLocator.Instance.GetService<ITransicionEscenaMono>().OnTransicion(3);
        });
    }
}