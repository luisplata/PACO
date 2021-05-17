using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaDeCreditos : MonoBehaviour
{
    private void Awake()
    {
        ServiceLocator.Instance.GetService<ITransicionEscenaMono>().OnTransicion();
    }
}
